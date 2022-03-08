using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Utils;

namespace VRDiscord.Channels.Welcome.Core
{
    public abstract class WelcomeChannel : ChannelGenerator
    {
        public abstract List<Website> Websites { get; }

        /// <summary>
        /// Passes messageContainer to be filled with Messages.
        /// </summary>
        public override void PopulateMessages(MessageContainer messageContainer)
        {
            var colors = GradientGenerator.GetColors(new Color(0, 0, 0), new Color(255, 0, 0), Websites.Count);

            for (int i = 0; i < Websites.Count; i++)
            {
                // Gets the rule
                var website = Websites[i];

                messageContainer.AddEmbed(new EmbedBuilder
                {
                    Title = website.Name,
                    Description = website.URL,
                    Fields = new List<EmbedFieldBuilder>()
                    {
                        new()
                        {
                            Name = "Description",
                            Value = website.Description,
                            IsInline = false
                        }
                    },
                    Color = colors[i],
                    // Make sure its not null
                    ThumbnailUrl = website.ThumbnailURL
                });
            }
        }
    }
}