using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O8CAvatarParts : MonoBehaviour
{
    [SerializeField] protected GameObject head;
    [SerializeField] protected GameObject leftHand;
    [SerializeField] protected GameObject rightHand;

    public GameObject Head { get { return head; } }
    public GameObject LeftHand { get { return leftHand; } }
    public GameObject RightHand { get { return rightHand; } }


    /// <summary>
    /// Initializes avatar parts.
    /// </summary>
    /// <remarks>
    /// Offsets are set. These may need to be set on a platform basis.
    /// </remarks>
    private void Start() {
        SetLeftHandOffset(new Vector3(-0.03f, -0.03f, -0.06f), new Vector3(-90, 90, 0));
        SetRightHandOffset(new Vector3(0.03f, -0.03f, -0.06f), new Vector3(-90, -90, 0));
    }

    private void SetLeftHandOffset(Vector3 pos, Vector3 rotation) {
        Transform offset = leftHand.transform.GetChild(0);
        offset.localPosition = pos;
        offset.localRotation = Quaternion.Euler(rotation);
    }

    private void SetRightHandOffset(Vector3 pos, Vector3 rotation) {
        Transform offset = rightHand.transform.GetChild(0);
        offset.localPosition = pos;
        offset.localRotation = Quaternion.Euler(rotation);
    }



}
