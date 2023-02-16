using UnityEngine;




public class IKRiggedAvatar : MonoBehaviour
{
    #region Public Variables
    public Transform SourceHeadTransform { private get; set; }
    public Transform SourceLeftHandTransform { private get; set; }
    public Transform SourceRightHandTransform { private get; set; }

    #endregion



    #region Class Variables

    protected RiggedParts riggedParts;
    protected Quaternion leftHandOffsetRotation;
    protected Quaternion rightHandOffsetRotation;

    protected Vector3 leftHandOffsetPosition;
    protected Vector3 rightHandOffsetPosition;

    protected Quaternion headOriginalRotation;

    #endregion



    #region Base Methods

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
        if (null == riggedParts) {
            return;
        }
        if (null != SourceHeadTransform) {
            // BLEE Note: This does not take into consideration the original rotation of the riggedParts.Head.transform.rotation.
            riggedParts.HeadRoot.rotation = SourceHeadTransform.rotation * headOriginalRotation;
        }


        leftHandOffsetRotation = Quaternion.Euler(riggedParts.LeftHandOffset.rotation);
        rightHandOffsetRotation = Quaternion.Euler(riggedParts.RightHandOffset.rotation);

        leftHandOffsetPosition = riggedParts.LeftHandOffset.position;
        rightHandOffsetPosition = riggedParts.RightHandOffset.position;


        if (null != SourceLeftHandTransform) {
            Quaternion rot = SourceLeftHandTransform.rotation * leftHandOffsetRotation;
            riggedParts.LeftHandTransform.rotation = rot;

            Vector3 offset = rot * leftHandOffsetPosition;
            riggedParts.LeftHandTransform.position = SourceLeftHandTransform.position + offset;
        }

        if (null != SourceRightHandTransform) {
            Quaternion rot = SourceRightHandTransform.rotation * rightHandOffsetRotation;
            riggedParts.RightHandTransform.rotation = rot;

            Vector3 offset = rot * rightHandOffsetPosition;
            riggedParts.RightHandTransform.position = SourceRightHandTransform.position + offset;
        }

    }

    #endregion



    #region Public Methods

    public void SetRiggedParts(RiggedParts parts) {
        riggedParts = parts;
        headOriginalRotation = riggedParts.HeadRoot.rotation;
    }

    #endregion

}
