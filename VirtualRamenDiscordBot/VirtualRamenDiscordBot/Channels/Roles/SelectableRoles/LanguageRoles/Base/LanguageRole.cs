using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.LanguageRoles.Base
{
    public abstract class LanguageRole : SelectableRole
    {
        public abstract string LocalizedDescription { get; }

        public abstract string ImageURL { get; }

        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**" + LocalizedDescription + "**",
            Color = new Color(255, 0, 0),
            ThumbnailUrl = ImageURL
        };
    }
}