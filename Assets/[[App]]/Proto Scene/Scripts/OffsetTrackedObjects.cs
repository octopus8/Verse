using System;
using UnityEngine;



/// <summary>
/// Provides access to avatar parts.
/// </summary>
public class OffsetTrackedObjects : MonoBehaviour {

    #region Inspector Variables

    /// <summary>The head GameObject.</summary>
    [SerializeField] protected GameObject headRoot;

    /// <summary>The head offsets.</summary>
    [SerializeField] protected PlatformPhysicalOffset headOffsets;

    /// <summary>The left hand GameObject.</summary>
    [SerializeField] protected GameObject leftHandRoot;

    /// <summary>The left hand renderer.</summary>
    [SerializeField] protected Renderer leftHandRenderer;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected PlatformPhysicalOffset leftHandOffsets;

    /// <summary>The right hand GameObject.</summary>
    [SerializeField] protected GameObject rightHandRoot;

    /// <summary>The right hand renderer.</summary>
    [SerializeField] protected Renderer rightHandRenderer;

    /// <summary>The right hand offsets.</summary>
    [SerializeField] protected PlatformPhysicalOffset rightHandOffsets;

    /// <summary>The body joint GameObject.</summary>
    [SerializeField] protected GameObject bodyJoint;

    #endregion



    #region Accessors

    /// <summary>Accessor for the head root transform.</summary>
    public GameObject HeadRoot { get { return headRoot; } }

    /// <summary>Accessor for the left hand root transform.</summary>
    public GameObject LeftHandRoot { get { return leftHandRoot; } }

    /// <summary>Accessor for the left hand renderer.</summary>
    public Renderer LeftHandRenderer { get { return leftHandRenderer; } }

    /// <summary>Accessor for the right hand root transform.</summary>
    public GameObject RightHandRoot { get { return rightHandRoot; } }

    /// <summary>Accessor for the right hand renderer.</summary>
    public Renderer RightHandRenderer { get { return leftHandRenderer; } }

    /// <summary>Accessor for the body joint GameObject.</summary>
    public GameObject BodyJoint { get { return bodyJoint; } }

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes avatar parts.
    /// </summary>
    /// <remarks>
    /// Offsets are set. These may need to be set on a platform basis.
    /// </remarks>
    private void Start() {
#if UNITY_WEBGL
        SetLeftHandOffset(leftHandOffsets.webXR.position, leftHandOffsets.webXR.rotation);
        SetRightHandOffset(rightHandOffsets.webXR.position, rightHandOffsets.webXR.rotation);
#else
            SetLeftHandOffset(leftHandOffsets.oculus.position, leftHandOffsets.oculus.rotation);
            SetRightHandOffset(rightHandOffsets.oculus.position, rightHandOffsets.oculus.rotation);
#endif
    }


    /// <summary>
    /// Updates the body joint.
    /// </summary>
    private void Update() {
        bodyJoint.transform.rotation = Quaternion.Euler(0, headRoot.transform.rotation.eulerAngles.y, 0);
    }

    #endregion



    #region Private Methods

    /// <summary>
    /// Sets the offset from tracking for the left hand.
    /// </summary>
    /// <param name="pos">Positional offset.</param>
    /// <param name="rotation">Rotational offset.</param>
    private void SetLeftHandOffset(Vector3 pos, Vector3 rotation) {
        Transform offset = leftHandRoot.transform.GetChild(0);
        offset.localPosition = pos;
        offset.localRotation = Quaternion.Euler(rotation);
    }


    /// <summary>
    /// Sets the offset from tracking for the right hand.
    /// </summary>
    /// <param name="pos">Positional offset.</param>
    /// <param name="rotation">Rotational offset.</param>
    private void SetRightHandOffset(Vector3 pos, Vector3 rotation) {
        Transform offset = rightHandRoot.transform.GetChild(0);
        offset.localPosition = pos;
        offset.localRotation = Quaternion.Euler(rotation);
    }

    #endregion


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
