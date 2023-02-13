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
        offsetObject.transform.localPosition = new Vector3(0, -1.7f, 0);
        offsetObject.transform.parent = avatarBaseObject.transform;

        GameObject avatar = Instantiate(avatarPrefab, offsetObject.transform);

        networkPlayer.AddHeadFollower(avatarBaseObject);




            return avatar;
    }


}
