using UnityEngine;




public class IKRiggedAvatar : MonoBehaviour
{
    RiggedParts riggedParts;

    public Transform SourceHeadTransform { private get; set; }
    public Transform SourceLeftHandTransform { private get; set; }
    public Transform SourceRightHandTransform { private get; set; }



    public GameObject TestObj { get; private set; }




    public void SetRiggedParts(RiggedParts parts) {
        riggedParts = parts;
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
        if (null != riggedParts) {
            if (null != SourceHeadTransform) {
                riggedParts.Head.transform.rotation = SourceHeadTransform.rotation;
            }

            if (null != SourceLeftHandTransform) {
                riggedParts.LeftHand.transform.rotation = SourceLeftHandTransform.rotation;
            }

            if (null != SourceRightHandTransform) {
                riggedParts.RightHand.transform.rotation = SourceRightHandTransform.rotation;
            }
        }

    }
}
