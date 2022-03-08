using System;
using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Channels.Roles.SelectableRoles.Base;
using VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles.Base;
using VRDiscord.Utils;

namespace VRDiscord.Channels.Roles
{
    /// <summary>
    /// Generates the Role channel, which is responsible for generating the messages used to automatically assign roles to users based on emotes.
    /// </summary>
    public class RolesChannel : ChannelGenerator
    {
        public override bool DeleteAllMessages => true;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.Roles,
            Name = "「🔎」rôles",
            Topic = "Permet de sélectionner ses propres rôles.",
            Channels = Channels.Roles
        };

        public static List<SelectableRole> SelectableRoles;

        static RolesChannel()
        {
            SelectableRoles = ReflectionUtils<SelectableRole>.Load();
        }

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddImage("Channels/Roles/Notifications.png");

            List<IEmote> emotes = new List<IEmote>();
            Console.WriteLine("Loading " + SelectableRoles.Count + " selectable roles...");

            List<Color> colors = GradientGenerator.GetRainbowGradient(SelectableRoles.Count);

            int i = 0;

            List<LanguageSelectableRole> languageRoles = new List<LanguageSelectableRole>();

            foreach (SelectableRole selectableRole in SelectableRoles)
            {
                if (selectableRole is LanguageSelectableRole languageRole)
                {
                    languageRoles.Add(languageRole);
                }
                else
                {
                    Console.WriteLine("Adding Role : " + selectableRole.Name);
                    messageContainer.AddEmbed(selectableRole.EmbedBuilder.WithColor(colors[i]));
                }

                i++;
            }

            foreach (LanguageSelectableRole languageRole in languageRoles)
            {
                messageContainer.AddEmbed(languageRole.EmbedBuilder)
                    .AddEmoji(languageRole.Emote);
            }

            TextMessage text = messageContainer.AddText("React here to select your role.");

            // Add the emojis
            foreach (SelectableRole selectableRole in SelectableRoles)
            {
                text.AddEmoji(selectableRole.Emote);
            }
        }
    }
}