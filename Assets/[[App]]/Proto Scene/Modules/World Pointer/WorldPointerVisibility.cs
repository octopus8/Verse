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


    private void FixedUpdate() {
        if (!pointer.activeInHierarchy) {
            return;
        }

        float maxDistance = 10.0f;

        Vector3 scale = Vector3.zero;
        if (Physics.Raycast(pointer.transform.position, pointer.transform.forward, out RaycastHit hit, maxDistance)) {
            scale.z = hit.distance;
        } else {
            scale.z = maxDistance;
        }
        pointer.transform.localScale = scale;
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
