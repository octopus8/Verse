using Mirror;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected RuntimeAnimatorController runtimeAnimatorController;

    [SerializeField] protected bool localTest = false;


    void Start()
    {
        // Create the actor.
        GameObject spawned = Instantiate(prefab, transform);

        // Set the actor root.
        IKRiggedAvatar riggedAvatar = spawned.GetComponent<IKRiggedAvatar>();
        riggedAvatar.AvatarRoot = transform;

        // Set the animation controller.
        Animator animator = spawned.GetComponent<Animator>();
        animator.runtimeAnimatorController = runtimeAnimatorController;

        // Add and initialize the arm controller.
        IKRiggedArmAnimationController armController = spawned.AddComponent<IKRiggedArmAnimationController>();
        armController.SetFootSolvers(riggedAvatar.LeftFootSolver, riggedAvatar.RightFootSolver);

        // If server (or local test), then add a controller.
        NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
        if (localTest || networkIdentity.isServer) {
            NPCController controller = spawned.AddComponent<NPCController>();
            controller.RootTransform = transform;
        }

    }

}
