using UnityEngine;



public class IKRiggedAvatar : MonoBehaviour
{
    RiggedParts riggedParts;
    Transform sourceHeadTransform;


    public void SetRiggedParts(RiggedParts parts) {
        riggedParts = parts;
    }

    public void SetSourceHeadTransform(Transform headTransform) {
        sourceHeadTransform = headTransform;
    }


    private void FixedUpdate() {
        float yRot = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, yRot, 0f);
    }


    /// <summary>
    /// Sets the rigged head transform to the source head transform.
    /// </summary>
    /// <remarks>
    /// This is done in LateUpdate to override any animation effects.
    /// </remarks>
    private void LateUpdate() {
        if ((null != riggedParts) && (null != sourceHeadTransform)) {
            riggedParts.Head.transform.rotation = sourceHeadTransform.rotation;
        }

    }
}
