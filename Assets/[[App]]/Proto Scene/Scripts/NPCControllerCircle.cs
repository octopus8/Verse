using System;
using UnityEngine;


/// <summary>
/// NPC controller that walks the NPC in a circle.
/// </summary>
/// <remarks>
/// * This component is only added to the server NPC.
/// * The Y position of the NPC is set using the average foot Y position.
/// </remarks>
public class NPCControllerCircle : NPCController {

    #region Class Variables

    /// <summary>Radius of the circle.</summary>
    const float circleRadiusUnits = 5.0f;

    /// <summary>Rotation speed, in rotations per second.</summary>
    const float speedRotationsPerSecond = 0.03f;

    /// <summary>NPC start position (the center of the circle).</summary>
    Vector3 startPosition;

    /// <summary>The rigged avatar.</summary>
    IKRiggedActor riggedAvatar;

    /// <summary>How fast the NPC moves along the Y axis, in units per second.</summary>
    float crouchSpeed = 5.0f;

    /// <summary>The Y offset, so the NPC isn't walking at full height.</summary>
    float serverCrouchDistance = 0.02f;

    /// <summary>The NPC root transform.</summary>
    public Transform RootTransform { private get; set; }

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes values and caches references.
    /// </summary>
    private void Awake() {
        RootTransform = transform;
        riggedAvatar = transform.parent.GetComponent<IKRiggedActor>();
    }


    /// <summary>
    /// Initializes values.
    /// </summary>
    void Start() {
        startPosition = transform.position;
    }


    /// <summary>
    /// Update the NPC position.
    /// </summary>
    void Update() {
        // Rotate a vector to compute the position.
        Vector3 offset = new Vector3(0, 0, circleRadiusUnits);
        float yRot = Time.time * speedRotationsPerSecond;
        yRot = (yRot - (float)Math.Truncate(yRot)) * 360.0f;
        offset = Quaternion.Euler(0, yRot, 0) * offset;
        Vector3 pos = startPosition + offset;

        // Compute the Y position.
        pos.y = (riggedAvatar.LeftFootSolver.FootTargetPosition.y + riggedAvatar.RightFootSolver.FootTargetPosition.y) * 0.5f;
        pos.y = Mathf.Lerp(transform.position.y, pos.y, Mathf.Clamp(Time.deltaTime * crouchSpeed, 0, 1)) - serverCrouchDistance;

        // Set the root position.
        RootTransform.position = pos;
    }

    #endregion
}
