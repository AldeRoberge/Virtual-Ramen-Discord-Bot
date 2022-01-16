using Discord;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles
{
    public class FireCampsRole : SelectableRole
    {
        public override string Name =>  "Fire Camps";
        public override IEmote Emote => new Emoji("📅");
        public override EmbedBuilder EmbedBuilder => new()
        {
            Title = Name,
            Description =
                "**Des moments chill seront organisés autour d'un Feu de Camp où chacun racontera des histoires afin de partager un bon moment entre amis.**",
            Color = Color.Red,
            ThumbnailUrl = "https://cdn.discordapp.com/emojis/846139999925698560.png?v=1"
        };
        
 
    }
}