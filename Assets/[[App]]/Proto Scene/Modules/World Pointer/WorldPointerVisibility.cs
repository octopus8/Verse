using UnityEngine;
using UnityEngine.InputSystem;

public class WorldPointerVisibility : MonoBehaviour
{
    [SerializeField] protected GameObject pointer;

    /// <summary>The input actions.</summary>
    VerseInputActions inputActions;

    public bool IsLocalPlayer { set {
            if (value) {
                inputActions = new VerseInputActions();
                inputActions.Player.WorldPointer.Enable();
                inputActions.Player.WorldPointer.performed += WorldPointer_performed;
            }
        }
    }



    void Start()
    {
        // XXX TEST
//        pointer.SetActive(false);
    }




    public void SetVisible(bool isVisible) {
        pointer.SetActive(isVisible);
    }


    /// <summary>
    /// Callback called upon VoiceBroadcastGlobal input action.
    /// </summary>
    /// <param name="context">Input</param>
    private void WorldPointer_performed(InputAction.CallbackContext context) {
        Debug.Log("Setting pointer visible " + context.ReadValueAsButton());
        SetVisible(context.ReadValueAsButton());
    }


}
