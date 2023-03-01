using UnityEngine;


/// <summary>
/// World pointer manager.
/// </summary>
/// <remarks>
/// Upon start, pointer elements are initialized.
/// </remarks>
[RequireComponent(typeof(WorldPointerVisibility))]
public class WorldPointer : MonoBehaviour
{
    #region Class Variables

    /// <summary>The required WorldPointerVisibility component.</summary>
    protected WorldPointerVisibility worldPointerVisibility;

    /// <summary>The WorldPointerNetworking in the parent network object.</summary>
    protected WorldPointerNetworking worldPointerNetworking;

    #endregion



    #region Accessors

    /// <summary>Provides access to setting the local player flag.</summary>
    public bool IsLocalPlayer { private get; set; }

    /// <summary>Provides access to setting the RootTransform.</summary>
    public Transform RootTransform { private get; set; }

    #endregion


    /// <summary>
    /// Initializes WorldPointerVisibility and WorldPointerNetworking values.
    /// </summary>
    private void Start() {
        // Initialize WorldPointerVisibility values.
        worldPointerVisibility = GetComponent<WorldPointerVisibility>();
        worldPointerVisibility.IsLocalPlayer = IsLocalPlayer;
        worldPointerVisibility.RootTransform = RootTransform;

        // Initialize WorldPointerNetworking values.
        worldPointerNetworking = GetComponentInParent<WorldPointerNetworking>();
        worldPointerNetworking.WorldPointerVisibility = worldPointerVisibility;
        worldPointerNetworking.IsLocalPlayer = IsLocalPlayer;
    }

}
