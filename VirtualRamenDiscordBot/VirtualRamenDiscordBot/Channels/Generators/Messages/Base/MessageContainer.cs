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

        public void AddEmbed(EmbedBuilder embedBuilder)
        {
            Messages.Add(new EmbedMessage(embedBuilder));
        }

        public void AddText(string text)
        {
            Messages.Add(new TextMessage(text));
        }

        public void AddImage(string imageUrl)
        {
            Messages.Add(new ImageMessage(imageUrl));
        }
    }
}