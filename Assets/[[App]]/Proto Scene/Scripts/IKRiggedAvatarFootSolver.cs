using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

/// <summary>
/// This component uses IK rigged legs to make the feet walk.
/// </summary>
public class IKRiggedAvatarFootSolver : MonoBehaviour {

    #region Interface Variables

    /// <summary>The body of the IK rig.</summary>
    [Tooltip("The body of the IK rig.")]
    [SerializeField] Transform body;

    /// <summary>The other foot.</summary>
    [Tooltip("The other foot.")]
    [SerializeField] IKRiggedAvatarFootSolver otherFoot;

    /// <summary>The base step speed.</summary>
    [Tooltip("The base step speed.")]
    [SerializeField] float footSpeed = 2;

    /// <summary>Step height.</summary>
    [Tooltip("Step height.")]
    [SerializeField] float stepHeight = 0.3f;

    /// <summary>A speed multiplier applied according to step distance.</summary>
    [Tooltip("A speed multiplier applied according to step distance.")]
    [SerializeField] float stepDistanceSpeedMultiplier = 0.4f;

    /// <summary>The foot offsets.</summary>
    [Tooltip("The foot offsets.")]
    [SerializeField] protected TrackedParts.PlatformPhysicalOffset offsets;

    #endregion



    #region Class Variables

    /// <summary>The lateral space between the feet.</summary>
    float footSpacing;

    /// <summary>The current step progression, from 0 to 1.</summary>
    float currentStepProgression;

    /// <summary>The previous foot position, when stepping.</summary>
    Vector3 oldFootPosition;

    /// <summary>The current foot position.</summary>
    Vector3 currentFootPosition;

    /// <summary>The target foot position, when stepping.</summary>
    Vector3 newFootPosition;

    /// <summary>The old foot normal, when stepping.</summary>
    Vector3 oldFootNormal;

    /// <summary>The current foot normal.</summary>
    Vector3 currentFootNormal;

    /// <summary>The target foot normal, when stepping.</summary>
    Vector3 newFootNormal;

    /// <summary>Position of the last raycast.</summary>
    /// <remarks>This is at a class level because it is used by OnDrawGizmos</remarks>
    Vector3 raycastPos = Vector3.zero;

    /// <summary>The last body position, when stepping.</summary>
    Vector3 lastBodyPosition;

    /// <summary>The last time the step speed was computed.</summary>
    float lastSpeedUpdateTime;

    /// <summary>The current speed of the body, in meters per second.</summary>
    float bodySpeedMetersPerSecond;

    /// <summary>The last time this foot stepped.</summary>
    float lastStepTime = float.MinValue;

    /// <summary>Minimum time between steps.</summary>
    float minStepTime = 1f;

    /// <summary>Returns whether or not the foot is stepping.</summary>
    protected bool IsMoving { get { return currentStepProgression < 1; } }

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes values.
    /// </summary>
    /// <returns>Coroutine</returns>
    IEnumerator Start() {
        lastBodyPosition = body.position;
        footSpacing = transform.localPosition.x;
        currentStepProgression = 1;
        Ray ray = new Ray(body.position + (body.right * footSpacing) + (Vector3.up * 2), Vector3.down);
        int layerMask = ~LayerMask.GetMask("LocalPlayer", "HandPlayer", "Hand");

        // I don't know why, but the feet won't initialize correctly for the local avatar unless this delay
        // is done.
        for (int i = 0; i < 20; ++i) {
            yield return null;
        }

        // Position and rotate the feet to the ground.
        if (Physics.Raycast(ray, out RaycastHit hit, 10, layerMask)) {
            currentFootPosition = newFootPosition = oldFootPosition = hit.point;
            currentFootNormal = newFootNormal = oldFootNormal = hit.normal;
        }
        else {
            currentFootPosition = newFootPosition = oldFootPosition = transform.position;
            currentFootNormal = newFootNormal = oldFootNormal = transform.up;
        }
    }


