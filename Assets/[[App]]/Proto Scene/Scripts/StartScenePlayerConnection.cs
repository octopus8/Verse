using O8C;
using UnityEngine;


/// <summary>
/// Handles new player connections.
/// </summary>
public class StartScenePlayerConnection : MonoBehaviour
{
    #region Inspector Variables

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected GameObject avatarPrefab;

    /// <summary>The player start transform.</summary>
    [Tooltip("The player start transform.")]
    [SerializeField] protected Transform startTransform;

    #endregion



    #region Base Methods

    /// <summary>
    /// Registers callbacks.
    /// </summary>
    void Start()
    {
        O8CSystem.Instance.PlayerConnection.AddPlayerConnectedObserver(OnPlayerConnected);
        O8CSystem.Instance.PlayerConnection.AddPlayerDisconnectedObserver(OnPlayerDisconnected);
    }


    /// <summary>
    /// Unregisters callbacks.
    /// </summary>
    private void OnDestroy() {
        O8CSystem.Instance.PlayerConnection.RemovePlayerConnectedObserver(OnPlayerConnected);
        O8CSystem.Instance.PlayerConnection.RemovePlayerDisconnectedObserver(OnPlayerDisconnected);
    }

    #endregion



    #region Private Methods

    /// <summary>
    /// Callback called upon a player connecting, the avatar for the player is added and configured.
    /// If the player is a local player, input and motor components are added to the player, and
    /// the player is set as the play area follower.
    /// </summary>
    /// <param name="player">The new player GameObject.</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
    private void OnPlayerConnected(GameObject player, bool isLocalPlayer) {

        var networkPlayer = player.GetComponent<IO8CNetworkPlayer>();


        var avatar = Instantiate(avatarPrefab, player.transform).GetComponent<O8CAvatarParts>();

        networkPlayer.AddHeadFollower(avatar.Head);
        networkPlayer.AddLeftHandFollower(avatar.LeftHand);
        networkPlayer.AddRightHandFollower(avatar.RightHand);

        if (isLocalPlayer) {
            player.AddComponent<StartSceneMicrophoneController>();
            var actorMotor = player.AddComponent<ActorMotorSimple>();
            IMotorInput motorInput = player.AddComponent<MotorInputSimple>();
            motorInput.SetMotor(actorMotor);
            motorInput.SetInputTransform(avatar.BodyJoint.transform);

            O8CSystem.Instance.DeviceTracking.SetPlayAreaFollower(player);

            player.transform.rotation = startTransform.rotation;
            player.transform.position = startTransform.position;
        }


    }


    /// <summary>
    /// Callback called upon a player disconnecting.
    /// </summary>
    /// <param name="player">The player that has disconnected.</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
    private void OnPlayerDisconnected(GameObject player, bool isLocalPlayer) {
        if (isLocalPlayer) {
            O8CSystem.Instance.DeviceTracking.SetPlayAreaFollower(null);
        }
    }

    #endregion

}
