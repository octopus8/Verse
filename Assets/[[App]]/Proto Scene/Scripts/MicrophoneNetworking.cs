using FrostweepGames.VoicePro;
using FrostweepGames.VoicePro.NetworkProviders.Mirror;
using Mirror;


/// <summary>
/// Provides support for 
/// </summary>
public class MicrophoneNetworking : NetworkBehaviour {

    /// <summary>
    /// Synchronized Microphone Pro ID.
    /// </summary>
    [SyncVar]
    protected string microphoneProID;



    /// <summary>
    /// If the player is a local player, then the command CmdSetMicrophoneProID is called.
    /// </summary>
    private void Start() {
        if (isLocalPlayer) {
            CmdSetMicrophoneProID(((MirrorNetworkProvider)NetworkRouter.Instance._networkProvider)._networkActor.Id);
        }
    }


    /// <summary>
    /// Server command to set the Microphone Pro ID value.
    /// </summary>
    /// <param name="id">The Microphone Pro ID value.</param>
    [Command]
    void CmdSetMicrophoneProID(string id) {
        microphoneProID = id;
    }

}