using O8C;
using UnityEngine;



public class ControllerDisplay : MonoBehaviour
{
    [SerializeField] protected GameObject leftController;
    [SerializeField] protected GameObject rightController;


    private void Start() {
        leftController.SetActive(false);
        rightController.SetActive(false);
    }


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
