using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace VirtualRamenDiscordBot.Services.RoleServices.Base
{
    public abstract class RoleService
    {
        public abstract ulong ChannelId { get; }
        
        public abstract Task AddRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction);
        
        public abstract Task RemoveRole(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction);
        
    }
}