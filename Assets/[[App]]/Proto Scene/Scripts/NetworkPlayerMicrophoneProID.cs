using FrostweepGames.VoicePro;
using FrostweepGames.VoicePro.NetworkProviders.Mirror;
using Mirror;


/// <summary>
/// This component is attached to a O8CMirrorNetworkPlayer to provide access to a player's Microphone Pro ID. 
/// </summary>
public class NetworkPlayerMicrophoneProID : NetworkBehaviour {

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