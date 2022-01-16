using System;
using System.Linq;
using Discord;
using Discord.WebSocket;

namespace _04_interactions_framework
{
    public class DiscordAPI : DiscordSocketClient
    {
        private SocketGuild _guild;

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