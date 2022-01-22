using System;
using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Base;
using VirtualRamenDiscordBot.Channels.Base.Messages.Base;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.LanguageRoles.Base;
using VirtualRamenDiscordBot.Modules;
using VirtualRamenDiscordBot.Utils;

namespace VirtualRamenDiscordBot.Channels.Roles
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
            ChannelsEnum = ChannelsEnum.Roles
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

            List<LanguageRole> languageRoles = new List<LanguageRole>();

            foreach (SelectableRole selectableRole in SelectableRoles)
            {
                if (selectableRole is LanguageRole languageRole)
                {
                    languageRoles.Add(languageRole);
                }
                else
                {
                    Console.WriteLine("Adding Role : " + selectableRole.Name);
                    messageContainer.AddEmbed(selectableRole.EmbedBuilder.WithColor(colors[i]))
                        .AddEmoji(selectableRole.Emote);
                }

                i++;
            }

            foreach (LanguageRole languageRole in languageRoles)
            {
                messageContainer.AddEmbed(languageRole.EmbedBuilder)
                    .AddEmoji(languageRole.Emote);
            }
        }
    }
}