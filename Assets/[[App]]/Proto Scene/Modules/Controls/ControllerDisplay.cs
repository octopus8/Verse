using O8C;
using UnityEngine;


/// <summary>
/// Handles displaying the controls.
/// </summary>
public class ControllerDisplay : MonoBehaviour
{
    /// <summary>The left controller GameObject.</summary>
    [Tooltip("The left controller GameObject.")]
    [SerializeField] protected GameObject leftController;

    /// <summary>The right controller GameObject.</summary>
    [Tooltip("The right controller GameObject.")]
    [SerializeField] protected GameObject rightController;


    /// <summary>
    /// Initializes display.
    /// </summary>
    private void Start() {
        leftController.SetActive(false);
        rightController.SetActive(false);
    }


    /// <summary>
    /// Displays/hides the controls.
    /// </summary>
    private void Update() {

        float minimumHeadXRotation = 25;

        Transform headTransform = O8CSystem.Instance.DeviceTracking.GetHeadTransform();

        if (leftController.activeInHierarchy) {
            if (headTransform.localEulerAngles.x < minimumHeadXRotation) {
                leftController.SetActive(false);
                rightController.SetActive(false);
                O8CSystem.Instance.EventManager.TriggerEvent(App.ShowAvatarEventID);
            }
        } else {
            if ((headTransform.localEulerAngles.x > minimumHeadXRotation) && (headTransform.localEulerAngles.x < 90)) {
                leftController.SetActive(true);
                rightController.SetActive(true);
                O8CSystem.Instance.EventManager.TriggerEvent(App.HideAvatarEventID);
            }
        }
    }

}
