using System;
using UnityEngine;


namespace O8C {

    /// <summary>
    /// Parent class for IO8CNetwork MonoBehaviour implementations.
    /// </summary>
    /// <remarks>
    /// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
    /// </remarks>
    public abstract class O8CNetwork : MonoBehaviour, IO8CNetwork {

        /** {@inheritdoc} */
        abstract public void AddOnConnectObserver(Action observer);


        /** {@inheritdoc} */
        abstract public void AddOnDisconnectObserver(Action observer);


        /** {@inheritdoc} */
        abstract public void RemoveOnConnectObserver(Action observer);


        /** {@inheritdoc} */
        abstract public void RemoveOnDisconnectObserver(Action observer);

    }

}