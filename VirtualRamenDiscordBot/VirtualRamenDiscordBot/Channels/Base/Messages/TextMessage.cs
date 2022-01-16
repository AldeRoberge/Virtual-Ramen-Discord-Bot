using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Generators.Messages
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