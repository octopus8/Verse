using Mirror;
using UnityEngine;


/// <summary>
/// Spawns an NPC on the server.    
/// </summary>
public class NPCSpawner : NetworkBehaviour {

    /// <summary>The NPC prefab to spawn.</summary>
    [Tooltip("The NPC prefab to spawn.")]
    [SerializeField] GameObject npcPrefab;


    /// <summary>
    /// Spawns the NPC on the server.
    /// </summary>
    void Start() {
        if (isServer) {
            GameObject npc = Instantiate(npcPrefab);
            npc.transform.SetPositionAndRotation(transform.position, transform.rotation);
            NetworkServer.Spawn(npc);
        }
    }

}
