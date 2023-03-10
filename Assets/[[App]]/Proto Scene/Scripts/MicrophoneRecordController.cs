using O8C;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Registers callbacks for the VoiceBroadcastGlobal input and upon the event, recording is started or stopped.
/// </summary>
public class MicrophoneRecordController : MonoBehaviour
{

    /// <summary>The input actions.</summary>
    protected VerseInputActions inputActions;

    /// <summary>Coroutine used to stop record on start.</summary>
    protected Coroutine stopOnStart = null;



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
        inputActions.Player.VoiceBroadcastGlobal.started += VoiceBroadcastGlobalStarted;

    }


    /// <summary>
    /// Ensures the microphone is not recording and unregisters an input callback.
    /// </summary>
    private void OnDisable() {
        O8CSystem.Instance.MicrophoneSupport.StopRecord();
        inputActions.Player.VoiceBroadcastGlobal.started -= VoiceBroadcastGlobalStarted;
    }

    #endregion



    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Unused</param>
    protected void VoiceBroadcastGlobalStarted(InputAction.CallbackContext context) {
        if (context.ReadValueAsButton()) {
            Debug.Log("Global broadcast start");
            if (stopOnStart != null) {
                StopCoroutine(stopOnStart);
                stopOnStart = null;
            }                
            O8CSystem.Instance.MicrophoneSupport.StartRecord();
        }
        else {
            Debug.Log("Global broadcast end");
            if (O8CSystem.Instance.MicrophoneSupport.IsRecording()) {
                O8CSystem.Instance.MicrophoneSupport.StopRecord();
            } else {
                stopOnStart = StartCoroutine(StopRecordOnStart());
            }
        }
    }


    /// <summary>
    /// Stops recording as soon as recording is detected.
    /// </summary>
    /// <remarks>Starting record can take a few frames. In that time, a request to stop may be made. This stop must happen after the record starts.</remarks>
    /// <returns>Coroutine</returns>
    protected IEnumerator StopRecordOnStart() {
        while (true) {
            if (O8CSystem.Instance.MicrophoneSupport.IsRecording()) {
                O8CSystem.Instance.MicrophoneSupport.StopRecord();
                yield break;
            }
            else {
                yield return null;
            }
        }
    }
}
