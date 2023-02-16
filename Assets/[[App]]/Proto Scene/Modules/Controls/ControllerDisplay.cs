using O8C;
using UnityEngine;



[RequireComponent(typeof(OffsetTrackedObjects))]
public class ControllerDisplay : MonoBehaviour
{

    protected OffsetTrackedObjects controllerActorParts;


    private void Start() {        
        controllerActorParts = GetComponent<OffsetTrackedObjects>();
        controllerActorParts.RiggedParts.LeftHand.SetActive(false);
        controllerActorParts.RiggedParts.RightHand.SetActive(false);
    }


    private void Update() {
        float minimumHeadXRotation = -25;

        Transform headTransform = O8CSystem.Instance.DeviceTracking.GetHeadTransform();

        if (controllerActorParts.RiggedParts.LeftHand.activeInHierarchy) {
            if (headTransform.localEulerAngles.x < minimumHeadXRotation) {
                controllerActorParts.RiggedParts.LeftHand.SetActive(false);
                controllerActorParts.RiggedParts.RightHand.SetActive(false);
                O8CSystem.Instance.EventManager.TriggerEvent(App.ShowAvatarEventID);
            }
        } else {
            if ((headTransform.localEulerAngles.x > minimumHeadXRotation) && (headTransform.localEulerAngles.x < 90)) {
                controllerActorParts.RiggedParts.LeftHand.SetActive(true);
                controllerActorParts.RiggedParts.RightHand.SetActive(true);
                O8CSystem.Instance.EventManager.TriggerEvent(App.HideAvatarEventID);
            }
        }


    }

}
