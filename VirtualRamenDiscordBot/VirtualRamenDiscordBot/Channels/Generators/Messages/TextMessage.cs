namespace _04_interactions_framework.Channels.Messages
{
    public class TextMessage : Message
    {
        public string Text;

        public TextMessage(string text)
        {
            Text = text;
        }
    }
}