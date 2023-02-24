using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IKRiggedAvatar))]
public class NPCController : MonoBehaviour
{
    float distanceUnits = 5.0f;
    float speedRotationsPerSecond = 0.03f;
    Vector3 startPosition;

    IKRiggedAvatar riggedAvatar;
    float crouchSpeed = 5.0f;
    float serverCrouchDistance = 0.02f;

    public Transform RootTransform { private get; set; }

    private void Awake() {
        RootTransform = transform;
        riggedAvatar = GetComponent<IKRiggedAvatar>();
    }

    void Start() {
        startPosition = transform.position;
    }


    void Update() {
        Vector3 offset = new Vector3(0, 0, distanceUnits);
        float yRot = Time.time * speedRotationsPerSecond;
        yRot = (yRot - (float)Math.Truncate(yRot)) * 360.0f;
        offset = Quaternion.Euler(0, yRot, 0) * offset;

        Vector3 pos = startPosition + offset;

        pos.y = (riggedAvatar.LeftFootSolver.GetFootTargetPosition().y + riggedAvatar.RightFootSolver.GetFootTargetPosition().y) * 0.5f;
        pos.y = Mathf.Lerp(transform.position.y, pos.y, Mathf.Clamp(Time.deltaTime * crouchSpeed, 0, 1)) - serverCrouchDistance;

        RootTransform.position = pos;

    }

}
