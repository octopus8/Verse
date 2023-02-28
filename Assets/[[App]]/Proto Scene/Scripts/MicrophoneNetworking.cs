using FrostweepGames.VoicePro;
using FrostweepGames.VoicePro.NetworkProviders.Mirror;
using Mirror;


public class MicrophoneNetworking : NetworkBehaviour {


    [SyncVar]
    protected string microphoneProID;


    private void Start() {
        if (isLocalPlayer) {
            CmdSetMicrophoneProID(((MirrorNetworkProvider)NetworkRouter.Instance._networkProvider)._networkActor.Id);
        }
    }



    [Command]
    void CmdSetMicrophoneProID(string id) {
        microphoneProID = id;
    }



}