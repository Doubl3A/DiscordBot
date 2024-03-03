using Core.Extensions;
using Core.Extensions.Interaction;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Core.Commands;

public class LavalinkSlashCommands : ApplicationCommandModule
{
    [SlashCommand("join", "Let me inn!")]
    public static async Task Join(InteractionContext context)
    {
        // Validate interaction for lavalink use
        var validInteraction = context.Validation()
            .CheckChannel(ChannelType.Voice)
            .CheckLavalinkConnection()
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            // Invalid request, respond with error message
            await context.SendChannelMessage(errorMessage);
            return;
        }

        // Get the current connected lavalink node
        context.TryGetLavaLink(out var lavalink);
        // var node = lavalink.GetConnectedNode();
        var node = lavalink.ConnectedNodes.Values.First();

        // Extract the user voice channel
        // var channel = context.GetInteractionVoiceChannel();
        var channel = context.Member.VoiceState.Channel;

        // Connect and respond to request
        await node.ConnectAsync(channel);
        await context.SendChannelMessage($"Joined {channel?.Name}!");
    }

    [SlashCommand("leave", "Ok then, keep your secrets 🤐")]
    public static async Task Leave(InteractionContext context)
    {
        // Validate interaction for lavalink use
        var validInteraction = context.Validation()
            .CheckChannel(ChannelType.Voice)
            .CheckLavalinkConnection()
            .CheckGuildConnection()
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            await context.SendChannelMessage(errorMessage);
            return;
        }

        // Current interaction channel
        var channel = context.GetInteractionVoiceChannel();

        // Get the current guild connection
        context.TryGetLavaLink(out var lavalink);
        var connection = lavalink.GetGuildConnection(channel?.Guild);

        // Disconnect and respond
        await connection.DisconnectAsync();
        await context.SendChannelMessage($"Left {channel?.Name}!");
    }

    [SlashCommand("play", "Provide a youtube URL, or search for a specific video")]
    public static async Task Play(InteractionContext context,
        [Option("query", "The url of the content you want to play")]
        string query)
    {
        // Validate user interaction
        var validInteraction = context.Validation()
            .CheckUserInput()
            .CheckMemberVoiceState()
            .CheckLavalinkConnection()
            .CheckGuildConnection()
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            await context.SendChannelMessage(errorMessage);
            return;
        }

        // Get the media at the provided URL
        context.TryGetLavaLink(out var lavalink);
        var loadResult = await lavalink.GetLoadedResult(query);
        if (loadResult == null)
        {
            await context.SendChannelMessage($"Failed to play \"{query}\".");
            return;
        }

        // Get current connection
        var connection = lavalink.GetGuildConnection(context.GetInteractionVoiceChannel()?.Guild);
        if (connection == null)
        {
            await context.SendChannelMessage("Failed to get current lavalink connection");
            return;
        }

        // Play track and send response
        var track = loadResult.Tracks.First();
        await connection.PlayAsync(track);
        await context.SendChannelMessage($"Now playing \"{track.Title}\"!");
    }

    [SlashCommand("pause", "Pause the currently running track.")]
    public static async Task Pause(InteractionContext context)
    {
        // Validate user interaction
        var validInteraction = context.Validation()
            .CheckMemberVoiceState()
            .CheckLavalinkConnection()
            .CheckGuildConnection()
            .CheckForTrack(context.GetInteractionVoiceChannel())
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            await context.SendChannelMessage(errorMessage);
            return;
        }

        // Get current connection
        context.TryGetLavaLink(out var lavalink);
        var connection = lavalink.GetGuildConnection(context.GetInteractionVoiceChannel()?.Guild);
        if (connection == null)
        {
            await context.SendChannelMessage("Failed to get current lavalink connection");
            return;
        }

        // Pause and send response
        await connection.PauseAsync();
        await context.SendChannelMessage("Paused currently running track");
    }

    [SlashCommand("resume", "Resume the currently running track.")]
    public static async Task Resume(InteractionContext context)
    {
        // Validate user interaction
        var validInteraction = context.Validation()
            .CheckMemberVoiceState()
            .CheckLavalinkConnection()
            .CheckGuildConnection()
            .CheckForTrack(context.GetInteractionVoiceChannel())
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            await context.SendChannelMessage(errorMessage);
            return;
        }

        // Get current connection
        context.TryGetLavaLink(out var lavalink);
        var connection = lavalink.GetGuildConnection(context.GetInteractionVoiceChannel()?.Guild);
        if (connection == null)
        {
            await context.SendChannelMessage("Failed to get current lavalink connection");
            return;
        }

        // Resume and send response
        await connection.ResumeAsync();
        await context.SendChannelMessage("Resumed currently running track");
    }
}