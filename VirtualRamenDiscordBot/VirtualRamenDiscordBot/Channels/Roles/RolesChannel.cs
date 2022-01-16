using System;
using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Generators.Base;
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;
using VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base;
using VirtualRamenDiscordBot.Modules;

namespace VirtualRamenDiscordBot.Channels.Roles
{
    /// <summary>
    /// Generates the Role channel, which is responsible for generating the messages used to automatically assign roles to users based on emotes.
    /// </summary>
    public class RolesChannel : ChannelGenerator
    {
        public override ChannelsEnum ChannelsEnum => ChannelsEnum.Roles;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.Roles,
            Name = "「🔎」roles",
            Topic = "Permet de sélectionner ses propres rôles."
        };

        public List<SelectableRole> SelectableRoles;

        public RolesChannel()
        {
            SelectableRoles = RelfectionUtil<SelectableRole>.Load();
        }


        public override void PopulateMessages(MessageContainer messageContainer)
        {
            messageContainer.AddImage("Channels/Roles/Notifications.jpg");

            List<IEmote> emotes = new List<IEmote>();

            foreach (SelectableRole selectableRole in SelectableRoles)
            {
                Console.WriteLine("Adding Role : " + selectableRole.Name);
                messageContainer.AddEmbed(selectableRole.EmbedBuilder);
                emotes.Add(selectableRole.Emote);
            }

            // 2. Partenariat
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Partenariat",
                Description =
                    "**Reste aux courants des partenariats de Virtual Ramen!**",
                Color = Color.Blue,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/848108003547021333.png?v=1"
            });
            emotes.Add(new Emoji("👂"));

            // 3. Sondages
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Sondages",
                Description =
                    "**Votre avis est important ! Le staff sera parfois confronté à des choix des plus difficiles. Nous ferons donc appel à vous pour trancher.**",
                Color = Color.Blue,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/848108003547021333.png?v=1"
            });
            emotes.Add(new Emoji("👂"));

            // 4. Giveaways
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Giveaways",
                Description =
                    "**Virtual Ramen fait de nombreux cadeaux à sa communauté ! On compte sur vous pour ne rien rater !**",
                Color = Color.Purple,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/840957384394670111.png?v=1"
            });
            emotes.Add(new Emoji("🎁"));

            // 5. Fire Camps
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Fire Camps",
                Description =
                    "**Des moments chill seront organisés autour d'un Feu de Camp où chacun racontera des histoires afin de partager un bon moment entre amis.**",
                Color = Color.Red,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/846139999925698560.png?v=1"
            });
            emotes.Add(new Emoji("📅"));

            // 6. Événements
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Événements",
                Description =
                    "**Besoin de bouger ? Tu as besoin d'action ? On te propose régulièrement des événements de tout types (Jeux, Concours...). On vous attend !**",
                Color = Color.Orange,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/800625533074407444.gif?v=1"
            });
            emotes.Add(new Emoji("⚒"));

            // 7. Ateliers
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "Ateliers",
                Description =
                    "**Le serveurs organise des Ateliers pour les plus créatifs et avide de savoir ! Ces ateliers, présentent des projets, des cours et bien d'autres qui sont basés sur les spécialités du serveur !**",
                Color = Color.Green,
                ThumbnailUrl = "https://cdn.discordapp.com/emojis/848472015806660638.png?v=1"
            });
            emotes.Add(new Emoji("🔥"));
            messageContainer.AddText("Some text").AddEmoji(emotes);
        }
    }
}