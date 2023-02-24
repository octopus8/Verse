using System;
using UnityEngine;
using UnityEngine.Assertions;

public class LocalNPCTest : MonoBehaviour
{
    [SerializeField] protected RuntimeAnimatorController runtimeAnimatorController;

    float distanceUnits = 5.0f;
    float speedRotationsPerSecond = 0.03f;
    Vector3 startPosition;

    Transform rootTransform;

    private void Awake() {
#if !UNITY_EDITOR
        Assert.IsTrue(false, "LocalNPCTest found in non-editor build.");
#endif
        IKRiggedAvatar riggedAvatar = GetComponent<IKRiggedAvatar>();
        riggedAvatar.AvatarRoot = transform;
        IKRiggedArmAnimationController armController = GetComponent<IKRiggedArmAnimationController>();
        armController.SetFootSolvers(riggedAvatar.LeftFootSolver, riggedAvatar.RightFootSolver);

        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = runtimeAnimatorController;

    }

    void Start()
    {
        startPosition = transform.position;
        rootTransform = transform;
    }


    void Update()
    {
        Vector3 offset = new Vector3(0, 0, distanceUnits);
        float yRot = Time.time * speedRotationsPerSecond;
        yRot = (yRot - (float)Math.Truncate(yRot)) * 360.0f;
        offset = Quaternion.Euler(0, yRot, 0) * offset;
        rootTransform.position = startPosition + offset;
    }
}
