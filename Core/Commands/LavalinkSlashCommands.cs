using Core.Extensions;
using Core.Extensions.Interaction;
using DSharpPlus;
using DSharpPlus.Lavalink;
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

    // [SlashCommand("play", "Do a search on youtube for a specific track, and the most relevant result will be played.")]
    // public async Task Play(InteractionContext ctx, [Option("query", "query")] string search)
    // {
    //     // Do a global search with the user input
    //
    //     //Important to check the voice state itself first, 
    //     //as it may throw a NullReferenceException if they don't have a voice state.
    //     if (ctx.Member?.VoiceState == null || ctx.Member.VoiceState.Channel == null)
    //     {
    //         await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
    //             new DiscordInteractionResponseBuilder().WithContent("You are not in a voice channel."));
    //         return;
    //     }
    //
    //     var lava = ctx.Client.GetLavalink();
    //     var node = lava.ConnectedNodes.Values.First();
    //     var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);
    //
    //     if (conn == null)
    //     {
    //         await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
    //             new DiscordInteractionResponseBuilder().WithContent("Lavalink is not connected."));
    //         return;
    //     }
    //
    //     //We don't need to specify the search type here
    //     //since it is YouTube by default.
    //     var loadResult = await node.Rest.GetTracksAsync(search);
    //
    //     //If something went wrong on Lavalink's end                          
    //     if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed
    //         //or it just couldn't find anything.
    //         || loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
    //     {
    //         await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
    //             new DiscordInteractionResponseBuilder().WithContent($"Track search failed for {search}."));
    //         return;
    //     }
    //
    //     var track = loadResult.Tracks.First();
    //
    //     await conn.PlayAsync(track);
    //
    //     await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
    //         new DiscordInteractionResponseBuilder().WithContent($"Now playing {track.Title}!"));
    // }

    [SlashCommand("play", "Provide a url, and I'll play that track for you 👍")]
    public static async Task Play(InteractionContext context,
        [Option("url", "The url of the content you want to play")]
        string url)
    {
        // Validate user interaction
        var validInteraction = context.Validation()
            .CheckMemberVoiceState()
            .CheckLavalinkConnection()
            .CheckGuildConnection()
            .Validate(out var errorMessage);
        if (!validInteraction)
        {
            await context.SendChannelMessage(errorMessage);
            return;
        }

        var lavalink = context.Client.GetLavalink();
        var node = lavalink.GetConnectedNode();

        // We don't need to specify the search type here
        // since it is YouTube by default.
        var loadResult = await node.Rest.GetTracksAsync(url);

        // If something went wrong on Lavalink's end                          
        if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed
            // or it just couldn't find anything.
            || loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
        {
            await context.SendChannelMessage($"Failed to play the URL: {url}.");
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
        await context.SendChannelMessage($"Now playing {track.Title}!");
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