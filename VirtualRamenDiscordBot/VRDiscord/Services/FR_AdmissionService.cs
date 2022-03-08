using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using VRDiscord.Channels;
using VRDiscord.Constants;
using VRDiscord.Services.Core;

namespace VRDiscord.Services
{
    public class FR_AdmissionService : AdmissionService
    {
        public override ulong ChannelId => ChannelConstants.FR_Rules;
        
        public override string LanguageRoleName => RoleConstants.French;

        public override async Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction)
        {
            await base.ReactionAdded(channel, user, reaction);
            await user.SendMessageAsync(
                "Vous êtes maintenant un membre vérifié du serveur Discord Virtual Ramen.");
        }
    }
}