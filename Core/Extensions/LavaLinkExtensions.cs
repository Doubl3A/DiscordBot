using DSharpPlus.Entities;
using DSharpPlus.Lavalink;

namespace Core.Extensions;

public static class LavaLinkExtensions
{
    /// <summary>
    ///     Get the lavalink connection
    /// </summary>
    /// <param name="lavalink">The lavalink instance to extract the connection from</param>
    /// <exception cref="InvalidOperationException">If the lavalink connection is empty</exception>
    /// <returns>The first lavalink connection</returns>
    public static LavalinkNodeConnection GetConnectedNode(this LavalinkExtension lavalink)
    {
        return lavalink.ConnectedNodes.Values.First();
    }

    /// <summary>
    ///     Get the current lavalink connection
    /// </summary>
    /// <param name="lavalink">The lavalink instance to check for a connection on</param>
    /// <param name="channel">The channel the lavalink instance should be in</param>
    /// <returns>A <see cref="LavalinkGuildConnection" />, or <b>Null</b> if no if there is no connection</returns>
    public static LavalinkGuildConnection? GetCurrentConnection(this LavalinkExtension lavalink,
        DiscordChannel? channel)
    {
        LavalinkGuildConnection? connection;
        try
        {
            connection = lavalink.GetConnectedNode().GetGuildConnection(channel?.Guild);
        }
        catch
        {
            connection = null;
        }

        return connection;
    }
}