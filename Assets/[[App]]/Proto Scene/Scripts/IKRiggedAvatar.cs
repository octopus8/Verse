using O8C;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This component synchronizes IK rigged avatar rigged part transforms with tracked part transforms.
/// </summary>
[RequireComponent(typeof(TrackedParts))]
public class IKRiggedAvatar : MonoBehaviour
{

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


    private void Start() {
        Assert.IsTrue(AvatarRoot != null);
        O8CSystem.Instance.DeviceTracking.AddHeadTarget(AvatarRoot.gameObject);
    }


    private void FixedUpdate() {
        // Clear the X & Z rotations for the AvatarRoot transform.
        float yRot = AvatarRoot.rotation.eulerAngles.y;
        AvatarRoot.rotation = Quaternion.Euler(0f, yRot, 0f);

        // Set the head rotation. Note: It will be place correctly indirectly by the body tracking the head.
        if (null != trackedHeadSource) {
            trackedParts.HeadRoot.rotation = trackedHeadSource.rotation * headOriginalRotation;
        }

        if (null != trackedRightHandSource) {
            trackedParts.RightHandTransform.SetPositionAndRotation(trackedRightHandSource.transform.position, trackedRightHandSource.transform.rotation * Quaternion.Euler(trackedParts.RightHandOffset.rotation));
            trackedParts.RightHandTransform.localPosition += trackedParts.RightHandOffset.position;
        }

        if (null != trackedLeftHandSource) {
            trackedParts.LeftHandTransform.SetPositionAndRotation(trackedLeftHandSource.transform.position, trackedLeftHandSource.transform.rotation * Quaternion.Euler(trackedParts.LeftHandOffset.rotation));
            trackedParts.LeftHandTransform.localPosition += trackedParts.LeftHandOffset.position;
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

    #endregion

}
