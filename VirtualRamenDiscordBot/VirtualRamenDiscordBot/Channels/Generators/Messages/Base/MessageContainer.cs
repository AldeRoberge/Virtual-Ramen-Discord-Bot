using System.Collections.Generic;
using _04_interactions_framework.Channels.Messages;
using Discord;

namespace _04_interactions_framework.Channels
{
    public class MessageContainer
    {
        public List<Message> Messages = new List<Message>();

        public void AddMessage(Message m)
        {
            Messages.Add(m);
        }

        public Message AddEmbed(EmbedBuilder embedBuilder)
        {
            var msg = new EmbedMessage(embedBuilder);
            Messages.Add(msg);
            
            return msg;
        }

        public Message AddText(string text)
        {
            var msg = new TextMessage(text);
            Messages.Add(msg);
            
            return msg;
        }

        public Message AddImage(string imageUrl)
        {
            var msg = new ImageMessage(imageUrl);
            Messages.Add(msg);
            
            return msg;
        }
    }
}