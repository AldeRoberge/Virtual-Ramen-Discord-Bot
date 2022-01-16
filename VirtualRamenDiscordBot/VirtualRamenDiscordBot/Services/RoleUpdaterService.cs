using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VirtualRamenDiscordBot.Channels;
using VirtualRamenDiscordBot.Channels.Roles;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Services
{
    public class RoleUpdaterService
    {
        public async Task AddRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();
            await UpdateRole(true, c, user, reaction);
        }

        public async Task RemoveRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();
            await UpdateRole(false, c, user, reaction);
        }

        private async Task UpdateRole(bool b, IMessageChannel c, SocketGuildUser user, SocketReaction reaction)
        {
            // Return if the user is a bot
            if (user.IsBot) return;

            // Not in the "roles" channel
            if (c.Id != ChannelConstants.Roles) return;

            Console.WriteLine("Received reaction : " + reaction.Emote.Name + " from " + user.Username);

            foreach (SelectableRole selectableRole in RolesChannel.SelectableRoles)
            {
                if (Equals(selectableRole.Emote, reaction.Emote))
                {
                    Console.WriteLine("Found selectable role : " + selectableRole.Name);

                    // Gets the role from the guild
                    var role = user.Guild.Roles.FirstOrDefault(r => r.Name == selectableRole.Name);

                    if (role == null)
                    {
                        var debg = "Could not find a role with the name '" + selectableRole.Name + "'.";
                        Console.WriteLine(debg);
                        await user.SendMessageAsync(debg);
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