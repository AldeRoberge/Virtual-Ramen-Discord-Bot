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
    /// Handles the regeneration method.
    /// Updates the title, description and image of the channel.
    /// Also populates the channel with messages and reactions on the messages.
    /// </summary>
    public class RoleListennerModule : InteractionModuleBase<SocketInteractionContext>
    {
        private DiscordAPI _client;

        public List<RoleService> RoleUpdaterServices;

        public RoleListennerModule(DiscordAPI socketClient)
        {
            _client = socketClient;

            RoleUpdaterServices = ReflectionUtils<RoleService>.Load();

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

            foreach (RoleService roleUpdaterService in RoleUpdaterServices)
            {
                if (roleUpdaterService.ChannelId == channel.Id)
                {
                    await roleUpdaterService.RemoveRole(channel, r, reaction);
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

            foreach (RoleService roleUpdaterService in RoleUpdaterServices)
            {
                if (roleUpdaterService.ChannelId == channel.Id)
                {
                    await roleUpdaterService.AddRole(channel, r, reaction);
                }
            }
        }
    }
}