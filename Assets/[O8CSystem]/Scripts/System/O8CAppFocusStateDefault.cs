using System;
using UnityEngine;
using WebXR;

namespace O8C {

    /// <summary>
    /// This class provides a "Bridge" to platform specific application focus state functionality.
    /// </summary>
    public class O8CAppFocusStateDefault : O8CAppFocusState {

        #region Class Variables

        /// <summary>The current visibility state.</summary>
        protected IO8CAppFocusState.VisibilityState currentVisiblityState;

        /// <summary>The current XR state.</summary>
        protected IO8CAppFocusState.XRState currentXRState;

        #endregion



        #region Public Actions & Accessors

        /// <summary>Observers of the "visibility changed" event.</summary>
        public event Action<IO8CAppFocusState.VisibilityState> OnVisibilityChange;

        /// <summary>Observers of the "XR state changed" event.</summary>
        public event Action<IO8CAppFocusState.XRState> OnXRChange;

        /// <summary>Accessor for the current visibility state.</summary>
        public IO8CAppFocusState.VisibilityState CurrentVisiblityState { get { return currentVisiblityState; } }

        #endregion



        #region Base Methods

        /// <summary>Registers app focus callbacks.</summary>
        private void OnEnable() {
            if (O8CSystem.IsDeployedWebGL()) {
                WebXRManager.OnVisibilityChange += OnVisibilityChangeWebXR;
                WebXRManager.OnXRChange += OnXRChangeWebXR;
            }
            else {
                OVRManager.InputFocusAcquired += OnInputFocusAcquiredApp;
                OVRManager.InputFocusLost += OnInputFocusLostApp;
            }
        }


        /// <summary>Unregisters app focus callbacks.</summary>
        private void OnDisable() {
            if (O8CSystem.IsDeployedWebGL()) {
                WebXRManager.OnVisibilityChange -= OnVisibilityChangeWebXR;
                WebXRManager.OnXRChange -= OnXRChangeWebXR;
            }
            else {
                OVRManager.InputFocusAcquired -= OnInputFocusAcquiredApp;
                OVRManager.InputFocusLost -= OnInputFocusLostApp;
            }
        }

        #endregion



        #region Web Callbacks

        /// <summary>
        /// Callback called on WebXRManager.OnXRChange, the current XRState is updated and OnXRChange is invoked.
        /// </summary>
        /// <param name="state">The new WebXRState</param>
        /// <param name="viewsCount">Unused</param>
        /// <param name="leftRect">Unused</param>
        /// <param name="rightRect">Unused</param>
        private void OnXRChangeWebXR(WebXRState state, int viewsCount, Rect leftRect, Rect rightRect) {
            IO8CAppFocusState.XRState xrState;
            switch (state) {
                case WebXRState.VR:
                    xrState = IO8CAppFocusState.XRState.VR;
                    break;
                case WebXRState.AR:
                    xrState = IO8CAppFocusState.XRState.AR;
                    break;
                case WebXRState.NORMAL:
                    xrState = IO8CAppFocusState.XRState.normal;
                    break;
                default:
                    xrState = IO8CAppFocusState.XRState.unknown;
                    break;
            }

            currentXRState = xrState;
            Debug.Log("XR state changed to " + currentXRState);
            OnXRChange?.Invoke(xrState);
        }


        /// <summary>
        /// Callback called on WebXRManager.OnVisibilityChange, the current VisibilityState is updated and OnVisibilityChange is invoked.
        /// </summary>
        /// <param name="visibilityState">The new WebXRVisibilityState.</param>
        private void OnVisibilityChangeWebXR(WebXRVisibilityState visibilityState) {
            IO8CAppFocusState.VisibilityState state;
            switch (visibilityState) {
                case WebXRVisibilityState.VISIBLE:
                    state = IO8CAppFocusState.VisibilityState.visible;
                    break;
                case WebXRVisibilityState.VISIBLE_BLURRED:
                    state = IO8CAppFocusState.VisibilityState.visibleBlurred;
                    break;
                case WebXRVisibilityState.HIDDEN:
                    state = IO8CAppFocusState.VisibilityState.hidden;
                    break;
                default:
                    state = IO8CAppFocusState.VisibilityState.unknown;
                    break;
            }
            currentVisiblityState = state;
            Debug.Log("Visiblity state changed to " + currentVisiblityState);
            OnVisibilityChange?.Invoke(state);
        }

        #endregion


        override public void AddOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer) {
            OnXRChange += observer;
        }

        override public void RemoveOnXRChangeObserver(Action<IO8CAppFocusState.XRState> observer) {
            OnXRChange -= observer;
        }



        #region Non-Web Callbacks

        /// <summary>
        /// Callback called on OVRManager.InputFocusAcquired, OnVisibilityChange is invoked.
        /// </summary>
        private void OnInputFocusAcquiredApp() {
            OnVisibilityChange?.Invoke(IO8CAppFocusState.VisibilityState.visible);
        }


        /// <summary>
        /// Callback called upon OVRManager.InputFocusLost, OnVisibilityChange is invoked.
        /// </summary>
        private void OnInputFocusLostApp() {
            OnVisibilityChange?.Invoke(IO8CAppFocusState.VisibilityState.visibleBlurred);
        }

        public override IO8CAppFocusState.XRState GetCurrentXRState() {
            return currentXRState;
        }

        public override IO8CAppFocusState.VisibilityState GetCurrentVisibilityState() {
            return currentVisiblityState;
        }


        #endregion




    }

}

