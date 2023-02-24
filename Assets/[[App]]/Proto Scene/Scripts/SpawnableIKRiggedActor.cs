using Mirror;
using UnityEngine;


/// <summary>
/// 
/// </summary>
/// <remarks>
/// * This component is part of the prefab instantiated by a Spawner.
/// </remarks>
public class SpawnableIKRiggedActor : MonoBehaviour
{

    #region Interface Variables

    /// <summary>The actor prefab.</summary>
    [Tooltip("The actor prefab.")]
    [SerializeField] protected GameObject actorPrefab;

    /// <summary>The animation controller to use for the actor.</summary>
    [Tooltip("The animation controller to use for the actor.")]
    [SerializeField] protected RuntimeAnimatorController runtimeAnimatorController;

    /// <summary>NPC controller prefab.</summary>
    [SerializeField] protected NPCController controllerPrefab;

    /// <summary>Flag indicating the spawnable is a local test.</summary>
    [SerializeField] protected bool localTest = false;

    #endregion



    /// <summary>
    /// Instanitates and initializes the actor.
    /// </summary>
    void Start()
    {
        // Create the actor.
        GameObject spawned = Instantiate(actorPrefab, transform);

        // Set the actor root.
        IKRiggedActor riggedAvatar = spawned.GetComponent<IKRiggedActor>();
        riggedAvatar.AvatarRoot = transform;

        // Add and initialize the arm controller.
        IKRiggedArmAnimationController armController = spawned.AddComponent<IKRiggedArmAnimationController>();
        armController.SetFootSolvers(riggedAvatar.LeftFootSolver, riggedAvatar.RightFootSolver);
        armController.SetAnimationController(runtimeAnimatorController);

        // If server (or local test), then add a controller.
        NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
        if (localTest || networkIdentity.isServer) {
            NPCControllerCircle controllerInstance = Instantiate(controllerPrefab.gameObject, spawned.transform).GetComponent<NPCControllerCircle>();
            controllerInstance.RootTransform = transform;
        }
    }

}
