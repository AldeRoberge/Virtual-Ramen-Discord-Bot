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
    public class EN_WelcomeChannel : WelcomeChannel
    {
        public override bool DeleteAllMessages => true;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.EN_Welcome,
            Name = "『👋』𝗪𝗲𝗹𝗰𝗼𝗺𝗲",
            Topic = "Welcome to the Virtual Ramen Discord Server!",
            ChannelsEnum = ChannelsEnum.Welcome
        };

        public override List<Website> Websites => new()
        {
            // Discord
            new Website("https://discord.io/virtualramen", "Discord",
                "https://drive.google.com/uc?id=1eAPU6hIiVAUA6sAcZZ7sGUA8cOcEf5fV",
                "Send the Discord server link to your friends to invite them to join us on this adventure!"),

            // Site web
            new Website("http://virtualramen.ca/", "Site web",
                "https://drive.google.com/uc?id=1mPiUbrjnabfZlJj8aEgSVDWdupP8npxh",
                "The website contains more information about the team behind the project!"),

            // Instagram
            new Website("https://www.instagram.com/virtualramengames/?hl=fr", "Instagram",
                "https://drive.google.com/uc?id=16ZWg_pEwc4fUenG0F4--Nwr9b2Y7NJSY",
                "You can find pictures of the project and the team behind the curtains on Instagram!"),

            // YouTube
            new Website("https://www.youtube.com/channel/UCVSJlKgm1HTWaTCRmqMPJVw", "YouTube",
                "https://drive.google.com/uc?id=1RLEvVtwbD-w8GRH-84YXGtZPVWmM_Q52",
                "You can find videos on YouTube that are often longer than those found on TikTok and Instagram!"),

            // Facebook
            new Website("https://www.facebook.com/virtualramengames/", "Facebook",
                "https://drive.google.com/uc?id=1ul7D3Gzxb4J4OuAyPjZ64XYwOAbwsTVr",
                "On Facebook, we share our achievements and we maintain a Facebook group for beta testers."),

            // Twitch
            new Website("https://twitch.tv/virtualramengames", "Twitch",
                "https://drive.google.com/uc?id=19vBfK6Ccz9ZcaRGpBhroAOU8V20e9DiA",
                "We are presenting LIVE in front of the public, come see our next presentation!"),

            // TikTok
            new Website("https://vm.tiktok.com/ZM8TkD9sQ/ ", "TikTok",
                "https://drive.google.com/uc?id=1HsswilbzjhIw2Zh5p0eiY2wEnAeuxOrB",
                "You can find short videos of the project on TikTok!"),
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");
            
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Welcome to the Virtual Ramen Discord Server!",
                Description = "Come play our first game : Mother's Voice.",
                Color = new Color(255, 0, 0)
            });

            base.PopulateMessages(messageContainer);
            
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Head over to the rules channel to see the rules!",
                Description = "<#" + ChannelConstants.EN_Rules + ">",
                Color = new Color(255, 0, 0)
            });
        }
    }
}