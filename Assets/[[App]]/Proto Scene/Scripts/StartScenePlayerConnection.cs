using O8C;
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
    /// Callback called upon a player connecting, the avatar for the player is added and configured.
    /// If the player is a local player, input and motor components are added to the player, and
    /// the player is set as the play area follower.
    /// </summary>
    /// <param name="player">The new player GameObject.</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
    private void OnPlayerConnected(GameObject player, bool isLocalPlayer) {

        var avatar = Instantiate(avatarPrefab, player.transform);
        if (isLocalPlayer) {
            var actorMotor = player.AddComponent<ActorMotorDefault>();
            IMotorInput inputHandler = player.AddComponent<MotorInputDefault>();
            inputHandler.SetMotor(actorMotor);
            O8CSystem.Instance.DeviceTracking.SetPlayAreaFollower(player);
        }


    }

}
