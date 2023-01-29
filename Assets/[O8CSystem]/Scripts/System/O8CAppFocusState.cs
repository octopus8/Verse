using O8C;
using System;
using UnityEngine;
using WebXR;

namespace O8C.System {

    /// <summary>
    /// This class provides a "Bridge" to platform specific application focus state functionality.
    /// </summary>
    public class O8CAppFocusState : MonoBehaviour {

        #region Class Variables

        /// <summary>The current visibility state.</summary>
        protected VisibilityState currentVisiblityState;

        /// <summary>The current XR state.</summary>
        protected XRState currentXRState;

        #endregion



        #region Public Actions & Accessors

        /// <summary>Observers of the "visibility changed" event.</summary>
        public event Action<VisibilityState> OnVisibilityChange;

        /// <summary>Observers of the "XR state changed" event.</summary>
        public event Action<XRState> OnXRChange;

        /// <summary>Accessor for the current visibility state.</summary>
        public VisibilityState CurrentVisiblityState { get { return currentVisiblityState; } }

        /// <summary>Accessor for the current XR state.</summary>
        public XRState CurrentXRState { get { return currentXRState; } }

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
            XRState xrState;
            switch (state) {
                case WebXRState.VR:
                    xrState = XRState.VR;
                    break;
                case WebXRState.AR:
                    xrState = XRState.AR;
                    break;
                case WebXRState.NORMAL:
                    xrState = XRState.normal;
                    break;
                default:
                    xrState = XRState.unknown;
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
            VisibilityState state;
            switch (visibilityState) {
                case WebXRVisibilityState.VISIBLE:
                    state = VisibilityState.visible;
                    break;
                case WebXRVisibilityState.VISIBLE_BLURRED:
                    state = VisibilityState.visibleBlurred;
                    break;
                case WebXRVisibilityState.HIDDEN:
                    state = VisibilityState.hidden;
                    break;
                default:
                    state = VisibilityState.unknown;
                    break;
            }
            currentVisiblityState = state;
            Debug.Log("Visiblity state changed to " + currentVisiblityState);
            OnVisibilityChange?.Invoke(state);
        }

        #endregion



        #region Non-Web Callbacks

        /// <summary>
        /// Callback called on OVRManager.InputFocusAcquired, OnVisibilityChange is invoked.
        /// </summary>
        private void OnInputFocusAcquiredApp() {
            OnVisibilityChange?.Invoke(VisibilityState.visible);
        }


        /// <summary>
        /// Callback called upon OVRManager.InputFocusLost, OnVisibilityChange is invoked.
        /// </summary>
        private void OnInputFocusLostApp() {
            OnVisibilityChange?.Invoke(VisibilityState.visibleBlurred);
        }

        #endregion



        #region Data Structures

        /// <summary>App visibility states.</summary>
        public enum VisibilityState {
            visible,
            hidden,
            visibleBlurred,
            unknown,
        }

        /// <summary>XR states.</summary>
        public enum XRState {
            normal,
            VR,
            AR,
            unknown,
        }

        #endregion

    }

}

