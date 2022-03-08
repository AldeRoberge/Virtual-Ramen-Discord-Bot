using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Channels.Rules.Core;

namespace VRDiscord.Channels.Rules
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class EN_RulesChannel : RulesChannel
    {
        public override bool DeleteAllMessages => true;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.EN_Rules,
            Name = "『📚』𝗥𝘂𝗹𝗲𝘀",
            Topic = "List of rules of the server.",
            ChannelsEnum = ChannelsEnum.Rules
        };

        public override List<Rule> Rules => new()
        {
            new Rule(
                "Respecting the usefulness of each text or voice channel is essential, if the function of a channel is not respected, the moderation team reserves the right to sanction you."),
            new Rule(
                "Your nickname must be alphanumeric. If it violates the respect of others or is not mentionable, a sanction or a change of nickname will take place."),
            new Rule(
                "Any inter-community conflict must be denounced via the support service. If the conflict takes place in a channel not dedicated to this, we reserve the right to sanction whoever is at fault."),
            new Rule(
                "Any insult, provocation, threats, spam and homophobic, racist, sexual, toxic behavior and/or attacking the integrity of a person or a community will be sanctioned. Even if the behavior does not seem embarrassing, if anyone complains about it, a sanction will be assigned."),
            new Rule(
                "In case of injustice on the part of a staff member, please contact a member of the administration by private message and not in one of the server lounges."),
            new Rule(
                "Users advertising in private message or on the server without authorization will be systematically banned."),
            new Rule(
                "No vulgar, insulting or discriminatory emoji are tolerated. The same goes for your profile picture and your nickname."),
            new Rule(
                "The references to everyone and here are strictly reserved for staff members. Misuse of mentions is also prohibited."),
            new Rule(
                "Any unjustified ticket will be sanctioned: each new ticket generates a notification for all the ticket staff members."),
            new Rule(
                "Any attempt to circumvent the rules will lead to at least a doubling of the basic sanction."),
        };


        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");

            
            base.PopulateMessages(messageContainer);
            
            messageContainer.AddSeparator();
            
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "I accept the rules",
                Description =
                    "As soon as you interact with our content, you declare that you have **read, understood and accepted** the rules. **You can't pretend not to know them**.",
                Color = new Color(0xFF0000),
                // Make sure its not null
                ThumbnailUrl = "https://drive.google.com/uc?id=14Q_J2kiZOKyE_Lc6mXyDEFwXs7O5CURc"
            }).AddEmoji("🩸");
        }
    }
}