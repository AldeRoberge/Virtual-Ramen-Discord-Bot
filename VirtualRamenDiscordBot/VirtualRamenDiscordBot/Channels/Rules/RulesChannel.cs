using System.Collections.Generic;
using Discord;
using VirtualRamenDiscordBot.Channels.Base;
using VirtualRamenDiscordBot.Channels.Base.Messages.Base;
using VirtualRamenDiscordBot.Utils;

namespace VirtualRamenDiscordBot.Channels.Rules
{
    public class Rule
    {
        public string Description { get; set; }

        public Rule(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Generates the Welcome channel, which invites user to read the rules and participate in the server.
    /// </summary>
    public class RulesChannel : ChannelGenerator
    {
        public override Channel Channel => new()
        {
            Id = ChannelConstants.Rules,
            Name = "「📃」règlements",
            Topic = "La liste des règles du serveur",
            ChannelsEnum = ChannelsEnum.Rules
        };

        public List<Rule> Rules = new()
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
            messageContainer.AddImage("Channels/Rules/Rules.png");

            var colors = GradientGenerator.GetColors(Color.Green, Color.Blue, Rules.Count);

            for (int i = 0; i < Rules.Count; i++)
            {
                // Gets the rule
                var rule = Rules[i];

                messageContainer.AddEmbed(new EmbedBuilder
                {
                    Title = "Article " + (i + 1),
                    Description = rule.Description,
                    Color = colors[i]
                });
            }

        }
    }
}