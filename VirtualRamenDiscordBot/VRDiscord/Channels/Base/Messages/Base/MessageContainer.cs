using System.Collections.Generic;
using Discord;
using VRDiscord.Constants;

namespace VRDiscord.Channels.Base.Messages.Base
{
    /// <summary>
    /// Contains a series of messages that can be sent to a channel during regeneration.
    /// </summary>
    public class MessageContainer
    {
        public List<Message> Messages = new();

        public void AddMessage(Message m)
        {
            Messages.Add(m);
        }

        public EmbedMessage AddEmbed(EmbedBuilder embedBuilder)
        {
            var msg = new EmbedMessage(embedBuilder);
            Messages.Add(msg);

            return msg;
        }

        public TextMessage AddText(string text)
        {
            var msg = new TextMessage(text);
            Messages.Add(msg);

            return msg;
        }

        public ImageMessage AddImage(string imageUrl)
        {
            var msg = new ImageMessage(imageUrl);
            Messages.Add(msg);

            return msg;
        }

        // Utility method to add an horizontal separator
        public void AddSeparator()
        {
            AddText(TextConstants.HorizontalSeparator);
        }
    }
}