    /// <summary>
    /// Handles stepping the foot.
    /// </summary>
    void LateUpdate() {
        float speedUpdateTimeSeconds = 0.25f;

        if (Time.time - lastSpeedUpdateTime > speedUpdateTimeSeconds) {
            lastSpeedUpdateTime = Time.time;
            bodySpeedMetersPerSecond = (body.position - lastBodyPosition).magnitude / speedUpdateTimeSeconds;
            lastBodyPosition = body.position;
        }

        // Override any transform inheritance and set the foot transform.
        transform.position = currentFootPosition + offsets.Offset.position;
        if (currentFootNormal != Vector3.zero) {
            transform.localRotation = Quaternion.LookRotation(currentFootNormal) * Quaternion.Euler(offsets.Offset.rotation);
        }

        // If both feet are still...
        if (!IsMoving && !otherFoot.IsMoving) {

            // If this foot is on the wrong side of the body, then move it.
            Vector3 localFootPos = body.InverseTransformPoint(transform.position);
            Vector3 localOtherFootPos = body.InverseTransformPoint(otherFoot.transform.position);
            float localFootDistance = localFootPos.magnitude;
            float otherFootDistance = localOtherFootPos.magnitude;
            float maxUnderBodyDeltaX = 0.2f;
            float maxUnderBodyDeltaZ = 0.2f;
            if (((footSpacing > 0) && (localFootPos.x < 0)) || ((footSpacing < 0) && (localFootPos.x > 0))) {
                currentStepProgression = 0;
            }

            // Otherwise, if this foot is not under the body...
            else if ((Mathf.Abs(localFootPos.x) > maxUnderBodyDeltaX) || (Mathf.Abs(localFootPos.z) > maxUnderBodyDeltaZ)) {
                // If this foot is the furthest foot, then move it.
                if ((localFootDistance >= otherFootDistance) && (Time.time - lastStepTime > minStepTime)) {
                    currentStepProgression = 0;
                }
            }
        }
        if (currentStepProgression == 0) {
            lastStepTime = Time.time;
        }

        // If the foot is moving, move the foot.
        if (currentStepProgression < 1) {
            // Compute the step length.
            float speedAdjustedStepLength = bodySpeedMetersPerSecond * stepDistanceSpeedMultiplier;

            // Compute the move direction.
            Vector3 moveDir = (body.position - lastBodyPosition).normalized;
            if (moveDir != Vector3.zero) {

                // Compute the new foot position.
                raycastPos = body.position + (moveDir * speedAdjustedStepLength) + (body.right * (footSpacing * 1f)) + (Vector3.up * 2);
                Ray ray = new Ray(raycastPos, Vector3.down);
                int layerMask = ~LayerMask.GetMask("LocalPlayer", "HandPlayer", "Hand");
                if (Physics.Raycast(ray, out RaycastHit hit, 10, layerMask)) {
                    newFootPosition = hit.point;
                    newFootNormal = hit.normal;
                }
            }


            float lerpval = currentStepProgression * currentStepProgression;
            Vector3 pos = Vector3.Lerp(oldFootPosition, newFootPosition, lerpval);
            pos.y += Mathf.Sin(currentStepProgression * Mathf.PI) * stepHeight;

            currentFootPosition = pos;
            currentFootNormal = Vector3.Lerp(oldFootNormal, newFootNormal, lerpval);
            currentStepProgression += Time.deltaTime * footSpeed;
        }

        // If the movement has completed, update the old foot position.
        if (currentStepProgression > 1) {
            oldFootPosition = newFootPosition;
            oldFootNormal = newFootNormal;
        }

    }

    #endregion



    #region Public Methods


    public float GetStepProgression() {
        return currentStepProgression;
    }

    public Vector3 GetFootTargetPosition() {
        return newFootPosition;
    }



    /// <summary>
    /// Callback called upon teleport.
    /// </summary>
    /// <returns></returns>
    public async UniTask OnTeleport() {
        // Allow the teleport to occur.
        await UniTask.DelayFrame(1);
        raycastPos = body.position + (body.right * (footSpacing * 1f)) + (Vector3.up * 2);
        Ray ray = new Ray(raycastPos, Vector3.down);
        int layerMask = ~LayerMask.GetMask("LocalPlayer", "HandPlayer", "Hand");
        if (Physics.Raycast(ray, out RaycastHit hit, 10, layerMask)) {
            currentFootPosition = oldFootPosition = newFootPosition = hit.point;
            currentFootNormal = oldFootNormal = newFootNormal = hit.normal;
        }
        else {
            currentFootPosition = body.position + (body.right * (footSpacing * 1f));
            currentFootNormal = Vector3.up;
        }
        currentStepProgression = 1.1f;
    }

    #endregion



    #region Editor Methods

    /// <summary>
    /// Draws gizmos.
    /// </summary>
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(raycastPos, 0.1f);
    }

    #endregion

}
