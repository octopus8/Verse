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
        GameObject avatar = Instantiate(avatarPrefab, offsetObject.transform);

        // Offset the avatar by the head offset.
        offsetObject.transform.localPosition = avatar.GetComponent<TrackedParts>().HeadOffset;

        // Initialize the IKRiggedAvatar component.
        IKRiggedAvatar iKRiggedAvatar = avatar.GetComponent<IKRiggedAvatar>();
        iKRiggedAvatar.AvatarRoot = avatarRootObject.transform;
        iKRiggedAvatar.SetTrackedSources(networkPlayer.GetHeadTransform(), networkPlayer.GetLeftHandTransform(), networkPlayer.GetRightHandTransform());
        iKRiggedAvatar.SetIsLocalPlayer(isLocalPlayer);

        return avatar;
    }

}
