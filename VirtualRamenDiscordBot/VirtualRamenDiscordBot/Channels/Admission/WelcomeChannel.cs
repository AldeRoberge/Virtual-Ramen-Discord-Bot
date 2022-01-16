using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Generators.Base;
using VirtualRamenDiscordBot.Channels.Generators.Messages;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;
using VirtualRamenDiscordBot.Utils;


namespace VirtualRamenDiscordBot.Channels.Welcome
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class AdmissionChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Admission,
            Name = "「📃」admission",
            Topic = "Accepter les conditions.",
            ChannelsEnum = ChannelsEnum.Admission
        };


        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");

            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "J'accèpte les règements",
                Description =
                    "Dès lors que vous interagissez avec notre contenu vous déclarez avoir **lu, compris et accepté** les <#905837427321634846>. **Vous ne pouvez pas prétendre de ne pas le connaître.**",
                Color = new Color(0xFF0000),
                // Make sure its not null
                ThumbnailUrl = "https://drive.google.com/uc?id=1xbB_JTOWFeuVhMD1VpvYyN_j-ByYTXjR"
            });


            
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "I accept the rules",
                Description =
                    "As soon as you interact with our content, you declare that you have **read, understood and accepted** the rules (<#905837427321634846>). **You can't pretend not to know them**.",
                Color = new Color(0xFF0000),
                // Make sure its not null
                ThumbnailUrl = "https://drive.google.com/uc?id=14Q_J2kiZOKyE_Lc6mXyDEFwXs7O5CURc"
            });

            messageContainer.AddText("Réagir pour accepter : ").AddEmoji("🩸");
        }
    }
}