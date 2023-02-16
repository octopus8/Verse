using UnityEngine;



/// <summary>
/// This component synchronizes IK rigged avatar rigged part transforms with tracked part transforms.
/// </summary>
[RequireComponent(typeof(TrackedParts))]
public class IKRiggedAvatar : MonoBehaviour
{
    #region Public Variables
    public Transform SourceHeadTransform { private get; set; }
    public Transform SourceLeftHandTransform { private get; set; }
    public Transform SourceRightHandTransform { private get; set; }

    #endregion



    #region Class Variables

    protected TrackedParts trackedParts;
    protected Quaternion leftHandOffsetRotation;
    protected Quaternion rightHandOffsetRotation;

    protected Vector3 leftHandOffsetPosition;
    protected Vector3 rightHandOffsetPosition;

    protected Quaternion headOriginalRotation;

    #endregion



    /// <summary>Cached reference to tracked head transform.</summary>
    protected Transform trackedHeadSource;

    /// <summary>Cached reference to tracked left hand transform.</summary>
    protected Transform trackedLeftHandSource;

    /// <summary>Cached reference to tracked right hand transform.</summary>
    protected Transform trackedRightHandSource;

    /// <summary>Cached reference to the left hand offset transform.</summary>
    protected Transform leftHandOffset;

    /// <summary>Cached reference to the right hand offset transform.</summary>
    protected Transform rightHandOffset;


    /// <summary>
    /// Sets the tracked transforms used to animate the avatar.
    /// </summary>
    /// <param name="head">The head tracked transform.</param>
    /// <param name="leftHand">The left hand tracked transform.</param>
    /// <param name="rightHand">The right hand tracked transform.</param>
    public void SetTrackedSources(Transform head, Transform leftHand, Transform rightHand) {
        trackedHeadSource = head;
        trackedLeftHandSource = leftHand;
        trackedRightHandSource = rightHand;
    }



    #region Base Methods

    private void Awake() {
        trackedParts = GetComponent<TrackedParts>();
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
        if (null == trackedParts) {
            return;
        }
        if (null != SourceHeadTransform) {
            // BLEE Note: This does not take into consideration the original rotation of the riggedParts.Head.transform.rotation.
            trackedParts.HeadRoot.rotation = SourceHeadTransform.rotation * headOriginalRotation;
        }


        leftHandOffsetRotation = Quaternion.Euler(trackedParts.LeftHandOffset.rotation);
        rightHandOffsetRotation = Quaternion.Euler(trackedParts.RightHandOffset.rotation);

        leftHandOffsetPosition = trackedParts.LeftHandOffset.position;
        rightHandOffsetPosition = trackedParts.RightHandOffset.position;


        if (null != SourceLeftHandTransform) {
            Quaternion rot = SourceLeftHandTransform.rotation * leftHandOffsetRotation;
            trackedParts.LeftHandTransform.rotation = rot;

            Vector3 offset = rot * leftHandOffsetPosition;
            trackedParts.LeftHandTransform.position = SourceLeftHandTransform.position + offset;
        }

        if (null != SourceRightHandTransform) {
            Quaternion rot = SourceRightHandTransform.rotation * rightHandOffsetRotation;
            trackedParts.RightHandTransform.rotation = rot;

            Vector3 offset = rot * rightHandOffsetPosition;
            trackedParts.RightHandTransform.position = SourceRightHandTransform.position + offset;
        }

    }

    #endregion




}
