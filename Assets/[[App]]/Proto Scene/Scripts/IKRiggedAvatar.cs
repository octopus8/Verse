using O8C;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This component synchronizes IK rigged avatar rigged part transforms with tracked part transforms.
/// </summary>
/// <remarks>
/// This class ASSUMES the left and right hand tracked parts of the avatar have an offset object. This object is used to transform the IK rig.
/// </remarks>
[RequireComponent(typeof(TrackedParts))]
public class IKRiggedAvatar : MonoBehaviour
{
    #region Interface Variables

    /// <summary>Left hand IK target.</summary>
    [Tooltip("Left hand IK target.")]
    [SerializeField] protected GameObject leftHandIKTarget;

    /// <summary>Right hand IK target.</summary>
    [Tooltip("Right hand IK target.")]
    [SerializeField] protected GameObject rightHandIKTarget;

    /// <summary>Head object.</summary>
    [Tooltip("Head object.")]
    [SerializeField] protected GameObject headObject;

    #endregion



    #region Class Variables

    /// <summary>The required TrackedParts component.</summary>
    protected TrackedParts trackedParts;

    /// <summary>Cached reference to tracked head transform.</summary>
    protected Transform trackedHeadSource;

    /// <summary>Cached reference to tracked left hand transform.</summary>
    protected Transform trackedLeftHandSource;

    /// <summary>Cached reference to tracked right hand transform.</summary>
    protected Transform trackedRightHandSource;

    /// <summary>The original rotation of the head.</summary>
    protected Quaternion headOriginalRotation;

    /// <summary>The left hand offset object.</summary>
    protected GameObject leftHandOffset;

    /// <summary>The right hand offset object.</summary>
    protected GameObject rightHandOffset;

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


    /// <summary>
    /// Caches references to objects and initializes values.
    /// </summary>
    private void Start() {
        // Assert values have been set.
        Assert.IsTrue(AvatarRoot != null);

        // Cache a reference to the offset objects.
        leftHandOffset = trackedParts.LeftHandTransform.GetChild(0).gameObject;
        rightHandOffset = trackedParts.RightHandTransform.GetChild(0).gameObject;

        // Set the position of the offset objects to the tracked parts offset.
        rightHandOffset.transform.localPosition = trackedParts.RightHandOffset.position;
        leftHandOffset.transform.localPosition = trackedParts.LeftHandOffset.position;

        // Cache the head's original rotation.
        headOriginalRotation = Quaternion.Inverse(AvatarRoot.rotation) * trackedParts.HeadRoot.rotation;
    }


    /// <summary>
    /// Updates tracked transforms.
    /// </summary>
    private void FixedUpdate() {

        // Set the AvatarRoot transform.
        AvatarRoot.transform.position = trackedHeadSource.transform.position;
        float yRot = trackedHeadSource.transform.rotation.eulerAngles.y;
        AvatarRoot.rotation = Quaternion.Euler(0f, yRot, 0f);

        // Set the tracked part transforms to the tracked sources.
        trackedParts.LeftHandTransform.position = trackedLeftHandSource.transform.position;
        trackedParts.LeftHandTransform.rotation = trackedLeftHandSource.transform.rotation;
        trackedParts.RightHandTransform.position = trackedRightHandSource.transform.position;
        trackedParts.RightHandTransform.rotation = trackedRightHandSource.transform.rotation;

        // test
        if (true) {
            rightHandOffset.transform.localPosition = trackedParts.RightHandOffset.position;
            leftHandOffset.transform.localPosition = trackedParts.LeftHandOffset.position;
        }

        // Set the IK target positions.
        rightHandIKTarget.transform.SetPositionAndRotation(rightHandOffset.transform.position, trackedRightHandSource.transform.rotation * Quaternion.Euler(trackedParts.RightHandOffset.rotation));
        leftHandIKTarget.transform.SetPositionAndRotation(leftHandOffset.transform.position, trackedLeftHandSource.transform.rotation * Quaternion.Euler(trackedParts.LeftHandOffset.rotation));
    }


    /// <summary>
    /// Updates the head root rotation.
    /// </summary>
    /// <remarks>This is done in LateUpdate to override animation.</remarks>
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


    public void SetIsLocalPlayer(bool isLocalPlayer) {
        headObject.SetActive(!isLocalPlayer);
    }

    #endregion

}
