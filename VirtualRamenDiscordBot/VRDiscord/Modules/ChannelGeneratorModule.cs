using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using VRDiscord.Channels;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Utils;

namespace VRDiscord.Modules
{
    /// <summary>
    /// Handles the regeneration method.
    /// Updates the title, description and image of the channel.
    /// Also populates the channel with messages and reactions on the messages.
    /// </summary>
    public class ChannelGeneratorModule : InteractionModuleBase<SocketInteractionContext>
    {
        public readonly List<ChannelGenerator> Channels;

        // Dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
        public InteractionService Commands { get; set; }

        private CommandHandler _handler;

        private DiscordAPI _client;

        // Constructor injection is also a valid way to access the dependecies
        public ChannelGeneratorModule(CommandHandler handler, DiscordAPI socketClient)
        {
            _handler = handler;
            _client = socketClient;

            // Load the Channel Generators
            Channels = new List<ChannelGenerator>();
            Channels.AddRange(ReflectionUtils<ChannelGenerator>.Load());
        }

        // Slash Commands are declared using the [SlashCommand], you need to provide a name and a description, both following the Discord guidelines
        [SlashCommand("regen", "Regens the channels")]
        [Utils.RequireOwner]
        public async Task Regen(Channels.Channels channelsToUpdate)
        {
            foreach (ChannelGenerator chanel in Channels)
            {
                try
                {
                    if (channelsToUpdate != VRDiscord.Channels.Channels.All && channelsToUpdate != chanel.Channel.Channels)
                    {
                        continue;
                    }

                    // DiscordAPI
                    IMessageChannel c = _client.GetChannelById(chanel.Channel.Id);

                    await ReplyAsync("Updating channel '" + c.Name + "'.");

                    if (chanel.DeleteAllMessages)
                    {
                        await ReplyAsync("Deleting all messages.");
                        await c.DeleteAllMessages();
                    }

                    SocketTextChannel channel = (SocketTextChannel)c;

                    if (channel.Name != chanel.Channel.Name ||
                        channel.Topic != chanel.Channel.Topic)
                    {
                        Console.WriteLine("Updating outdated channel information...");

                        await channel.ModifyAsync(prop =>
                        {
                            prop.Name = chanel.Channel.Name;
                            prop.Topic = chanel.Channel.Topic;
                        });
                    }

                    // Start building the messages
                    MessageContainer m = new MessageContainer();
                    chanel.PopulateMessages(m);

                    if (m.Messages.Count > 0)
                    {
                        await ReplyAsync("Found " + m.Messages.Count + " message(s) to send.");
                    }

                    foreach (var message in m.Messages)
                    {
                        try
                        {
                            IUserMessage resultMsg = null;

                            switch (message)
                            {
                                case ImageMessage imageMessage:
                                    resultMsg = await c.SendFileAsync(imageMessage.ImagePath);
                                    break;
                                case TextMessage textMessage:
                                    resultMsg = await c.SendMessageAsync(textMessage.Text);
                                    break;
                                case EmbedMessage embedMessage:
                                    resultMsg = await c.SendMessageAsync(embedMessage.Text, false,
                                        embedMessage.EmbedBuilder.Build());
                                    break;
                                default:
                                    Console.WriteLine("Error, unknown type of message : " + typeof(Message) + ".");
                                    break;
                            }

                            if (resultMsg != null)
                            {
                                // Adds the reactions for the message
                                foreach (var messageEmote in message.Emotes)
                                {
                                    await resultMsg.AddReactionAsync(messageEmote);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("Error (" + e.Message + ") while sending message : '" + message + "'.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while updating channel '" + chanel.Channel.Name + "' : " +
                                      e.Message);
                    await ReplyAsync("Error while updating channel '" + chanel.Channel.Name + "' : " +
                                     e.Message);
                }
            }

            await ReplyAsync("Regen completed.");
        }
    }
}