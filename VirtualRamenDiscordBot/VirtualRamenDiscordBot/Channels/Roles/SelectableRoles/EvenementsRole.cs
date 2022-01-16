using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class EvenementsRole : SelectableRole
    {
        public override string Name => "Événements";
        public override IEmote Emote => new Emoji("⚒");

        public override string Role => Name;
        
        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Besoin de bouger ? Tu as besoin d'action ? On te propose régulièrement des événements de tout types (Jeux, Concours...). On vous attend !**",
            Color = Color.Orange,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/800625533074407444.gif?v=1"
        };
    }
}