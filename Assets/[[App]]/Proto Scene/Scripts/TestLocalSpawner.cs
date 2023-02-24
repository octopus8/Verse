using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLocalSpawner : MonoBehaviour
{
    [SerializeField] GameObject npcPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject npc = Instantiate(npcPrefab);
        npc.transform.position = transform.position;
        npc.transform.rotation = transform.rotation;
    }
}
