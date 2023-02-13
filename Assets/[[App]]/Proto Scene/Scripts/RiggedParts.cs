using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static O8C.O8CActorParts;

public class RiggedParts : MonoBehaviour
{
    [SerializeField] protected GameObject head;
    [SerializeField] protected GameObject leftHand;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected PlatformOffset leftHandOffsets;

    /// <summary>The left hand offsets.</summary>
    [SerializeField] protected PlatformOffset rightHandOffsets;

    [SerializeField] protected GameObject rightHand;

    public GameObject Head { get { return head; } }

    public GameObject LeftHand { get { return leftHand; } }

    public GameObject RightHand { get { return rightHand; } }


}
