using System;
using UnityEngine;

namespace O8C {

    /// <summary>
    /// Parent class for IO8CPlayerConnection MonoBehaviour implementations.
    /// </summary>
    /// <remarks>
    /// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
    /// </remarks>
    public abstract class O8CPlayerConnection : MonoBehaviour, IO8CPlayerConnection {

        /** {@inheritdoc} */
        abstract public void AddPlayerConnectedObserver(Action<GameObject, bool> observer);

        /** {@inheritdoc} */
        abstract public void PlayerConnected(GameObject player, bool isLocalPlayer);

        /** {@inheritdoc} */
        abstract public void PlayerDisconnected(GameObject player, bool isLocalPlayer);

        /** {@inheritdoc} */
        abstract public void RemovePlayerConnectedObserver(Action<GameObject, bool> observer);

    }

}
