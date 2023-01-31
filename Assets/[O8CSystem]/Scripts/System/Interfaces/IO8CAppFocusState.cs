using System;


namespace O8C {

    /// <summary>
    /// Provides access to the app focus state.
    /// </summary>
    public interface IO8CAppFocusState {

        /// <summary>
        /// Add an observer to the "XR change" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void AddOnXRChangeObserver(Action<XRState> observer);


        /// <summary>
        /// Remmoves an observer to the "XR change" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void RemoveOnXRChangeObserver(Action<XRState> observer);


        /// <summary>
        /// Returns the current XR state.
        /// </summary>
        /// <returns>The current XR state.</returns>
        public XRState GetCurrentXRState();


        /// <summary>
        /// Returns the current visibility state.
        /// </summary>
        /// <returns>The current visibility state.</returns>
        public VisibilityState GetCurrentVisibilityState();


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