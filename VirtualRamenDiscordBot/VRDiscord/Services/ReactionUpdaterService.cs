using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VRDiscord.Channels;
using VRDiscord.Channels.Roles;
using VRDiscord.Modules;
using VRDiscord.Services.RoleServices.Base;

namespace VRDiscord.Services
{
    /// <summary>
    /// Gives or removes a role based on the reaction on a message from the user.
    /// </summary>
    public class ReactionUpdaterService : ReactionService
    {
        public override ulong ChannelId => ChannelConstants.Roles;

        public override async Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();
            await UpdateRole(true, c, user, reaction);
        }

        public override async Task ReactionRemoved(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();
            await UpdateRole(false, c, user, reaction);
        }

        private async Task UpdateRole(bool b, IMessageChannel c, SocketGuildUser user, IReaction reaction)
        {
            // Return if the user is a bot
            if (user.IsBot) return;

            Console.WriteLine("Received reaction : " + reaction.Emote.Name + " from " + user.Username);

            foreach (var selectableRole in RolesChannel.SelectableRoles)
            {
                if (Equals(selectableRole.Emote, reaction.Emote))
                {
                    Console.WriteLine("Found selectable role : " + selectableRole.Name);

                    // Gets the role from the guild
                    var role = user.Guild.Roles.FirstOrDefault(r => r.Name == selectableRole.Name);

                    if (role == null)
                    {
                        await LoggerModule.Log("Could not find a role with the name '" + selectableRole.Name + "'.",
                            user);
                        return;
                    }

                    // Add or remove the role
                    if (b)
                        await user.AddRoleAsync(role);
                    else
                        await user.RemoveRoleAsync(role);

                    return;
                }
            }
        }
    }
}