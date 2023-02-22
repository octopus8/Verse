using O8C;
using UnityEngine;


/// <summary>
/// Rotates the component to face the camera.
/// </summary>
public class CameraFacing : MonoBehaviour
{

    /// <summary>
    /// Rotates the component to face the camera.
    /// </summary>
    private void LateUpdate() {
        transform.LookAt(O8CSystem.Instance.DeviceTracking.GetHeadTransform());
    }

}
