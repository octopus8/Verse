using System;
using UnityEngine;

namespace O8C.System {

    /// <summary>
    /// Provides actions for Observers of player connection events.
    /// </summary>
    public class O8CPlayerConnection : MonoBehaviour {

        #region Public Events

        /// <summary>"on player connected" event.</summary>
        public event Action<GameObject, bool> OnPlayerConnected;

        /// <summary>"on player disconnected" event.</summary>
        public event Action<GameObject, bool> OnPlayerDisconnected;

        #endregion


        /// <summary>
        /// Called by O8CNetworkPlayer on Start to notify the system of a player connecting, this method calls
        /// the OnPlayerConnected observers.
        /// </summary>
        /// <remarks>
        /// This method is called by O8CNetworkPlayer on Start, notifying the system of a player connecting.
        /// </remarks>
        /// <param name="player">The new player GameObject.</param>
        /// <param name="isLocalPlayer">Flag indicating if the new player is a local player.</param>
        public void PlayerConnected(GameObject player, bool isLocalPlayer) {
            OnPlayerConnected.Invoke(player, isLocalPlayer);
        }


        /// <summary>
        /// Called by O8CNetworkPlayer on Start to notify the system of a player disconnecting, this method invokes
        /// the OnPlayerDisconnected event.
        /// </summary>
        /// <remarks>
        /// This method is called by O8CNetworkPlayer OnDestroy, notifying the system of a player disconnecting.
        /// </remarks>
        /// <param name="player">The player GameObject for the player disconnecting.</param>
        /// <param name="isLocalPlayer">Flag indicating if the player leaving is a local player.</param>
        public void PlayerDisconnected(GameObject player, bool isLocalPlayer) {
            OnPlayerDisconnected?.Invoke(player, isLocalPlayer);
        }

    }

}
