using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WorldPointerVisibility))]

public class WorldPointerNetworking : NetworkBehaviour {

    /// <summary>The input actions.</summary>
    VerseInputActions inputActions;

    /// <summary> Flag indicating right hand pointer activation.</summary>
    [SyncVar(hook = nameof(OnPointerActivationChanged))]
    protected bool pointerActivated = false;


    WorldPointerVisibility worldPointerVisibility;
//    public WorldPointerVisibility WorldPointerVisibility { private get; set; }

    public bool IsLocalPlayer { private get; set; }



    private void Awake() {
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
    }


    private void Start() {
        if (IsLocalPlayer) {
            inputActions = new VerseInputActions();
            inputActions.Player.WorldPointer.Enable();
            inputActions.Player.WorldPointer.performed += WorldPointer_performed;
        }

    }





    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Input</param>
    private void WorldPointer_performed(InputAction.CallbackContext context) {
        if (context.ReadValueAsButton()) {
            CmdOnPointerActiveChanged(true);
        }
        else {
            CmdOnPointerActiveChanged(false);
        }
    }



    [Command]
    void CmdOnPointerActiveChanged(bool active) {
        pointerActivated = active;
    }



    /// <summary>
    /// Callback called upon a change to rightHandPointerActivated, if the avatar is a remote avatar, then
    /// it is notified of the activation change.
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    protected void OnPointerActivationChanged(bool oldValue, bool newValue) {
        if (!isLocalPlayer) {
            worldPointerVisibility.SetVisible(newValue);
        }
    }



}
