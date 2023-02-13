using UnityEngine;




public class IKRiggedAvatar : MonoBehaviour
{
    RiggedParts riggedParts;

    public Transform SourceHeadTransform { private get; set; }
    public Transform SourceLeftHandTransform { private get; set; }
    public Transform SourceRightHandTransform { private get; set; }


    Quaternion leftHandOffsetRotation;
    Quaternion rightHandOffsetRotation;

    Vector3 leftHandOffsetPosition;
    Vector3 rightHandOffsetPosition;



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

        }

        leftHandOffsetRotation = Quaternion.Euler(-90f, 90f, 0f);
        rightHandOffsetRotation = Quaternion.Euler(90f, 0f, 90f);

        leftHandOffsetPosition = new Vector3(0.11f, 0.03f, -0.03f);
        rightHandOffsetPosition = new Vector3(-0.11f, -0.03f, 0.03f);


        if (null != SourceLeftHandTransform) {
            Quaternion rot = SourceLeftHandTransform.rotation * leftHandOffsetRotation;
            riggedParts.LeftHand.transform.rotation = rot;

            Vector3 offset = rot * leftHandOffsetPosition;
            riggedParts.LeftHand.transform.position = SourceLeftHandTransform.position + offset;
        }

        if (null != SourceRightHandTransform) {
            Quaternion rot = SourceRightHandTransform.rotation * rightHandOffsetRotation;
            riggedParts.RightHand.transform.rotation = rot;

            Vector3 offset = rot * rightHandOffsetPosition;
            riggedParts.RightHand.transform.position = SourceRightHandTransform.position + offset;
        }

    }
}
