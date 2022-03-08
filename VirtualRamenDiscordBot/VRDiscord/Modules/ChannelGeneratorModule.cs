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
        public async Task Regen(ChannelsEnum channelsToUpdate)
        {

        
            
            foreach (ChannelGenerator channelGenerator in Channels)
            {
                
                try
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

                await ReplyAsync("Updating channel '" + c.Name + "'. Deleting all messages : " +
                                 channelGenerator.DeleteAllMessages);

                if (channelGenerator.DeleteAllMessages)
                {
                    await c.DeleteAllMessages();
                }

                SocketTextChannel channel = (SocketTextChannel) c;

               


                if (channel.Name != channelGenerator.Channel.Name || channel.Topic != channelGenerator.Channel.Topic)
                {
                    Console.WriteLine("Updating channel information...");
                    
                    await channel.ModifyAsync(prop =>
                    {
                        prop.Name = channelGenerator.Channel.Name;
                        prop.Topic = channelGenerator.Channel.Topic;
                    });
                }

                MessageContainer m = new MessageContainer();
                channelGenerator.PopulateMessages(m);

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
                        await ReplyAsync("Error while sending message : '" + message.ToString() + "'.");
                    }
                }
                
                } catch (Exception e)
                {
                    Console.WriteLine("Error while updating channel '" + channelGenerator.Channel.Name + "' : " + e.Message);
                    await ReplyAsync("Error while updating channel '" + channelGenerator.Channel.Name + "' : " + e.Message);
                }
            }

            await ReplyAsync("Regen completed.");
        }
    }
}