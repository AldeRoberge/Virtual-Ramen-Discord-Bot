using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace VirtualRamenDiscordBot.Services.RoleServices.Base
{
    /// <summary>
    /// Defines a class that listens for reasons in a given channel.
    /// </summary>
    public abstract class ReactionService
    {
        public abstract ulong ChannelId { get; }
        
        public abstract Task ReactionAdded(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction);
        
        public abstract Task ReactionRemoved(Cacheable<IMessageChannel, ulong> channel, SocketGuildUser user,
            SocketReaction reaction);
        
    }
}