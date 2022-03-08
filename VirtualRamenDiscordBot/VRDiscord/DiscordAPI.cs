using System.Linq;
using Discord;
using Discord.WebSocket;

namespace VRDiscord
{
    /// <summary>
    /// Gives a higher level of control over the bot.
    /// Allows for methods that hide some logic for the users of the bot.
    /// </summary>
    public class DiscordAPI : DiscordSocketClient
    {
        private SocketGuild _guild;

        public DiscordAPI(DiscordSocketConfig config) : base(config)
        {
        }

        public SocketGuild GetGuild()
        {
            return _guild ??= Guilds.First();
        }

        public IMessageChannel GetChannelByName(string name)
        {
            return GetGuild().Channels.FirstOrDefault(x => x.Name == name) as IMessageChannel;
        }

        public IMessageChannel GetChannelById(ulong id)
        {
            return GetGuild().Channels.FirstOrDefault(x => x.Id == id) as IMessageChannel;
        }
    }
}