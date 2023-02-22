using O8C;
using UnityEngine;

/// <summary>
/// Factory interface for creating an avatar.
/// </summary>
public interface IAvatarFactory 
{
    /// <summary>
    /// Creates an avatar.
    /// </summary>
    /// <param name="player">The root player GameObject</param>
    /// <param name="networkPlayer">The IO8CNetworkPlayer component for the player</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player</param>
    /// <returns></returns>
    public GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer);

}
