using O8C;
using UnityEngine;

public interface IAvatarCreator 
{
    public GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer);

}
