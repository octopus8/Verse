using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;


public class WorldPointerNetworking : NetworkBehaviour {

    #region Class Variables

    /// <summary> Flag indicating right hand pointer activation.</summary>
    [SyncVar(hook = nameof(OnPointerActivationChanged))]
    protected bool pointerActivated = false;

    /// <summary>The input actions.</summary>
    protected VerseInputActions inputActions;

    /// <summary>Flag indicating the player is a local player.</summary>
    protected bool isPlayerLocal = false;

    #endregion



    #region Properties

    /// <summary>Allows access to the WorldPointerVisibility object.</summary>
    public WorldPointerVisibility WorldPointerVisibility { private get; set; }

    /// <summary>Allows the local player flag to be set. Upon setting this flag to true, input is polled.</summary>
    public bool IsLocalPlayer {
        private get {
            return isPlayerLocal;
        }
        set {
            isPlayerLocal = value;
            if (value) {
                inputActions = new VerseInputActions();
                inputActions.Player.WorldPointer.Enable();
                inputActions.Player.WorldPointer.started += WorldPointerStarted;
            }
        }
    }

    #endregion



    #region Server Commands

    /// <summary>
    /// Server command to set the SyncVar pointerActivated value.
    /// </summary>
    /// <param name="active"></param>
    [Command]
    protected void CmdOnPointerActiveChanged(bool active) {
        pointerActivated = active;
    }

    #endregion



    #region Private Methods

    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Input</param>
    protected void WorldPointerStarted(InputAction.CallbackContext context) {
        CmdOnPointerActiveChanged(context.ReadValueAsButton());
    }


    /// <summary>
    /// SyncVar hook called upon a change to rightHandPointerActivated, if the avatar is a remote avatar, then
    /// it is notified of the activation change.
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    protected void OnPointerActivationChanged(bool oldValue, bool newValue) {
        if (!IsLocalPlayer) {
            WorldPointerVisibility.SetVisible(newValue);
        }
    }

    #endregion

}
