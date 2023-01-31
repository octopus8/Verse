using System;
using UnityEngine;

namespace O8C {


    public abstract class O8CAppFocusState : MonoBehaviour, IO8CAppFocusState {

        abstract public void AddOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer);

        abstract public IO8CAppFocusState.VisibilityState GetCurrentVisibilityState();

        abstract public IO8CAppFocusState.XRState GetCurrentXRState();

        abstract public void RemoveOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer);
    }


}
