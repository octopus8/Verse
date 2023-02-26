using Mirror;
using UnityEngine;

[RequireComponent(typeof(WorldPointerVisibility))]
public class WorldPointer : MonoBehaviour
{
    WorldPointerNetworking worldPointerNetworking;
    WorldPointerVisibility worldPointerVisibility;

    private void Awake() {
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();

        GameObject networkRoot = GetComponentInParent<NetworkIdentity>().gameObject;
        worldPointerNetworking = networkRoot.AddComponent<WorldPointerNetworking>();
    }


    public bool IsLocalPlayer { set {
            worldPointerNetworking.IsLocalPlayer = value;
            worldPointerVisibility.IsLocalPlayer = value;
        }
    }

}
