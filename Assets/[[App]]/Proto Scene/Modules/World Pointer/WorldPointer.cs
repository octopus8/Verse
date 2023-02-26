using Mirror;
using UnityEngine;

[RequireComponent(typeof(WorldPointerVisibility))]
[RequireComponent(typeof(WorldPointerNetworking))]

public class WorldPointer : MonoBehaviour
{
    WorldPointerNetworking worldPointerNetworking;
    WorldPointerVisibility worldPointerVisibility;

    public bool IsLocalPlayer { private get; set; }

    private void Start() {
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
        worldPointerNetworking = GetComponent<WorldPointerNetworking>();
        worldPointerNetworking.IsLocalPlayer = IsLocalPlayer;
        worldPointerVisibility.IsLocalPlayer = IsLocalPlayer;
    }

}
