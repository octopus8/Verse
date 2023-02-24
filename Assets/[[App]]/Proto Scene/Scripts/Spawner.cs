using Mirror;
using UnityEngine;

public class Spawner : NetworkBehaviour {

    [SerializeField] GameObject npcPrefab;

    void Start() {
        if (isServer) {
            GameObject npc = Instantiate(npcPrefab);
            NetworkServer.Spawn(npc);
        }
    }


}
