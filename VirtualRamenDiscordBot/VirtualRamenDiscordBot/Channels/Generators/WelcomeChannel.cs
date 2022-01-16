using System.Collections.Generic;
using Discord;

namespace _04_interactions_framework.Channels
{
    public class WelcomeChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Welcome,
            Name = "「💬」welcome",
            Topic = "Allows for some welcome messages to be sent to new members."
        };

        public override List<Embed> PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddMessage(new Message("Pee pee", new EmbedBuilder
            {
                Title = "Hey",
                Description = "Test Description"
            }));
        }
    }
}