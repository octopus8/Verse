using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldPointerNetworking))]
[RequireComponent(typeof(WorldPointerVisibility))]
public class WorldPointer : MonoBehaviour
{
    public bool IsLocalPlayer { set {
            WorldPointerNetworking worldPointerNetworking = GetComponent<WorldPointerNetworking>();
            WorldPointerVisibility worldPointerVisibility = GetComponent<WorldPointerVisibility>();
            worldPointerNetworking.IsLocalPlayer = value;
            worldPointerVisibility.IsLocalPlayer = value;
        }
    }

}
