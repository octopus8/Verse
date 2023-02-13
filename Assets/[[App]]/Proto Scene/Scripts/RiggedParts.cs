using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static O8C.O8CActorParts;

public class RiggedParts : MonoBehaviour
{
    [SerializeField] protected GameObject head;

    [SerializeField] protected Vector3 headOffset;

    [SerializeField] protected GameObject leftHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected PlatformOffset leftHandOffsets;

    [SerializeField] protected GameObject rightHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected PlatformOffset rightHandOffsets;


    public GameObject Head { get { return head; } }

    public GameObject LeftHand { get { return leftHand; } }

    public GameObject RightHand { get { return rightHand; } }

    public Offset LeftHandOffset { get {
#if UNITY_WEBGL
            return leftHandOffsets.webXR;
#else
            return leftHandOffsets.oculus;
#endif
        } }

    public Offset RightHandOffset { get {
#if UNITY_WEBGL
            return rightHandOffsets.webXR;
#else
            return rightHandOffsets.oculus;
#endif
        }
    }

    public Vector3 HeadOffset { get { return headOffset; } }

}
