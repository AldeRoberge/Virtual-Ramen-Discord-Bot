using VRDiscord.Channels.Base.Messages.Base;

namespace VRDiscord.Channels.Base.Messages
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