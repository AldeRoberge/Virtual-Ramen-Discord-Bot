using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Channels.Welcome.Core;

namespace VRDiscord.Channels.Welcome
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class FR_WelcomeChannel : WelcomeChannel
    {
        public override bool DeleteAllMessages => true;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.FR_Welcome,
            Name = "『👋』𝗕𝗶𝗲𝗻𝘃𝗲𝗻𝘂𝗲",
            Topic = "Bienvenue sur le serveur de Virtual Ramen",
            Channels = Channels.Welcome
        };

        public override List<Website> Websites => new()
        {
            // Discord
            new Website("https://discord.io/virtualramen", "Discord",
                "Discord",
                "Envois le lien du serveur Discord à tes amis pour les inviter à nous rejoindre dans cette aventure!"),

            // Site web
            new Website("http://virtualramen.ca/", "Site web",
                "Star",
                "Le site web recceuil plus d'information sur l'équipe derrière le projet!"),

            // Instagram
            new Website("https://www.instagram.com/virtualramengames/?hl=fr", "Instagram",
                "Instagram",
                "Tu pourras trouver sur Instagram des images du projet et de l'équipe derrière les rideaux!"),

            // YouTube
            new Website("https://www.youtube.com/channel/UCVSJlKgm1HTWaTCRmqMPJVw", "YouTube",
                "YouTube",
                "Tu pourras trouver sur YouTube des vidéos souvent plus long que ceux trouvé sur TikTok et Instagram!"),

            // Facebook
            new Website("https://www.facebook.com/virtualramengames/", "Facebook",
                "Facebook",
                "Sur Facebook, nous partageons nos réalisations et nous entretennons un groupe Facebook pour les beta testeurs."),

            // Twitch
            new Website("https://twitch.tv/virtualramengames", "Twitch",
                "Twitch",
                "Nous présentons LIVE devant public, viens voir notre prochaine présentation!"),

            // TikTok
            new Website("https://vm.tiktok.com/ZM8TkD9sQ/ ", "TikTok",
                "TikTok",
                "Tu pourras trouver sur TikTok des courtes vidéos du projet!"),
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");

            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Bienvenue sur le serveur de Virtual Ramen!",
                Description = "Viens jouer à notre premier jeu : Mother's Voice.",
                Color = new Color(255, 0, 0)
            });

            base.PopulateMessages(messageContainer);

            messageContainer.AddSeparator();

            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Va voir les règles!",
                Description = "<#" + ChannelConstants.FR_Rules + ">",
                Color = new Color(255, 0, 0)
            });
        }
    }
}