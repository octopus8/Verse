using O8C;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This component synchronizes IK rigged avatar rigged part transforms with tracked part transforms.
/// </summary>
[RequireComponent(typeof(TrackedParts))]
public class IKRiggedAvatar : MonoBehaviour
{
    [SerializeField] protected GameObject leftHandIKTarget;
    [SerializeField] protected GameObject rightHandIKTarget;


    #region Class Variables

    /// <summary>The required TrackedParts component.</summary>
    protected TrackedParts trackedParts;

    /// <summary>Cached reference to tracked head transform.</summary>
    protected Transform trackedHeadSource;

    /// <summary>Cached reference to tracked left hand transform.</summary>
    protected Transform trackedLeftHandSource;

    /// <summary>Cached reference to tracked right hand transform.</summary>
    protected Transform trackedRightHandSource;

    protected Quaternion headOriginalRotation;

    /// <summary>Allows the avatar root transform to be set.</summary>
    public Transform AvatarRoot { private get; set; }

    #endregion



    #region Base Methods

    /// <summary>
    /// Caches component references.
    /// </summary>
    private void Awake() {
        trackedParts = GetComponent<TrackedParts>();
    }

    protected GameObject leftHandOffset;
    protected GameObject rightHandOffset;


    private void Start() {
        Assert.IsTrue(AvatarRoot != null);

        leftHandOffset = trackedParts.LeftHandTransform.GetChild(0).gameObject;
        rightHandOffset = trackedParts.RightHandTransform.GetChild(0).gameObject;

        rightHandOffset.transform.localPosition = trackedParts.RightHandOffset.position;
        leftHandOffset.transform.localPosition = trackedParts.LeftHandOffset.position;

        headOriginalRotation = Quaternion.Inverse(AvatarRoot.rotation) * trackedParts.HeadRoot.rotation;

    }


    private void FixedUpdate() {

        // Set the AvatarRoot transform.
        AvatarRoot.transform.position = trackedHeadSource.transform.position;
        float yRot = trackedHeadSource.transform.rotation.eulerAngles.y;
        AvatarRoot.rotation = Quaternion.Euler(0f, yRot, 0f);

        trackedParts.LeftHandTransform.position = trackedLeftHandSource.transform.position;
        trackedParts.LeftHandTransform.rotation = trackedLeftHandSource.transform.rotation;
        trackedParts.RightHandTransform.position = trackedRightHandSource.transform.position;
        trackedParts.RightHandTransform.rotation = trackedRightHandSource.transform.rotation;

        // XXX TEST
//        rightHandOffset.transform.localPosition = trackedParts.RightHandOffset.position;
//        leftHandOffset.transform.localPosition = trackedParts.LeftHandOffset.position;

        rightHandIKTarget.transform.SetPositionAndRotation(rightHandOffset.transform.position, trackedRightHandSource.transform.rotation * Quaternion.Euler(trackedParts.RightHandOffset.rotation));
        leftHandIKTarget.transform.SetPositionAndRotation(leftHandOffset.transform.position, trackedLeftHandSource.transform.rotation * Quaternion.Euler(trackedParts.LeftHandOffset.rotation));
    }


    private void LateUpdate() {
        // Set the head rotation. Note: The position is set indirectly by setting the AvatarRoot position.
        trackedParts.HeadRoot.rotation = trackedHeadSource.rotation * headOriginalRotation;
    }

    #endregion



    #region Public Methods

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

    #endregion

}
