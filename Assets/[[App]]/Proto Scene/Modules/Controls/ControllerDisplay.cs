using O8C;
using UnityEngine;



[RequireComponent(typeof(MinimalAvatar))]
public class ControllerDisplay : MonoBehaviour
{

    protected MinimalAvatar controllerActorParts;


    private void Start() {        
        controllerActorParts = GetComponent<MinimalAvatar>();
        controllerActorParts.RiggedParts.LeftHandTransform.gameObject.SetActive(false);
        controllerActorParts.RiggedParts.RightHandTransform.gameObject.SetActive(false);
    }


    private void Update() {
        float minimumHeadXRotation = 25;

        Transform headTransform = O8CSystem.Instance.DeviceTracking.GetHeadTransform();

        if (controllerActorParts.RiggedParts.LeftHandTransform.gameObject.activeInHierarchy) {
            if (headTransform.localEulerAngles.x < minimumHeadXRotation) {
                controllerActorParts.RiggedParts.LeftHandTransform.gameObject.SetActive(false);
                controllerActorParts.RiggedParts.RightHandTransform.gameObject.SetActive(false);
                O8CSystem.Instance.EventManager.TriggerEvent(App.ShowAvatarEventID);
            }
        } else {
            if ((headTransform.localEulerAngles.x > minimumHeadXRotation) && (headTransform.localEulerAngles.x < 90)) {
                controllerActorParts.RiggedParts.LeftHandTransform.gameObject.SetActive(true);
                controllerActorParts.RiggedParts.RightHandTransform.gameObject.SetActive(true);
                O8CSystem.Instance.EventManager.TriggerEvent(App.HideAvatarEventID);
            }
        }


    }

}
