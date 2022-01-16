using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class AteliersRole : SelectableRole
    {
        public override string Name => "Ateliers";
        public override IEmote Emote => new Emoji("🔥");

        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Le serveur organise des Ateliers pour les plus créatifs et avide de savoir ! Ces ateliers, présentent des projets, des cours et bien d'autres qui sont basés sur les spécialités du serveur !**",
            Color = Color.Green,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/848472015806660638.png?v=1"
        };
    }
}