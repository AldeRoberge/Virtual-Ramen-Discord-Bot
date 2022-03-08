using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VRDiscord.Channels;
using VRDiscord.Constants;
using VRDiscord.Services.Core;

namespace VRDiscord.Services
{
    public class EN_AdmissionService : AdmissionService
    {
        public override ulong ChannelId => ChannelConstants.EN_Rules;

        public override string LanguageRoleName => RoleConstants.English;

        public override async Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            await base.ReactionAdded(channel, user, reaction);
            await user.SendMessageAsync("You are now a member of the Virtual Ramen Discord Server.");
        }
    }
}