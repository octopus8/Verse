using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;


public class WorldPointerNetworking : NetworkBehaviour {

    /// <summary>The input actions.</summary>
    VerseInputActions inputActions;

    /// <summary> Flag indicating right hand pointer activation.</summary>
    [SyncVar(hook = nameof(OnPointerActivationChanged))]
    protected bool pointerActivated = false;


//    WorldPointerVisibility worldPointerVisibility;
    public WorldPointerVisibility WorldPointerVisibility { private get; set; }

    bool isPlayerLocal = false;
    public bool IsLocalPlayer { private get {
            return isPlayerLocal; 
        }
        set {
            isPlayerLocal = value;
            if (value) {
                inputActions = new VerseInputActions();
                inputActions.Player.WorldPointer.Enable();
                inputActions.Player.WorldPointer.started += WorldPointerStarted;
            }
        } }



    private void Awake() {
//        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
    }


    private void Start() {
        if (IsLocalPlayer) {
            inputActions = new VerseInputActions();
            inputActions.Player.WorldPointer.Enable();
            inputActions.Player.WorldPointer.started += WorldPointerStarted;
        }

    }


        


    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Input</param>
    private void WorldPointerStarted(InputAction.CallbackContext context) {
        CmdOnPointerActiveChanged(context.ReadValueAsButton());
    }



    [Command]
    void CmdOnPointerActiveChanged(bool active) {
        Debug.Log("CMD CALLED");
        pointerActivated = active;
    }



    /// <summary>
    /// Callback called upon a change to rightHandPointerActivated, if the avatar is a remote avatar, then
    /// it is notified of the activation change.
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    protected void OnPointerActivationChanged(bool oldValue, bool newValue) {
        if (!IsLocalPlayer) {
            WorldPointerVisibility.SetVisible(newValue);
        }
    }



}
