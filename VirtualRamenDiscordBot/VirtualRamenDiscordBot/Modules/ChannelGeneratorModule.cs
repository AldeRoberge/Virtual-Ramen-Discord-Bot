using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using VirtualRamenDiscordBot.Channels;
using VirtualRamenDiscordBot.Channels.Generators.Base;
using VirtualRamenDiscordBot.Channels.Generators.Messages;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;
using VirtualRamenDiscordBot.Utils;

namespace VirtualRamenDiscordBot.Modules
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
            Channels.AddRange(RelfectionUtil<ChannelGenerator>.Load());
        }

        // Slash Commands are declared using the [SlashCommand], you need to provide a name and a description, both following the Discord guidelines
        [SlashCommand("regen", "Regens the channels")]
        [RequireOwner]
        public async Task Regen(ChannelsEnum channelsToUpdate)
        {
            foreach (ChannelGenerator channelGenerator in Channels)
            {
                int skipped = 0;

                if (channelsToUpdate != ChannelsEnum.All && channelsToUpdate != channelGenerator.Channel.ChannelsEnum)
                {
                    skipped++;
                    continue;
                }


                // DiscordAPI
                IMessageChannel c = _client.GetChannelById(channelGenerator.Channel.Id);


                Console.WriteLine("Updating channel '" + c.Name + "'. Deleting all messages...");

                await ReplyAsync("Updating channel '" + c.Name + "'.");
                await c.DeleteAllMessages();

                SocketTextChannel channel = (SocketTextChannel) c;

                Console.WriteLine("Updating channel information...");
                await channel.ModifyAsync(prop =>
                {
                    prop.Name = channelGenerator.Channel.Name;
                    prop.Topic = channelGenerator.Channel.Topic;
                });

                MessageContainer m = new MessageContainer();
                channelGenerator.PopulateMessages(m);

                await ReplyAsync("Found " + m.Messages.Count + " message(s) to send.");

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
                        await ReplyAsync("Error while sending message : '" + message.ToString() + "'.");
                    }
                }
            }


            await ReplyAsync("Regen completed.");
        }
    }

    public static class RelfectionUtil<T>
    {
        /// <summary>
        /// Loads all the classes that inherit from the given type using reflection.
        /// </summary>
        public static List<T> Load()
        {
            List<T> instances = new List<T>();

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(T)))
                {
                    instances.Add((T) Activator.CreateInstance(type));
                }
            }

            return instances;
        }
    }
}