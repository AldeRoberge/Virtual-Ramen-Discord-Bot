using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class AnnoncesRole : SelectableRole
    {
        public override string Name => "Annonces";
        public override IEmote Emote => new Emoji("📢");
        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Que ce soit mise à jour, recrutements, ou encore pleins d'autres annonces concernant l'actualité du serveur, tu ne ratera rien !**",
            Color = new Color(0, 253, 228),
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/767890329093275668.png?v=1"
        };
    }
}