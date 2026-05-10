using Core.Extensions.Interaction;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Core.Commands;

public class GeneralCommands : ApplicationCommandModule
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
}