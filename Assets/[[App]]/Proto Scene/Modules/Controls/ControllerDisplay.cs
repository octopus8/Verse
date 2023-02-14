using O8C;
using UnityEngine;



[RequireComponent(typeof(OffsetTrackedObjects))]
public class ControllerDisplay : MonoBehaviour
{

    protected OffsetTrackedObjects controllerActorParts;


    private void Start() {        
        controllerActorParts = GetComponent<OffsetTrackedObjects>();
        controllerActorParts.LeftHandRoot.SetActive(false);
        controllerActorParts.RightHandRoot.SetActive(false);
    }


    private void Update() {
        float minimumHeadXRotation = 25;

        Transform headTransform = O8CSystem.Instance.DeviceTracking.GetHeadTransform();

        if (controllerActorParts.LeftHandRoot.activeInHierarchy) {
            if (headTransform.localEulerAngles.x < minimumHeadXRotation) {
                controllerActorParts.LeftHandRoot.SetActive(false);
                controllerActorParts.RightHandRoot.SetActive(false);
//                avatarActorParts.LeftHandRoot.SetActive(true);
//                avatarActorParts.RightHandRoot.SetActive(true);
            }
        } else {
            if ((headTransform.localEulerAngles.x > minimumHeadXRotation) && (headTransform.localEulerAngles.x < 90)) {
                controllerActorParts.LeftHandRoot.SetActive(true);
                controllerActorParts.RightHandRoot.SetActive(true);
//                avatarActorParts.LeftHandRoot.SetActive(false);
//                avatarActorParts.RightHandRoot.SetActive(false);
            }
        }


    }

}
