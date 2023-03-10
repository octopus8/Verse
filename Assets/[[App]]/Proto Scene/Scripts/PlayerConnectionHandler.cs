using O8C;
using UnityEngine;


/// <summary>
/// Creates and destroys players upon connection and disconnection.
/// </summary>
public class PlayerConnectionHandler : MonoBehaviour
{
    #region Inspector Variables

    /// <summary>The avatar factory.</summary>
    [SerializeField] protected AvatarFactory avatarFactory;

    /// <summary>The player start transform.</summary>
    [Tooltip("The player start transform.")]
    [SerializeField] protected Transform startTransform;

    /// <summary>The hot mic indicator prefab.</summary>
    [Tooltip("The hot mic indicator prefab.")]
    [SerializeField] protected GameObject hotMicIndicatorPrefab;

    /// <summary>The controllers prefab.</summary>
    [Tooltip("The controllers prefab.")]
    [SerializeField] protected GameObject controllersPrefab;

    /// <summary>The world pointer prefab.</summary>
    [Tooltip("The world pointer prefab.")]
    [SerializeField] protected GameObject worldPointerPrefab;


    

    /// <summary>The set of motor inputs.</summary>
    [SerializeField] MotorInput[] motorInputs;

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
    /// <param name="player">The new IO8CNetworkPlayer GameObject.</param>
    /// <param name="isLocalPlayer">Flag indicating the player is a local player.</param>
    private void OnPlayerConnected(GameObject player, bool isLocalPlayer) {

        var networkPlayer = player.GetComponent<IO8CNetworkPlayer>();
        GameObject avatar = avatarFactory.CreateAvatar(player, networkPlayer, isLocalPlayer);

        if (isLocalPlayer) {
            player.name = "Local Player";
            var actorMotor = player.AddComponent<ActorMotorSimple>();
            foreach (var motorInput in motorInputs) {
                motorInput.SetMotor(actorMotor);
                motorInput.SetInputTransform(player.transform);
            }
            O8CSystem.Instance.DeviceTracking.SetPlayAreaFollower(player);

            // Add the hot mic controller to the player. Instantiate the hot mic indicator prefab and attach it to the head.
            player.AddComponent<MicrophoneRecordController>();
            Instantiate(hotMicIndicatorPrefab, O8CSystem.Instance.DeviceTracking.GetHeadTransform());

            // Add Controllers display.
            var controllers = Instantiate(controllersPrefab, player.transform).GetComponent<MinimalAvatar>();
            controllers.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());

            // Add avatar hider.
            player.AddComponent<LocalAvatarHider>().Avatar = avatar;

            // Initialize the player position.
            player.transform.rotation = startTransform.rotation;
            player.transform.position = startTransform.position;
        }
        else {
            player.name = "Remote Player";
        }

        // Create a world pointer and add it to the avatar.
        WorldPointer worldPointer = Instantiate(worldPointerPrefab, avatar.transform).GetComponent<WorldPointer>();
        worldPointer.IsLocalPlayer = isLocalPlayer;
        TrackedParts trackedParts = avatar.GetComponent<TrackedParts>();
        worldPointer.RootTransform = trackedParts.RightHandTransform;
    }


    /// <summary><
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
