using Discord;
using VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles.Base;

namespace VRDiscord.Channels.Roles.SelectableRoles.LanguageRoles
{
    public class EnglishRole : LanguageRole
    {
        public override string Name => "English";
        public override IEmote Emote => new Emoji("🇺🇸");
        
        public override string Role => Name;
        
        public override string LocalizedDescription =>
            "Use this role to get admitted to all of the English language sections.";

        public override string ImageURL => "https://drive.google.com/uc?id=14Q_J2kiZOKyE_Lc6mXyDEFwXs7O5CURc";
    }
}