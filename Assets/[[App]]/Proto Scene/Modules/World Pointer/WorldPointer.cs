using Mirror;
using UnityEngine;

[RequireComponent(typeof(WorldPointerVisibility))]

public class WorldPointer : MonoBehaviour
{
    WorldPointerVisibility worldPointerVisibility;
    WorldPointerNetworking worldPointerNetworking;

    public bool IsLocalPlayer { private get; set; }

    public Transform RootTransform { private get; set; }



    private void Start() {
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
        worldPointerVisibility.IsLocalPlayer = IsLocalPlayer;
        worldPointerVisibility.RootTransform = RootTransform;

//        worldPointerNetworking = GetComponent<WorldPointerNetworking>();
        worldPointerNetworking = GetComponentInParent<WorldPointerNetworking>();
        worldPointerNetworking.WorldPointerVisibility = worldPointerVisibility;
        worldPointerNetworking.IsLocalPlayer = IsLocalPlayer;
    }

}
