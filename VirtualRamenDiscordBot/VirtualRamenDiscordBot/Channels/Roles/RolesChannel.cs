using System;
using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Generators.Base;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;
using VirtualRamenDiscordBot.Modules;

namespace VirtualRamenDiscordBot.Channels.Roles
{
    /// <summary>
    /// Generates the Role channel, which is responsible for generating the messages used to automatically assign roles to users based on emotes.
    /// </summary>
    public class RolesChannel : ChannelGenerator
    {
        public override ChannelsEnum ChannelsEnum => ChannelsEnum.Roles;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.Roles,
            Name = "「🔎」roles",
            Topic = "Permet de sélectionner ses propres rôles."
        };

        public List<SelectableRole> SelectableRoles;

        public RolesChannel()
        {
            SelectableRoles = RelfectionUtil<SelectableRole>.Load();
        }

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddImage("Channels/Roles/Notifications.jpg");

            List<IEmote> emotes = new List<IEmote>();
            Console.WriteLine("Loading " + SelectableRoles.Count + " selectable roles...");

            foreach (SelectableRole selectableRole in SelectableRoles)
            {
                Console.WriteLine("Adding Role : " + selectableRole.Name);
                messageContainer.AddEmbed(selectableRole.EmbedBuilder);
                emotes.Add(selectableRole.Emote);
            }

            messageContainer.AddText("Some text").AddEmoji(emotes);
        }
    }
}