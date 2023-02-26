using Mirror;
using UnityEngine;

[RequireComponent(typeof(WorldPointerVisibility))]
public class WorldPointer : MonoBehaviour
{
    WorldPointerNetworking worldPointerNetworking;
    WorldPointerVisibility worldPointerVisibility;

    public bool IsLocalPlayer { private get; set; }

    private void Start() {
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
        worldPointerNetworking = GetComponentInParent<WorldPointerNetworking>();
        worldPointerNetworking.WorldPointerVisibility = worldPointerVisibility;

        worldPointerNetworking.IsLocalPlayer = IsLocalPlayer;
        worldPointerVisibility.IsLocalPlayer = IsLocalPlayer;
    }

}
