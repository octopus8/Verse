using UnityEngine;



/// <summary>
/// This component synchronizes minimal avatar rigged part transforms with tracked part transforms.
/// </summary>
[RequireComponent(typeof(TrackedParts))]
public class MinimalAvatar : MonoBehaviour {

    #region Inspector Variables

    /// <summary>The body joint GameObject.</summary>
    [SerializeField] protected GameObject bodyJoint;

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

    #endregion



    #region Base Methods

    /// <summary>
    /// Caches references.
    /// </summary>
    private void Awake() {
        trackedParts = GetComponent<TrackedParts>();
    }


    /// <summary>
    /// Updates rigged part transforms, and the body joint rotation.
    /// </summary>
    private void FixedUpdate() {
        if (null != trackedHeadSource) {
            bodyJoint.transform.rotation = Quaternion.Euler(0, trackedHeadSource.rotation.eulerAngles.y, 0);
            trackedParts.HeadRoot.SetPositionAndRotation(trackedHeadSource.position, trackedHeadSource.rotation);
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
