using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using _04_interactions_framework.Channels;
using _04_interactions_framework.Channels.Messages;
using _04_interactions_framework.Utils;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace _04_interactions_framework.Modules
{
    public class ChannelModule : InteractionModuleBase<SocketInteractionContext>
    {
        public List<ChannelGenerator> Channels = new List<ChannelGenerator>()
        {
            new WelcomeChannel()
        };


        // Dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
        public InteractionService Commands { get; set; }

        private CommandHandler _handler;

        private DiscordAPI _client;

        // Constructor injection is also a valid way to access the dependecies
        public ChannelModule(CommandHandler handler, DiscordAPI socketClient)
        {
            _handler = handler;
            _client = socketClient;
        }


        // Slash Commands are declared using the [SlashCommand], you need to provide a name and a description, both following the Discord guidelines
        [SlashCommand("regen", "Regens the channels")]
        [RequireOwner]
        public async Task Regen()
        {
            foreach (ChannelGenerator channelGenerator in Channels)
            {
                // DiscordAPI
                IMessageChannel c = _client.GetChannelById(channelGenerator.Channel.Id);

                await ReplyAsync("Updating '" + c.Name + "'.");

                await ReplyAsync("Deleting all messages...");
                await c.DeleteAllMessages();

                SocketTextChannel channel = (SocketTextChannel) c;

                await ReplyAsync("Updating channel information...");
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
                    await ReplyAsync("Sending message '" + message.ToString() + "'.");

                    switch (message)
                    {
                        case ImageMessage imageMessage:
                            await c.SendFileAsync(imageMessage.ImagePath);
                            break;
                        case TextMessage textMessage:
                            await c.SendMessageAsync(textMessage.Text);
                            break;
                        case EmbedMessage embedMessage:
                            await c.SendMessageAsync(embedMessage.Text, false, embedMessage.EmbedBuilder.Build());
                            break;
                    }
                }
            }
        }
    }
}