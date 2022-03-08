using System.Collections.Generic;
using Discord;
using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;
using VRDiscord.Channels.Rules.Core;

namespace VRDiscord.Channels.Rules
{
    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class FR_RulesChannel : RulesChannel
    {
        public override bool DeleteAllMessages => true;

        public override Channel Channel => new()
        {
            Id = ChannelConstants.FR_Rules,
            Name = "『📚』𝗥è𝗴𝗹𝗲𝗺𝗲𝗻𝘁𝘀",
            Topic = "La liste des règles du serveur.",
            ChannelsEnum = ChannelsEnum.Rules
        };

        public override List<Rule> Rules => new()
        {
            new Rule(
                "Le respect de l'utilité de chaque salon textuel ou vocal est primordial, si la fonction d'un channel n'est pas respecté l'équipe de modération se garde le droit de vous sanctionner."),
            new Rule(
                "Votre pseudo se doit d'être alphanumérique. S'il porte atteinte au respect d'autrui ou n'est pas mentionnable, une sanction ou un changement de pseudo aura lieu."),
            new Rule(
                "Tout conflit inter-communautaire se doit d'être dénoncé via le service support. Si le conflit se déroule dans un channel non dédié à cela, nous nous gardons le droit de sanctionner peut importe le fautif."),
            new Rule(
                "Toute insulte, provocation, menaces, spam et comportement homophobe, raciste, sexuel, toxique et/ou portant atteinte à l'intégrité d'une personne ou d'une communauté seront sanctionnés. Même si le comportement ne parait pas gênant, si quiconque s'en plaint, une sanction se verra attribuée."),
            new Rule(
                "En cas d'injustice de la part d'un membre du staff, veuillez contacter en message privé un membre de l'administration et non dans un des salons du serveur."),
            new Rule(
                "Les utilisateurs faisant de la publicité en message privé ou sur le serveur sans autorisation seront systématiquement bannis."),
            new Rule(
                "Aucun emoji vulgaire, insultant ou discriminatoire n'est toléré. De même pour votre photo de profil ainsi que votre pseudo."),
            new Rule(
                "Les mentions everyone et here sont strictement réservées aux membres du staff. L'abus de mentions est également interdit."),
            new Rule(
                "Tout ticket non justifié sera sanctionné : chaque nouveau ticket génère une notification chez tous les membres du staff du ticket."),
            new Rule(
                "Toute tentative de contournement des règles amènera à minima un doublement de la sanction de base."),
        };


        public override void PopulateMessages(MessageContainer messageContainer)
        {
            // Add the welcome image
            messageContainer.AddImage("Channels/Welcome/Welcome.png");

            base.PopulateMessages(messageContainer);
            
            messageContainer.AddSeparator();
            
            messageContainer.AddEmbed(new EmbedBuilder
            {
                Title = "J'accèpte les règements",
                Description =
                    "Dès lors que vous interagissez avec notre contenu vous déclarez avoir **lu, compris et accepté** les règlements. **Vous ne pouvez pas prétendre de ne pas le connaître.**",
                Color = new Color(0xFF0000),
                // Make sure its not null
                ThumbnailUrl = "https://drive.google.com/uc?id=1xbB_JTOWFeuVhMD1VpvYyN_j-ByYTXjR"
            }).AddEmoji("🩸");
        }
    }
}