using System.Collections.Generic;

namespace _04_interactions_framework.Channels
{
    public class MessageContainer
    {
        public List<Message> Messages = new List<Message>();
        
        public void AddMessage(Message m)
        {
            Messages.Add(m);
        }
    }
}