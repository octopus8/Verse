using O8C;
using UnityEngine;


public class MinimalAvatarCreator : AvatarCreator {

    #region Inspector Variables

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected MinimalAvatar avatarPrefab;

    #endregion


    public override GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer) {

        MinimalAvatar minimalAvatar = Instantiate(avatarPrefab, player.transform);

        minimalAvatar.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());

        return minimalAvatar.gameObject;
    }

}
