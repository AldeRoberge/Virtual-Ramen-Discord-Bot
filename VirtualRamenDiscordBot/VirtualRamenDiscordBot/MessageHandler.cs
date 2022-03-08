using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

namespace VirtualRamenDiscordBot
{
    public class MessageHandler : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly DiscordAPI _client;

        public MessageHandler(DiscordAPI client)
        {
            _client = client;
        }

        public async Task InitializeAsync()
        {
            // Process the InteractionCreated payloads to execute Interactions commands
            _client.MessageReceived += async (message) =>
            {
                if (message.Author.IsBot)
                    return;

                //DialogAnswer d = DialogService.GetSimpleAnswer(message.Content);
                //await ReplyAsync(d.Answer);
            };
        }
    }
}