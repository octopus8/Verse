using O8C;
using UnityEngine;



public class CameraFacing : MonoBehaviour
{


    private void LateUpdate() {
        transform.LookAt(O8CSystem.Instance.DeviceTracking.GetHeadTransform());
    }


}
