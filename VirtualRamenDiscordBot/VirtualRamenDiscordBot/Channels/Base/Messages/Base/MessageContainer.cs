using System.Collections.Generic;
using Discord;

namespace VirtualRamenDiscordBot.Channels.Generators.Messages.Base
{
    /// <summary>
    /// Contains a series of messages that can be sent to a channel during regeneration.
    /// </summary>
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