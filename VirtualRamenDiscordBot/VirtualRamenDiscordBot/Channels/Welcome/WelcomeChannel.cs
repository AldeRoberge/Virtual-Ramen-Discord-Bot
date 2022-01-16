using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Base;
using VirtualRamenDiscordBot.Channels.Base.Messages;
using VirtualRamenDiscordBot.Channels.Base.Messages.Base;
using VirtualRamenDiscordBot.Utils;


namespace VirtualRamenDiscordBot.Channels.Welcome
{
    public class Website
    {
        public Color Color;
        public string URL;
        public string Name;
        public string ThumbnailURL;
        public string Description;

        public Website(Color color, string url, string name, string thumbnailUrl, string description)
        {
            Color = color;
            URL = url;
            Name = name;
            ThumbnailURL = thumbnailUrl;
            Description = description;
        }
    }
}

namespace VirtualRamenDiscordBot.Channels.Welcome
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class WelcomeChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Welcome,
            Name = "「💬」bienvenue",
            Topic = "Allows for some welcome messages to be sent to new members.",
            ChannelsEnum = ChannelsEnum.Welcome
        };

        public List<Website> Websites = new()
        {
            // Discord
            new Website(new Color(0x5865F2), "https://discord.io/virtualramen", "Discord",
                "https://drive.google.com/uc?id=1eAPU6hIiVAUA6sAcZZ7sGUA8cOcEf5fV",
                "Envois le lien du serveur Discord à tes amis pour les inviter à nous rejoindre dans cette aventure!"),

            // Site web
            new Website(new Color(0xD8D8D8), "http://virtualramen.ca/", "Site web",
                "https://drive.google.com/uc?id=1mPiUbrjnabfZlJj8aEgSVDWdupP8npxh",
                "Le site web recceuil plus d'information sur l'équipe derrière le projet!"),

            // Instagram
            new Website(new Color(0xC632AF), "https://www.instagram.com/virtualramengames/?hl=fr", "Instagram",
                "https://drive.google.com/uc?id=16ZWg_pEwc4fUenG0F4--Nwr9b2Y7NJSY",
                "Tu pourras trouver sur Instagram des images du projet et de l'équipe derrière les rideaux!"),

            // YouTube
            new Website(new Color(0xFE0000), "https://www.youtube.com/channel/UCVSJlKgm1HTWaTCRmqMPJVw", "YouTube",
                "https://drive.google.com/uc?id=1RLEvVtwbD-w8GRH-84YXGtZPVWmM_Q52",
                "Tu pourras trouver sur YouTube des vidéos souvent plus long que ceux trouvé sur TikTok et Instagram!"),

            // Facebook
            new Website(new Color(0x1877F2), "https://www.facebook.com/virtualramengames/", "Facebook",
                "https://drive.google.com/uc?id=1ul7D3Gzxb4J4OuAyPjZ64XYwOAbwsTVr",
                "Sur Facebook, nous partageons nos réalisations et nous entretennons un groupe Facebook pour les beta testeurs."),

            // Twitch
            new Website(new Color(0x9147FF), "https://twitch.tv/virtualramengames", "Twitch",
                "https://drive.google.com/uc?id=19vBfK6Ccz9ZcaRGpBhroAOU8V20e9DiA",
                "Nous présentons LIVE devant public, viens voir notre prochaine présentation!"),

            // TikTok
            new Website(new Color(0x00F2EA), "https://vm.tiktok.com/ZM8TkD9sQ/ ", "TikTok",
                "https://drive.google.com/uc?id=1HsswilbzjhIw2Zh5p0eiY2wEnAeuxOrB",
                "Tu pourras trouver sur TikTok des courtes vidéos du projet!"),
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");

            List<Color> colors = GradientGenerator.GetRainbowGradient(Websites.Count);

            int i = 0;

            foreach (Website website in Websites)
            {
                messageContainer.AddEmbed(new EmbedBuilder
                {
                    Title = website.Name,
                    Description = website.URL,
                    Fields = new List<EmbedFieldBuilder>()
                    {
                        new()
                        {
                            Name = "Description",
                            Value = website.Description,
                            IsInline = false
                        }
                    },
                    Color = colors[i],
                    // Make sure its not null
                    ThumbnailUrl = website.ThumbnailURL
                });

                i++;
            }
            
            messageContainer.AddMessage(
                new TextMessage("Va maintenant voir <#905837427321634846> pour être admis dans le serveur."));
        }
    }
}