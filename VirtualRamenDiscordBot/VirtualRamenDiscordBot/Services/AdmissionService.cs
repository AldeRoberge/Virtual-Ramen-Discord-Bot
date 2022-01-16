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
    public class AdmissionService : ReactionService
    {
        
        public override ulong ChannelId => ChannelConstants.Admission;
        
        public const string AdmittedRoleName = "Membre";

        public IRole AdmittedRole;

        public override async Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();

            Console.WriteLine("Admission requested by : " + user.Username);

            AdmittedRole ??= user.Guild.Roles.FirstOrDefault(r => r.Name == AdmittedRoleName);
            await user.AddRoleAsync(AdmittedRole);
        }

        public override Task ReactionRemoved(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user, SocketReaction reaction)
        {
            return Task.CompletedTask;
        }
    }
}