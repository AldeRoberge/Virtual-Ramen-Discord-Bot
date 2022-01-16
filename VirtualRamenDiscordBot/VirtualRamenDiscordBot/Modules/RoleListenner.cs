using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using VirtualRamenDiscordBot.Channels;
using VirtualRamenDiscordBot.Services;
using VirtualRamenDiscordBot.Utils;

namespace VirtualRamenDiscordBot.Modules
{
    /// <summary>
    /// Handles the regeneration method.
    /// Updates the title, description and image of the channel.
    /// Also populates the channel with messages and reactions on the messages.
    /// </summary>
    public class RoleListennerModule : InteractionModuleBase<SocketInteractionContext>
    {
        private DiscordAPI _client;

        RoleUpdaterService _roleUpdaterService;

        public RoleListennerModule(DiscordAPI socketClient)
        {
            _client = socketClient;

            _client.ReactionAdded += OnReactionAdded;
            _client.ReactionRemoved += OnReactionRemoved;

            _roleUpdaterService = new RoleUpdaterService();
        }

        private async Task OnReactionRemoved(Cacheable<IUserMessage, ulong> message,
            Cacheable<IMessageChannel, ulong> channel,
            SocketReaction reaction)
        {
            Console.WriteLine("Reaction removed...");
            var user = _client.GetGuild();
            var r = user.GetUser(reaction.UserId);

            await _roleUpdaterService.RemoveRole(channel, r, reaction);
        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> message,
            Cacheable<IMessageChannel, ulong> channel,
            SocketReaction reaction)
        {
            Console.WriteLine("Reaction added...");
            var user = _client.GetGuild();
            var r = user.GetUser(reaction.UserId);


            await _roleUpdaterService.AddRole(channel, r, reaction);
        }
    }
}