using O8C;
using UnityEngine;


/// <summary>
/// Handles new player connections.
/// </summary>
public class StartScenePlayerConnection : MonoBehaviour
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
    [Tooltip("The controllsers prefab.")]
    [SerializeField] protected GameObject controllersPrefab;

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
    /// <param name="player">The new player GameObject.</param>
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

            player.AddComponent<StartSceneMicrophoneController>();
            Instantiate(hotMicIndicatorPrefab, O8CSystem.Instance.DeviceTracking.GetHeadTransform());

            // Add Controllers display.
            var controllers = Instantiate(controllersPrefab, player.transform).GetComponent<MinimalAvatar>();
            controllers.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());

            // Add avatar hider.
            player.AddComponent<AvatarHider>().Avatar = avatar;
        }
        else {
            player.name = "Remote Player";
        }


        player.transform.rotation = startTransform.rotation;
        player.transform.position = startTransform.position;

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
