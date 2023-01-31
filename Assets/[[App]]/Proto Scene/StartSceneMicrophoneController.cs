using O8C;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Registers callbacks for the VoiceBroadcastGlobal input and upon the event, recording is started or stopped.
/// </summary>
public class StartSceneMicrophoneController : MonoBehaviour
{
    /// <summary>The input actions.</summary>
    VerseInputActions inputActions;


    #region Base Methods

    /// <summary>
    /// Creates a VerseInputActions.
    /// </summary>
    private void Awake() {
        inputActions = new VerseInputActions();
    }


    /// <summary>
    /// Destroys the VerseInputActions.
    /// </summary>
    private void OnDestroy() {
        inputActions = null;
    }


    /// <summary>
    /// Enables the input and registers an input callback.
    /// </summary>
    private void OnEnable() {
        inputActions.Player.VoiceBroadcastGlobal.Enable();
        inputActions.Player.VoiceBroadcastGlobal.performed += VoiceBroadcastGlobal_performed;

    }


    /// <summary>
    /// Ensures the microphone is not recording and unregisters an input callback.
    /// </summary>
    private void OnDisable() {
        O8CSystem.Instance.MicrophoneSupport.StopRecord();
        inputActions.Player.VoiceBroadcastGlobal.performed -= VoiceBroadcastGlobal_performed;
    }

    #endregion



    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Unused</param>
    private void VoiceBroadcastGlobal_performed(InputAction.CallbackContext context) {
        if (context.ReadValueAsButton()) {
            Debug.Log("Global broadcast start");
            O8CSystem.Instance.MicrophoneSupport.StartRecord();
        }
        else {
            Debug.Log("Global broadcast end");
            O8CSystem.Instance.MicrophoneSupport.StopRecord();
        }
    }

}
