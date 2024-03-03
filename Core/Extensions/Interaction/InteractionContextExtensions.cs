using Core.Collections;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;

namespace Core.Extensions.Interaction;

public static class InteractionContextExtensions
{
    /// <summary>
    ///     Get the the current voice channel a user made the interaction from.
    /// </summary>
    /// <param name="context">The interaction context</param>
    /// <returns>Returns the current channel the user is in</returns>
    /// <remarks>
    ///     Returns <b>Null</b> when the user isn't in a channel
    /// </remarks>
    public static DiscordChannel? GetInteractionVoiceChannel(this InteractionContext context)
    {
        DiscordChannel? channel;
        try
        {
            channel = context.Member.VoiceState.Channel;
        }
        catch (NullReferenceException)
        {
            // If a user isn't in a voice channel
            channel = null;
        }

        return channel;
    }

    /// <summary>
    ///     Try to get the <see cref="LavalinkExtension" /> on the current context
    /// </summary>
    /// <param name="context">The current interaction context</param>
    /// <param name="lavaLink">The fetched <see cref="LavalinkExtension" /></param>
    /// <returns>The result of the LavaLink connection check</returns>
    public static bool TryGetLavaLink(this InteractionContext context,
        out LavalinkExtension lavaLink)
    {
        // Fetch LavaLink
        lavaLink = context.Client.GetLavalink();
        // And check for a connection
        return lavaLink.ConnectedNodes.Any();
    }

    /// <summary>
    ///     Start a new validation for this interaction context
    /// </summary>
    /// <param name="context">The context to validate</param>
    /// <returns>Returns the <see cref="InteractionValidationCollection" /> used to validate this context</returns>
    public static InteractionValidationCollection Validation(this InteractionContext context)
    {
        var temp = new InteractionValidationCollection(context);
        return temp;
    }
}