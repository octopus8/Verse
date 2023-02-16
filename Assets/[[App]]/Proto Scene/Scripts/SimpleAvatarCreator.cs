using O8C;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAvatarCreator : AvatarCreator {

    #region Inspector Variables

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected MinimalAvatar avatarPrefab;

    #endregion


    public override GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer) {

        MinimalAvatar avatar = Instantiate(avatarPrefab, player.transform);

        avatar.SetTrackedObjects(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());

        return avatar.gameObject;
    }

}
