using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Figgle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VRDiscord
{
    /// <summary>
    /// Launches the bot.
    /// Based on Discord.NET's 'interaction' example.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // One of the more flexable ways to access the configuration data is to use the Microsoft's Configuration model,
            // this way we can avoid hard coding the environment secrets. I opted to use the Json and environment variable providers here.
            IConfiguration config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "DC_")
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            RunAsync(config).GetAwaiter().GetResult();
        }

        static async Task RunAsync(IConfiguration configuration)
        {
            Console.WriteLine("Is Debug : " + IsDebug());

            // Dependency injection is a key part of the Interactions framework but it needs to be disposed at the end of the app's lifetime.
            using var services = ConfigureServices(configuration);

            var client = services.GetRequiredService<DiscordAPI>();
            var commands = services.GetRequiredService<InteractionService>();

            client.Log += LogAsync;
            commands.Log += LogAsync;

            // Slash Commands and Context Commands are can be automatically registered, but this process needs to happen after the client enters the READY state.
            // Since Global Commands take around 1 hour to register, we should use a test guild to instantly update and test our commands. To determine the method we should
            // register the commands with, we can check whether we are in a DEBUG environment and if we are, we can register the commands to a predetermined test guild.
            client.Ready += async () =>
            {
                if (IsDebug())
                {
                    // Id of the test guild can be provided from the Configuration object
                    await commands.RegisterCommandsToGuildAsync(configuration.GetValue<ulong>("testGuild"), true);

                    // Download all of the members of the guild
                    await client.GetGuild().DownloadUsersAsync();
                }
                else
                    await commands.RegisterCommandsGloballyAsync(true);
            };

            // Here we can initialize the service that will register and execute our commands
            await services.GetRequiredService<CommandHandler>().InitializeAsync();


            // Bot token can be provided from the Configuration object we set up earlier

            if (IsDebug())
            {
                Console.WriteLine(FiggleFonts.Standard.Render("We're runnin' on DEBUG!"));
                await client.LoginAsync(TokenType.Bot, configuration["token_dev"]);
            }
            else
            {
                await client.LoginAsync(TokenType.Bot, configuration["token_prod"]);
            }


            await client.StartAsync();


            await Task.Delay(Timeout.Infinite);
        }


        static Task LogAsync(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }


        static ServiceProvider ConfigureServices(IConfiguration configuration)
        {
            return new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton(x => new DiscordAPI(new DiscordSocketConfig()
                {
                    // Sets the members intent
                    AlwaysDownloadUsers = true,
                    MessageCacheSize = 50,
                    LogLevel = LogSeverity.Info,
                    GatewayIntents = GatewayIntents.All
                }))
                .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordAPI>()))
                .AddSingleton<CommandHandler>()
                .BuildServiceProvider();
        }

        static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}