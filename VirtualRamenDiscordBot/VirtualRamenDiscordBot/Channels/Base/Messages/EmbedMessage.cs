using Discord;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Generators.Messages
{
    /// <summary>
    /// An Embed and optional text.
    /// </summary>
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