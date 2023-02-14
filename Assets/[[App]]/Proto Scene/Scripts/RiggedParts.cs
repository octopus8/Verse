using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to rigged part objects so they can be animated.
/// </summary>
public class RiggedParts : MonoBehaviour
{
    #region Interface Variables

    /// <summary>The head root transform.</summary>
    [SerializeField] protected Transform headRoot;

    /// <summary>The offset for the head.</summary>
    [SerializeField] protected Vector3 headOffset;

    /// <summary>The left hand root transform.</summary>
    [SerializeField] protected Transform leftHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected OffsetTrackedObjects.PlatformPhysicalOffset leftHandOffsets;

    /// <summary>The right hand root transform.</summary>
    [SerializeField] protected Transform rightHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected OffsetTrackedObjects.PlatformPhysicalOffset rightHandOffsets;

    #endregion



    #region Accessors

    /// <summary>Accessor for the HeadTransform.</summary>
    public Transform HeadRoot { get { return headRoot; } }

    /// <summary>Accessor for the LeftHandTransform .</summary>
    public Transform LeftHandTransform { get { return leftHand; } }

    /// <summary>Accessor for the RightHandTransform .</summary>
    public Transform RightHandTransform { get { return rightHand; } }

    /// <summary>Accessor for the LeftHandOffset values.</summary>
    public OffsetTrackedObjects.PhysicalOffset LeftHandOffset { get {
#if UNITY_WEBGL
            return leftHandOffsets.webXR;
#else
            return leftHandOffsets.oculus;
#endif
        }
    }

    /// <summary>Accessor for the RightHandOffset values.</summary>
    public OffsetTrackedObjects.PhysicalOffset RightHandOffset { get {
#if UNITY_WEBGL
            return rightHandOffsets.webXR;
#else
            return rightHandOffsets.oculus;
#endif
        }
    }

    /// <summary>Accessor for the HeadOffset.</summary>
    public Vector3 HeadOffset { get { return headOffset; } }

    #endregion

}
