using Discord;
using VirtualRamenDiscordBot.Channels.Generators.Base;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Welcome
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class WelcomeChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Welcome,
            Name = "「💬」welcome",
            Topic = "Allows for some welcome messages to be sent to new members.",
            ChannelsEnum = ChannelsEnum.Welcome
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Hey",
                Description = "Test Description"
            });

            messageContainer.AddText("Some text");
            messageContainer.AddImage("Channels/Welcome/Welcome.png");
        }
    }
}