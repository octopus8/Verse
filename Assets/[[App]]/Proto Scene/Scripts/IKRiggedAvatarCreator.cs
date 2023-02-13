using O8C;
using System.Collections;
using System.Collections.Generic;
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
        offsetObject.transform.localPosition = new Vector3(0, -1.569113f, 0.004839525f);
        offsetObject.transform.parent = avatarBaseObject.transform;

        GameObject avatar = Instantiate(avatarPrefab, offsetObject.transform);

        avatarBaseObject.GetComponent<IKRiggedAvatar>().SetRiggedParts(avatar.GetComponent<RiggedParts>());

        networkPlayer.AddHeadFollower(avatarBaseObject);





        return avatar;
    }


}
