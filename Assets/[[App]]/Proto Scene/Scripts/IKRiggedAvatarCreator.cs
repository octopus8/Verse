using O8C;
using UnityEngine;

public class IKRiggedAvatarCreator : AvatarCreator {

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected GameObject avatarPrefab;


    public override GameObject CreateAvatar(GameObject player, bool isLocalPlayer) {

        var networkPlayer = player.GetComponent<IO8CNetworkPlayer>();

        GameObject avatarBaseObject = new GameObject("Avatar", typeof(IKRiggedAvatar));
        avatarBaseObject.transform.parent = player.transform;
        GameObject offsetObject = new GameObject("Offset");
        offsetObject.transform.parent = avatarBaseObject.transform;

        GameObject avatar = Instantiate(avatarPrefab, offsetObject.transform);
        RiggedParts riggedParts = avatar.GetComponent<RiggedParts>();
        offsetObject.transform.localPosition = riggedParts.HeadOffset;

        IKRiggedAvatar iKRiggedAvatar = avatarBaseObject.GetComponent<IKRiggedAvatar>();
        iKRiggedAvatar.SetRiggedParts(avatar.GetComponent<RiggedParts>());
        iKRiggedAvatar.SourceHeadTransform = networkPlayer.GetHeadTransform();

        iKRiggedAvatar.SourceLeftHandTransform = networkPlayer.GetLeftHandTransform();
        iKRiggedAvatar.SourceRightHandTransform = networkPlayer.GetRightHandTransform();

        networkPlayer.AddHeadFollower(avatarBaseObject);





        return avatar;
    }


}
