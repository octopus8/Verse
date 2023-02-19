using O8C;
using UnityEngine;

/// <summary>
/// Avatar factory for a minimal avatar.
/// </summary>
public class MinimalAvatarFactory : AvatarFactory {

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected MinimalAvatar avatarPrefab;



    /// <inheritdoc />
    public override GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer) {

        MinimalAvatar minimalAvatar = Instantiate(avatarPrefab, player.transform);
        minimalAvatar.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());
        return minimalAvatar.gameObject;
    }

}
