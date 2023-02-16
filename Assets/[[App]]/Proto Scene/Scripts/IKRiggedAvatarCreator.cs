using O8C;
using UnityEngine;

public class IKRiggedAvatarCreator : AvatarCreator {

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected GameObject avatarPrefab;


    public override GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer) {
        /*
                // Create the avatar base objects.
                GameObject avatarRootObject = new GameObject("Avatar", typeof(IKRiggedAvatar));
                avatarRootObject.transform.parent = player.transform;
                GameObject offsetObject = new GameObject("Offset");
                offsetObject.transform.parent = avatarRootObject.transform;

                // Create the avatar.
                GameObject avatar = Instantiate(avatarPrefab, offsetObject.transform);

                // Offset the avatar by the head offset.
                TrackedParts riggedParts = avatar.GetComponent<TrackedParts>();
                offsetObject.transform.localPosition = riggedParts.HeadOffset;

                IKRiggedAvatar iKRiggedAvatar = avatarRootObject.GetComponent<IKRiggedAvatar>();
                iKRiggedAvatar.SetRiggedParts(avatar.GetComponent<TrackedParts>());
                iKRiggedAvatar.SourceHeadTransform = networkPlayer.GetHeadTransform();
                iKRiggedAvatar.SourceLeftHandTransform = networkPlayer.GetLeftHandTransform();
                iKRiggedAvatar.SourceRightHandTransform = networkPlayer.GetRightHandTransform();

                networkPlayer.AddHeadFollower(avatarRootObject);

                return avatar;
        */
        return null;
    }


}
