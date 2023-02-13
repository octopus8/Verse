using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKRiggedAvatar : MonoBehaviour
{
    RiggedParts riggedParts;


    public void SetRiggedParts(RiggedParts parts) {
        riggedParts = parts;
    }


    private void FixedUpdate() {
        float yRot = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, yRot, 0f);

        // BLEE Note: NOT WORKING
//        riggedParts.Head.transform.localRotation = Quaternion.identity;

    }
}
