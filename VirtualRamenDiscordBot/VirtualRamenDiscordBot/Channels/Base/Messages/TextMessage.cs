using VirtualRamenDiscordBot.Channels.Base.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Base.Messages
{
    /// <summary>
    /// Simple text message.
    /// </summary>
    public class TextMessage : Message
    {
        public string Text;

        public TextMessage(string text)
        {
            Text = text;
        }
    }
}