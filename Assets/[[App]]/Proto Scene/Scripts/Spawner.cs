using Mirror;
using UnityEngine;

public class Spawner : NetworkBehaviour {

    [SerializeField] GameObject npcPrefab;

    void Start() {
        if (isServer) {
            GameObject npc = Instantiate(npcPrefab);
            npc.transform.SetPositionAndRotation(transform.position, transform.rotation);
            NetworkServer.Spawn(npc);
        }
    }


}
