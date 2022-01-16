using Discord;

namespace _04_interactions_framework.Channels
{
    public class Message
    {
        public EmbedBuilder EmbedBuilder;
        public string Text;

        public Message(EmbedBuilder embedBuilder, string text = "")
        {
            EmbedBuilder = embedBuilder;
            Text = text;
        }
    }
}