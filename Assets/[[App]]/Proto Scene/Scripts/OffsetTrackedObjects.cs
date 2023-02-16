using System;
using UnityEngine;
using O8C;


/// <summary>
/// Provides access to avatar parts.
/// </summary>
/// <remarks>
/// This component ASSUMES the GameObject this is attached to has a single child object which is used as the offset.
/// </remarks>
[RequireComponent(typeof(RiggedParts))]
public class OffsetTrackedObjects : MonoBehaviour {

    #region Inspector Variables

    /// <summary>The body joint GameObject.</summary>
    [SerializeField] protected GameObject bodyJoint;

    #endregion

    protected Transform trackedHead;
    protected Transform trackedLeftHand;
    protected Transform trackedRightHand;




    protected RiggedParts riggedParts;

    protected Transform leftHandOffset;
    protected Transform rightHandOffset;


    public RiggedParts RiggedParts { get { return riggedParts; } }

    private void Awake() {
        riggedParts = GetComponent<RiggedParts>();
    }



    #region Base Methods

    /// <summary>
    /// Initializes avatar parts.
    /// </summary>
    /// <remarks>
    /// Offsets are set. These may need to be set on a platform basis.
    /// </remarks>
    private void Start() {

        leftHandOffset = riggedParts.LeftHand.transform.GetChild(0);
        rightHandOffset = riggedParts.RightHand.transform.GetChild(0);

        SetLeftHandOffset(riggedParts.LeftHandOffset.position, riggedParts.LeftHandOffset.rotation);
        SetRightHandOffset(riggedParts.RightHandOffset.position, riggedParts.RightHandOffset.rotation);
    }


    /// <summary>
    /// Updates the body joint.
    /// </summary>
    private void FixedUpdate() {
        if (null != trackedHead) {
            bodyJoint.transform.rotation = Quaternion.Euler(0, trackedHead.rotation.eulerAngles.y, 0);
            riggedParts.Head.transform.SetPositionAndRotation(trackedHead.position, trackedHead.rotation);
        }

        if (null != trackedRightHand) {
            SetRightHandOffset(riggedParts.RightHandOffset.position, riggedParts.RightHandOffset.rotation); // TEST
            riggedParts.RightHand.transform.SetPositionAndRotation(trackedRightHand.transform.position, trackedRightHand.transform.rotation * Quaternion.Euler(riggedParts.RightHandOffset.rotation));
        }

        if (null != trackedLeftHand) {
            SetLeftHandOffset(riggedParts.LeftHandOffset.position, riggedParts.LeftHandOffset.rotation);    // TEST
            riggedParts.LeftHand.transform.SetPositionAndRotation(trackedLeftHand.transform.position, trackedLeftHand.transform.rotation * Quaternion.Euler(riggedParts.LeftHandOffset.rotation));
        }

    }

    #endregion



    #region Private Methods

    /// <summary>
    /// Sets the offset from tracking for the left hand.
    /// </summary>
    /// <param name="pos">Positional offset.</param>
    /// <param name="rotation">Rotational offset.</param>
    private void SetLeftHandOffset(Vector3 pos, Vector3 rotation) {
        leftHandOffset.localPosition = pos;
//        leftHandOffset.localRotation = Quaternion.Euler(rotation);
    }


    /// <summary>
    /// Sets the offset from tracking for the right hand.
    /// </summary>
    /// <param name="pos">Positional offset.</param>
    /// <param name="rotation">Rotational offset.</param>
    private void SetRightHandOffset(Vector3 pos, Vector3 rotation) {
        rightHandOffset.localPosition = pos;
//        rightHandOffset.localRotation = Quaternion.Euler(rotation);
    }




    #endregion


    public void SetTrackedObjects(Transform head, Transform leftHand, Transform rightHand) {
        trackedHead = head;
        trackedLeftHand = leftHand;
        trackedRightHand = rightHand;
    }



    [Serializable]
    public struct PlatformPhysicalOffset {
        public PhysicalOffset webXR;
        public PhysicalOffset oculus;
    }

    [Serializable]
    public struct PhysicalOffset {
        public Vector3 position;
        public Vector3 rotation;
    }



}
