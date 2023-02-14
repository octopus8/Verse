using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggedParts : MonoBehaviour
{
    [SerializeField] protected GameObject head;

    [SerializeField] protected Vector3 headOffset;

    [SerializeField] protected GameObject leftHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected OffsetTrackedObjects.PlatformPhysicalOffset leftHandOffsets;

    [SerializeField] protected GameObject rightHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected OffsetTrackedObjects.PlatformPhysicalOffset rightHandOffsets;


    public GameObject Head { get { return head; } }

    public GameObject LeftHand { get { return leftHand; } }

    public GameObject RightHand { get { return rightHand; } }

    public OffsetTrackedObjects.PhysicalOffset LeftHandOffset { get {
#if UNITY_WEBGL
            return leftHandOffsets.webXR;
#else
            return leftHandOffsets.oculus;
#endif
        } }

    public OffsetTrackedObjects.PhysicalOffset RightHandOffset { get {
#if UNITY_WEBGL
            return rightHandOffsets.webXR;
#else
            return rightHandOffsets.oculus;
#endif
        }
    }

    public Vector3 HeadOffset { get { return headOffset; } }

}
