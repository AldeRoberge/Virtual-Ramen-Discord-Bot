using Discord;
using VRDiscord.Channels.Roles.SelectableRoles.Base;

namespace VRDiscord.Channels.Roles.SelectableRoles
{
    public class GiveAwayRole : SelectableRole
    {
        public override string Name => "Giveaways";
        public override IEmote Emote => new Emoji("🎁");

        public override string Role => Name;
        
        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Virtual Ramen fait de nombreux cadeaux à sa communauté ! On compte sur vous pour ne rien rater !**",
            Color = Color.Purple,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/840957384394670111.png?v=1"
        };
    }
}