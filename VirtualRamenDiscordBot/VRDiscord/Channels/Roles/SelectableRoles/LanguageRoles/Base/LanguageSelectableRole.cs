using Discord;
using VRDiscord.Channels.Roles.SelectableRoles.Base;

namespace VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles.Base
{
    public abstract class LanguageSelectableRole : SelectableRole
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