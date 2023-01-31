using System;
using UnityEngine;

namespace O8C {

    /// <summary>
    /// Parent class for IO8CAppFocusState MonoBehaviour implementations.
    /// </summary>
    /// <remarks>
    /// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
    /// </remarks>
    public abstract class O8CAppFocusState : MonoBehaviour, IO8CAppFocusState {

        /** {@inheritdoc} */
        abstract public void AddOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer);


        /** {@inheritdoc} */
        abstract public IO8CAppFocusState.VisibilityState GetCurrentVisibilityState();


        /** {@inheritdoc} */
        abstract public IO8CAppFocusState.XRState GetCurrentXRState();


        /** {@inheritdoc} */
        abstract public void RemoveOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer);

    }

}
