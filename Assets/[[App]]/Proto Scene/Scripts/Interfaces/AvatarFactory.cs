using O8C;
using UnityEngine;



/// <summary>
/// Parent class for IAvatarFactory MonoBehaviour implementations.
/// </summary>
/// <remarks>
/// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
/// </remarks>
public abstract class AvatarFactory : MonoBehaviour, IAvatarFactory
{

    /// <inheritdoc />
    abstract public GameObject CreateAvatar(GameObject player, IO8CNetworkPlayer networkPlayer, bool isLocalPlayer);

}
