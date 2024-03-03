using System.Reflection;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;
using DSharpPlus.SlashCommands;

namespace Core;

public class DiscordBot
{
    private readonly DiscordClient _client;
    private CommandsNextExtension? _commandsNext;
    private LavalinkConfiguration? _lavalinkConfiguration;
    private LavalinkExtension? _lavalinkExtension;
    private SlashCommandsExtension? _slashCommandsExtension;

    /// <summary>
    ///     Create a new discord bot
    /// </summary>
    public DiscordBot()
    {
        _client = ClientInit();
    }

    /// <summary>
    ///     Initialize the discord client connection
    /// </summary>
    /// <param name="config">An optional <see cref="DiscordConfiguration" /> to configure the discord client</param>
    /// <returns>A prepared <see cref="DiscordClient" /></returns>
    private static DiscordClient ClientInit(DiscordConfiguration? config = null)
    {
        if (config == null)
            config = new DiscordConfiguration
            {
                // TODO - TODO - migrate to appsettings/env
                Token = "app_token",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };

        return new DiscordClient(config);
    }

    /// <summary>
    ///     Initialize the <see cref="DiscordClient" /> to use <see cref="CommandsNextExtension" />
    /// </summary>
    /// <param name="prefix">The commands next prefix</param>
    public void UseCommandsNext(string prefix = "!")
    {
        _commandsNext = _client.UseCommandsNext(new CommandsNextConfiguration(new CommandsNextConfiguration
        {
            StringPrefixes = new[] { prefix }
        }));
    }

    /// <summary>
    ///     Initialise the <see cref="DiscordClient" /> to use slash commands
    /// </summary>
    public void UseSlashCommands()
    {
        _slashCommandsExtension = _client.UseSlashCommands(new SlashCommandsConfiguration());
    }

    /// <summary>
    ///     Add a lavalink connection to the discord bot
    /// </summary>
    public void AddLavalink()
    {
        var endpoint = new ConnectionEndpoint
        {
            Hostname = "127.0.0.1", // TODO - move to config (From your server configuration)
            Port = 2333 // TODO - move to config (From your server configuration)
        };

        _lavalinkConfiguration = new LavalinkConfiguration
        {
            Password = "youshallnotpass", // TODO - move to config (From your server configuration)
            RestEndpoint = endpoint,
            SocketEndpoint = endpoint
        };

        _lavalinkExtension = _client.UseLavalink();
    }

    /// <summary>
    ///     Start and run the discord bot with the current configuration
    /// </summary>
    public async Task Run()
    {
        await _client.ConnectAsync();

        // Add CommandsNext
        if (_commandsNext != null)
            _commandsNext.RegisterCommands(Assembly.GetExecutingAssembly());

        // Add slash commands
        if (_slashCommandsExtension != null)
            _slashCommandsExtension.RegisterCommands(Assembly.GetExecutingAssembly());

        // Add the lavalink connection
        if (_lavalinkConfiguration != null && _lavalinkExtension != null)
            // Make sure this is after Discord.ConnectAsync().
            await _lavalinkExtension.ConnectAsync(_lavalinkConfiguration);

        await Task.Delay(-1);
    }
}