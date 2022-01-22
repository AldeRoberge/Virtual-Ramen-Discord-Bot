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
    public abstract class AdmissionService : ReactionService
    {
        public abstract string LanguageRoleName { get; }

        public IRole MemberRole;

        public override async Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            var c = await channel.GetOrDownloadAsync();

            Console.WriteLine("Admission requested by : " + user.Username);

            // Add the member role
            MemberRole ??= user.Guild.Roles.FirstOrDefault(r => r.Name == RoleConstants.Member);
            await user.AddRoleAsync(MemberRole);

            // Add the language role
            var languageRole = user.Guild.Roles.FirstOrDefault(r => r.Name == LanguageRoleName);
            
            if (languageRole != null)
            {
                await user.AddRoleAsync(languageRole);
            }
            else
            {
                Console.WriteLine("Language role "+LanguageRoleName+" not found");
            }
        }

        public override Task ReactionRemoved(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            return Task.CompletedTask;
        }
    }
}