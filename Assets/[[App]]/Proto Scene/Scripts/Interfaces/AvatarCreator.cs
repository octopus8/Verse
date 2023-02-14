using O8C;
using UnityEngine;

public abstract class AvatarCreator : MonoBehaviour, IAvatarCreator
{
    abstract public GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer);

}
