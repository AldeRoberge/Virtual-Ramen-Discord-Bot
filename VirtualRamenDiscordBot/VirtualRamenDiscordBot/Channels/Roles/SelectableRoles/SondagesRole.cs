using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class SondagesRole : SelectableRole
    {
        public override string Name => "Sondages";
        public override IEmote Emote => new Emoji("👂");

        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Votre avis est important ! Le staff sera parfois confronté à des choix des plus difficiles. Nous ferons donc appel à vous pour trancher.**",
            Color = Color.Blue,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/848108003547021333.png?v=1"
        };
    }
}