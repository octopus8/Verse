using O8C.System;
using Tilia.CameraRigs.TrackedAlias;
using UnityEngine;


/// <summary>
/// Handles new player connections.
/// </summary>
public class StartScenePlayerConnection : MonoBehaviour
{
    [SerializeField] protected GameObject avatarPrefab;


    /// <summary>
    /// Registers callbacks.
    /// </summary>
    void Start()
    {
        O8CSystem.Instance.PlayerConnection.AddPlayerConnectedObserver(OnPlayerConnected);
    }


    /// <summary>
    /// Unregisters callbacks.
    /// </summary>
    private void OnDestroy() {
        O8CSystem.Instance.PlayerConnection.RemovePlayerConnectedObserver(OnPlayerConnected);
    }



    /// <summary>
    /// Callback called upon a player connecting.
    /// </summary>
    /// <param name="player">The new player GameObject.</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
    private void OnPlayerConnected(GameObject player, bool isLocalPlayer) {

        var avatar = Instantiate(avatarPrefab, player.transform);

    }
}
