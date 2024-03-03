using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace Core.Extensions.Interaction;

public static class MessageExtensions
{
    /// <summary>
    ///     Send a default Interaction message as a response
    /// </summary>
    /// <param name="context">The current interaction context</param>
    /// <param name="message">The message to respond with</param>
    public static async Task SendChannelMessage(this InteractionContext context, string message)
    {
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder().WithContent(message));
    }
}