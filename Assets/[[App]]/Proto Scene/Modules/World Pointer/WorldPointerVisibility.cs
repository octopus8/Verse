using UnityEngine;
using UnityEngine.InputSystem;

public class WorldPointerVisibility : MonoBehaviour
{
    [SerializeField] protected GameObject pointer;

    /// <summary>The input actions.</summary>
    VerseInputActions inputActions;

    public Transform RootTransform { set => pointer.transform.parent = transform; }

    bool isLocalPlayer;

    public bool IsLocalPlayer { set {
            isLocalPlayer = value; 
            if (value) {
                inputActions = new VerseInputActions();
                inputActions.Player.WorldPointer.Enable();
                inputActions.Player.WorldPointer.started += WorldPointerStarted;
            }
        }
    }




    void Start()
    {
        pointer.SetActive(false);
    }

    private void OnDestroy() {
        if (isLocalPlayer) {
            inputActions.Player.WorldPointer.started -= WorldPointerStarted;
            inputActions.Player.WorldPointer.Disable();

        }
    }



    public void SetVisible(bool isVisible) {
        pointer.SetActive(isVisible);
    }


    private void WorldPointerStarted(InputAction.CallbackContext context) {
        bool isVisible = context.ReadValueAsButton();
        Debug.Log("World Pointer " + isVisible);
        SetVisible(isVisible);
    }
}
