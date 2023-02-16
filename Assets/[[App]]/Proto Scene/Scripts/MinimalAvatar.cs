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

    /// <summary>The required RiggedParts component.</summary>
    protected TrackedParts riggedParts;

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

    #endregion



    #region Base Methods

    /// <summary>
    /// Caches references.
    /// </summary>
    private void Awake() {
        riggedParts = GetComponent<TrackedParts>();
    }


    /// <summary>
    /// Caches references and initializes offset transforms.
    /// </summary>
    /// <remarks>
    /// Offsets are set. These may need to be set on a platform basis.
    /// </remarks>
    private void Start() {

        leftHandOffset = riggedParts.LeftHandTransform.GetChild(0);
        rightHandOffset = riggedParts.RightHandTransform.GetChild(0);

        leftHandOffset.localPosition = riggedParts.LeftHandOffset.position;
        rightHandOffset.localPosition = riggedParts.RightHandOffset.position;
    }


    /// <summary>
    /// Updates rigged part transforms, and the body joint rotation.
    /// </summary>
    private void FixedUpdate() {
        if (null != trackedHeadSource) {
            bodyJoint.transform.rotation = Quaternion.Euler(0, trackedHeadSource.rotation.eulerAngles.y, 0);
            riggedParts.HeadRoot.SetPositionAndRotation(trackedHeadSource.position, trackedHeadSource.rotation);
        }
        if (null != trackedRightHandSource) {
//            rightHandOffset.localPosition = riggedParts.RightHandOffset.position;     // TEST
            riggedParts.RightHandTransform.SetPositionAndRotation(trackedRightHandSource.transform.position, trackedRightHandSource.transform.rotation * Quaternion.Euler(riggedParts.RightHandOffset.rotation));
        }
        if (null != trackedLeftHandSource) {
//            leftHandOffset.localPosition = riggedParts.LeftHandOffset.position;       // TEST
            riggedParts.LeftHandTransform.SetPositionAndRotation(trackedLeftHandSource.transform.position, trackedLeftHandSource.transform.rotation * Quaternion.Euler(riggedParts.LeftHandOffset.rotation));
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
