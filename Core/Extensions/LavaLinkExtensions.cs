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

    /// <summary>
    ///     Get the loaded media with the provided <paramref name="media" />
    /// </summary>
    /// <param name="lavalink">The lavalink instance to load the media</param>
    /// <param name="media">The media query</param>
    /// <returns>The loaded media</returns>
    /// <remarks>
    ///     Works with both URLs and queries (as in search)
    ///     Returns <b>Null</b> if an error occured while loading the media
    /// </remarks>
    public static async Task<LavalinkLoadResult?> GetLoadedResult(this LavalinkExtension lavalink, string media)
    {
        //We don't need to specify the search type here
        //since it is YouTube by default.
        var node = lavalink.GetConnectedNode();
        var result = await node.Rest.GetTracksAsync(media);

        //If something went wrong on Lavalink's end                          
        if (result.LoadResultType == LavalinkLoadResultType.LoadFailed
            // or it just couldn't find anything.
            || result.LoadResultType == LavalinkLoadResultType.NoMatches)
            result = null;

        return result;
    }
}