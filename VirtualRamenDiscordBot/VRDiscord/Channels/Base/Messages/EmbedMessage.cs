using Discord;
using VRDiscord.Channels.Base.Messages.Base;

namespace VRDiscord.Channels.Base.Messages
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