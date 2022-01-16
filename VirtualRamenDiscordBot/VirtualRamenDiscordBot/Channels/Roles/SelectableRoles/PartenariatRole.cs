using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class PartenariatRole : SelectableRole
    {
        public override string Name => "Partenariat";
        public override IEmote Emote => new Emoji("📢");

        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Reste aux courants des partenariats de Virtual Ramen!**",
            Color = Color.Blue,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/848108003547021333.png?v=1"
        };
    }
}