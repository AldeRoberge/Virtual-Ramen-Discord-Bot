using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Utils;

namespace VRDiscord.Channels.Rules.Core
{
    public abstract class RulesChannel : ChannelGenerator
    {
        public abstract List<Rule> Rules { get; }

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // messageContainer.AddImage("Channels/Rules/Rules.png");

            var colors = GradientGenerator.GetColors(  new Color(0, 0, 0), new Color(255, 0, 0), Rules.Count);

            for (int i = 0; i < Rules.Count; i++)
            {
                // Gets the rule
                var rule = Rules[i];

                messageContainer.AddEmbed(new EmbedBuilder
                {
                    Title = "Article " + (i + 1),
                    Description = rule.Description,
                    Color = colors[i]
                });
            }
        }
    }
}