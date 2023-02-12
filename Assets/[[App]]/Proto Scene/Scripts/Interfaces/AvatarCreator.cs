using UnityEngine;

public abstract class AvatarCreator : MonoBehaviour, IAvatarCreator
{
    abstract public GameObject CreateAvatar(GameObject player, bool isLocalPlayer);

}
