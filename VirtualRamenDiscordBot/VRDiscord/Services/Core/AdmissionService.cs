using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VRDiscord.Constants;
using VRDiscord.Services.RoleServices.Base;

namespace VRDiscord.Services.Core
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
            
            user.Roles.ToList().ForEach(x =>
            {
                if (x == MemberRole)
                {
                    Console.WriteLine("User already has role");
                    return; // User already has role
                }
            });
            
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