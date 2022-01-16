using System.Collections.Generic;
using Discord;

namespace _04_interactions_framework.Channels
{
    public class RolesChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Roles,
            Name = "「💬」welcome",
            Topic = "Allows for some welcome messages to be sent to new members."
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Hey",
                Description = "Test Description"
            });

            messageContainer.AddText("Some text");
            messageContainer.AddImage("Channels/Generators/Welcome/Welcome.png");
        }
    }
}