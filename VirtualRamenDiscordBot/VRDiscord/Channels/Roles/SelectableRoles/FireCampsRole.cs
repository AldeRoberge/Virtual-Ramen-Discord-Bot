using Discord;
using VRDiscord.Channels.Roles.SelectableRoles.Base;

namespace VRDiscord.Channels.Roles.SelectableRoles
{
    public class FireCampsRole : SelectableRole
    {
        public override string Name => "Fire Camps";
        public override IEmote Emote => new Emoji("📅");

        public override string Role => Name;
        
        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Des moments chill seront organisés autour d'un Feu de Camp où chacun racontera des histoires afin de partager un bon moment entre amis.**",
            Color = new Color(255,0,0),
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/846139999925698560.png?v=1"
        };
    }
}