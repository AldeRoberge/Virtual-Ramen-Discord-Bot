using Discord;
using VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles.Base;

namespace VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles
{
    public class FrenchSelectableRole : LanguageSelectableRole
    {
        public override string Name => "Français";
        public override IEmote Emote => new Emoji("🇫🇷");
        
        public override string Role => Name;

        public override string LocalizedDescription =>
            "Utilise l'emoji en dessous pour être admis en tant que membre francophone du serveur";

        public override string ImageURL => "https://drive.google.com/uc?id=1xbB_JTOWFeuVhMD1VpvYyN_j-ByYTXjR";
    }
}