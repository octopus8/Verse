
using System;
using UnityEngine;

namespace O8C {

    /// <summary>
    /// Provides access to player connection events.
    /// </summary>
    public interface IO8CPlayerConnection {

        /// <summary>
        /// Add a "player connected" event observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void AddPlayerConnectedObserver(Action<GameObject, bool> observer);


        /// <summary>
        /// Remove a "player connected" event observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void RemovePlayerConnectedObserver(Action<GameObject, bool> observer);


        /// <summary>
        /// Notifies the system a player has connected.
        /// </summary>
        /// <remarks>
        /// This is called by O8CNetworkPlayer on Start.
        /// </remarks>
        /// <param name="player">The player that connected.</param>
        /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
        public void PlayerConnected(GameObject player, bool isLocalPlayer);


        /// <summary>
        /// Notifies the system a player has disconnected.
        /// </summary>
        /// <remarks>
        /// This is called by O8CNetworkPlayer OnDestroy.
        /// </remarks>
        /// <param name="player">The player that disconnected.</param>
        /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
        public void PlayerDisconnected(GameObject player, bool isLocalPlayer);

    }

}