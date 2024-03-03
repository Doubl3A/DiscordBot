using Core.Extensions;
using Core.Extensions.Interaction;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace Core.Collections;

public class InteractionValidationCollection
{
    private readonly InteractionContext _context;
    private string _message = string.Empty;
    private bool _valid = true;

    public InteractionValidationCollection(InteractionContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get the results of the current interaction validation
    /// </summary>
    /// <param name="message">Error message provided if the validation fails</param>
    /// <returns>The result of the validation</returns>
    public bool Validate(out string message)
    {
        // Return the results of this validation
        message = _message;
        return _valid;
    }

    /// <summary>
    ///     Check if the user channel is the right type for this interaction
    /// </summary>
    /// <param name="channelType">The required channel type</param>
    /// <returns>The result of the <paramref name="channelType" /> and user channel type comparison</returns>
    public InteractionValidationCollection CheckChannel(ChannelType channelType)
    {
        if (SkipValidation())
            // Previous method failed, skipping this validation
            return this;

        var channel = _context.GetInteractionVoiceChannel();
        if (channel?.Type != channelType)
        {
            _message = "Not in a valid voice channel";
            _valid = false;
        }

        return this;
    }

    /// <summary>
    ///     Checks for a lavalink connection
    /// </summary>
    /// <returns>The result of the lavalink connection check</returns>
    public InteractionValidationCollection CheckLavalinkConnection()
    {
        if (SkipValidation())
            // Previous method failed, skipping this validation
            return this;

        // Validate that lavalink is up and running
        var hasConnection = _context.TryGetLavaLink(out _);
        if (!hasConnection)
        {
            // No LavaLink connection exists
            _message = "The LavaLink connection is not established";
            _valid = false;
        }

        return this;
    }

    /// <summary>
    ///     Check if the app is in a voice channel
    /// </summary>
    /// <returns>The result of the app location check</returns>
    public InteractionValidationCollection CheckGuildConnection()
    {
        if (SkipValidation())
            // Previous method failed, skipping this validation
            return this;

        // Validate current connection
        _context.TryGetLavaLink(out var lavalink);
        var connection = lavalink.GetCurrentConnection(_context.GetInteractionVoiceChannel());
        if (connection == null)
        {
            _message = "No voice connection found";
            _valid = false;
        }

        return this;
    }

    /// <summary>
    ///     Check that the interacting user is in a voice channel
    /// </summary>
    /// <returns>The result of the user voice channel check</returns>
    public InteractionValidationCollection CheckMemberVoiceState()
    {
        if (SkipValidation())
            // Previous method failed, skipping this validation
            return this;

        if (_context.Member.VoiceState == null || _context.Member.VoiceState.Channel == null)
        {
            _message = "You are not in a voice channel.";
            _valid = false;
        }

        return this;
    }

    /// <summary>
    ///     Check that a track is loaded into the player
    /// </summary>
    /// <param name="channel">The current voice channel</param>
    /// <returns>The result of the track check</returns>
    public InteractionValidationCollection CheckForTrack(DiscordChannel? channel)
    {
        if (SkipValidation())
            // Previous method failed, skipping this validation
            return this;

        _context.TryGetLavaLink(out var lavaLink);
        var connection = lavaLink.GetCurrentConnection(channel);
        if (connection?.CurrentState.CurrentTrack == null)
        {
            _message = "There are no tracks loaded.";
            _valid = false;
        }

        return this;
    }

    /// <summary>
    ///     Used to skip a validation step if a previous validation has failed
    /// </summary>
    private bool SkipValidation()
    {
        return !_valid;
    }
}