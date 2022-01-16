using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VirtualRamenDiscordBot.Channels;
using VirtualRamenDiscordBot.Channels.Roles;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;
using VirtualRamenDiscordBot.Services.RoleServices.Base;

namespace VirtualRamenDiscordBot.Services
{
    /// <summary>
    /// Gives or removes a role based on the reaction on a message from the user.
    /// </summary>
    public class RoleUpdaterService : RoleService
    {

        public override ulong ChannelId => ChannelConstants.Roles;
        
        public override async Task AddRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();
            await UpdateRole(true, c, user, reaction);
        }

        public override async Task RemoveRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
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