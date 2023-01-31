using System;


namespace O8C {


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

        public XRState GetCurrentXRState();

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