using Discord;

namespace _04_interactions_framework.Channels.Messages
{
    public class EmbedMessage : Message
    {
        public string Text;
        public EmbedBuilder EmbedBuilder;

        public EmbedMessage(EmbedBuilder embedBuilder, string text = "")
        {
            EmbedBuilder = embedBuilder;
            Text = text;
        }
    }
}