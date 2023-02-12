using UnityEngine;

public interface IAvatarCreator 
{
    public GameObject CreateAvatar(GameObject player, bool isLocalPlayer);

}
