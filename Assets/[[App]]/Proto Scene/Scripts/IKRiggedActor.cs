using O8C;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This component synchronizes IK rigged avatar rigged part transforms with tracked part transforms.
/// </summary>
[RequireComponent(typeof(TrackedParts))]
public class IKRiggedActor : MonoBehaviour
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

    [SerializeField] protected IKRiggedAvatarFootSolver leftFootSolver;

    [SerializeField] protected IKRiggedAvatarFootSolver rightFootSolver;

    public IKRiggedAvatarFootSolver LeftFootSolver { get { return leftFootSolver; } }
    public IKRiggedAvatarFootSolver RightFootSolver { get { return rightFootSolver; } }

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

        // Cache the head's original rotation.
        headOriginalRotation = Quaternion.Inverse(AvatarRoot.rotation) * trackedParts.HeadRoot.rotation;
    }


    /// <summary>
    /// Updates tracked transforms.
    /// </summary>
    private void FixedUpdate() {

        // Set the AvatarRoot transform.
        if (null != trackedHeadSource) {
            AvatarRoot.transform.position = trackedHeadSource.transform.position;
            float yRot = trackedHeadSource.transform.rotation.eulerAngles.y;
            AvatarRoot.rotation = Quaternion.Euler(0f, yRot, 0f);
        }

        if (null != trackedLeftHandSource) {
            trackedParts.LeftHandTransform.position = trackedLeftHandSource.transform.position;
            trackedParts.LeftHandTransform.rotation = trackedLeftHandSource.transform.rotation;
            leftHandIKTarget.transform.SetPositionAndRotation(trackedLeftHandSource.transform.position, trackedLeftHandSource.transform.rotation * Quaternion.Euler(trackedParts.LeftHandOffset.rotation));
            leftHandIKTarget.transform.localPosition += trackedLeftHandSource.transform.localRotation * trackedParts.LeftHandOffset.position;
        }

        if (null != trackedRightHandSource) {
            trackedParts.RightHandTransform.position = trackedRightHandSource.transform.position;
            trackedParts.RightHandTransform.rotation = trackedRightHandSource.transform.rotation;
            rightHandIKTarget.transform.SetPositionAndRotation(trackedRightHandSource.transform.position, trackedRightHandSource.transform.rotation * Quaternion.Euler(trackedParts.RightHandOffset.rotation));
            rightHandIKTarget.transform.localPosition += trackedRightHandSource.transform.localRotation * trackedParts.RightHandOffset.position;
        }
    }


    /// <summary>
    /// Updates the head root rotation.
    /// </summary>
    /// <remarks>This is done in LateUpdate to override animation.</remarks>
    private void LateUpdate() {
        // Set the head rotation. Note: The position is set indirectly by setting the AvatarRoot position.
        if (null != trackedHeadSource) {
            trackedParts.HeadRoot.rotation = trackedHeadSource.rotation * headOriginalRotation;
        }
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
