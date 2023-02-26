using Mirror;
using O8C;
using UnityEngine;

/// <summary>
/// Avatar factory for an IK rigged avatar.
/// </summary>
public class IKRiggedAvatarFactory : AvatarFactory {

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected GameObject avatarPrefab;



    /// <inheritdoc />
    public override GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer) {

        // Create the avatar base objects.
        GameObject avatarRootObject = new GameObject("Avatar");
        avatarRootObject.transform.parent = player.transform;
        GameObject offsetObject = new GameObject("Offset");
        offsetObject.transform.parent = avatarRootObject.transform;

        // Create the avatar.
        GameObject avatar;

        avatar = Instantiate(avatarPrefab, offsetObject.transform);

        // Offset the avatar by the head offset.
        TrackedParts avatarTrackedParts = avatar.GetComponent<TrackedParts>();
        offsetObject.transform.localPosition = avatarTrackedParts.HeadOffset;

        // Initialize the IKRiggedAvatar component.
        IKRiggedActor iKRiggedAvatar = avatar.GetComponent<IKRiggedActor>();
        iKRiggedAvatar.AvatarRoot = avatarRootObject.transform;
        iKRiggedAvatar.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());
        iKRiggedAvatar.SetIsLocalPlayer(isLocalPlayer);

        return avatar;
    }

}
