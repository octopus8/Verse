using UnityEngine;
using UnityEngine.InputSystem;



public class WorldPointerVisibility : MonoBehaviour
{
    #region Interface Variables

    /// <summary>The pointer geometry.</summary>
    [SerializeField] protected GameObject pointerGeometry;

    #endregion



    /// <summary>Maximum distance of pointer.</summary>
    const float maxDistance = 20.0f;



    #region Class Variables

    /// <summary>The input actions.</summary>
    protected VerseInputActions inputActions;

    /// <summary>Flag indicating the player is a local player.</summary>
    protected bool isLocalPlayer;

    #endregion



    #region Properties

    /// <summary>Allows the root transform of the pointer geometry to be set.</summary>
    public Transform RootTransform { set { pointerGeometry.transform.parent = value; pointerGeometry.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity); } }

    /// <summary>Allows the local player flag to be set. Upon setting this flag to true, input is polled.</summary>
    public bool IsLocalPlayer {
        set {
            isLocalPlayer = value;
            if (value) {
                inputActions = new VerseInputActions();
                inputActions.Player.WorldPointer.Enable();
                inputActions.Player.WorldPointer.started += WorldPointerStarted;
            }
        }
    }

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes pointer visibility.
    /// </summary>
    void Start()
    {
        pointerGeometry.SetActive(false);
    }


    /// <summary>
    /// Handles destroying the player.
    /// </summary>
    private void OnDestroy() {
        Destroy(pointerGeometry);
        if (isLocalPlayer) {
            inputActions.Player.WorldPointer.started -= WorldPointerStarted;
            inputActions.Player.WorldPointer.Disable();

        }
    }


    /// <summary>
    /// Sets the pointer length, if active.
    /// </summary>
    private void FixedUpdate() {
        // If the pointer is not active, then do nothing.
        if (!pointerGeometry.activeInHierarchy) {
            return;
        }

        // Do raycast and set the pointer length.
        Vector3 scale = Vector3.one;
        if (Physics.Raycast(pointerGeometry.transform.position, pointerGeometry.transform.forward, out RaycastHit hit, maxDistance)) {
            scale.z = hit.distance;
        } else {
            scale.z = maxDistance;
        }
        pointerGeometry.transform.localScale = scale;
    }

    #endregion



    #region Public Methods

    /// <summary>
    /// Sets the pointer visibility.
    /// </summary>
    /// <param name="isVisible">Flag indicating visibility.</param>
    public void SetVisible(bool isVisible) {
        pointerGeometry.SetActive(isVisible);
    }

    #endregion



    #region Private Methods

    /// <summary>
    /// Callback called upon world pointer input.
    /// </summary>
    /// <param name="context">Input data</param>
    private void WorldPointerStarted(InputAction.CallbackContext context) {
        bool isVisible = context.ReadValueAsButton();
        Debug.Log("World Pointer " + isVisible);
        SetVisible(isVisible);
    }

    #endregion

}
