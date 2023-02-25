using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldPointerNetworking))]
[RequireComponent(typeof(WorldPointerVisibility))]
public class WorldPointer : MonoBehaviour
{
    WorldPointerNetworking worldPointerNetworking;
    WorldPointerVisibility worldPointerVisibility;

    private void Awake() {
        worldPointerNetworking = GetComponent<WorldPointerNetworking>();
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
    }

    public bool IsLocalPlayer { set {
            worldPointerNetworking.IsLocalPlayer = value;
            worldPointerVisibility.IsLocalPlayer = value;
        }
    }

}
