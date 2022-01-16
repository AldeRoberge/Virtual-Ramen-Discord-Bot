using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _04_interactions_framework.Utils;
using Discord;
using Discord.WebSocket;

namespace _04_interactions_framework.Channels
{
    public abstract class ChannelGenerator
    {
        public abstract Channel Channel { get; }
        
        public abstract void PopulateMessages(MessageContainer messageContainer);
    }
}