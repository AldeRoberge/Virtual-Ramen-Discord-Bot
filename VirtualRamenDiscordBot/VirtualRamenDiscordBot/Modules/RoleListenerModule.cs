using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using VirtualRamenDiscordBot.Channels;
using VirtualRamenDiscordBot.Services;
using VirtualRamenDiscordBot.Services.RoleServices.Base;
using VirtualRamenDiscordBot.Utils;

namespace VirtualRamenDiscordBot.Modules
{
    /// <summary>
    /// Handles reactions on messages that give roles.
    /// </summary>
    public class RoleListenerModule : InteractionModuleBase<SocketInteractionContext>
    {
        private DiscordAPI _client;

        public List<ReactionService> RoleUpdaterServices;

        public RoleListenerModule(DiscordAPI socketClient)
        {
            _client = socketClient;

            RoleUpdaterServices = ReflectionUtils<ReactionService>.Load();

            _client.ReactionAdded += OnReactionAdded;
            _client.ReactionRemoved += OnReactionRemoved;
        }

        private async Task OnReactionRemoved(Cacheable<IUserMessage, ulong> message,
            Cacheable<IMessageChannel, ulong> channel,
            SocketReaction reaction)
        {
            Console.WriteLine("Reaction removed...");
            var user = _client.GetGuild();
            var r = user.GetUser(reaction.UserId);

            foreach (ReactionService roleUpdaterService in RoleUpdaterServices)
            {
                if (roleUpdaterService.ChannelId == channel.Id)
                {
                    await roleUpdaterService.ReactionRemoved(channel, r, reaction);
                }
            }
        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> message,
            Cacheable<IMessageChannel, ulong> channel,
            SocketReaction reaction)
        {
            Console.WriteLine("Reaction added...");
            var user = _client.GetGuild();
            var r = user.GetUser(reaction.UserId);

            foreach (ReactionService roleUpdaterService in RoleUpdaterServices)
            {
                if (roleUpdaterService.ChannelId == channel.Id)
                {
                    await roleUpdaterService.ReactionAdded(channel, r, reaction);
                }
            }
        }
    }
}