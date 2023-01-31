using UnityEngine;

namespace O8C.WebGL {


    /// <summary>
    /// Enables microphone support upon initial start of VR. This allows the webpage to request microphone privleges before
    /// enabling microphone support.
    /// </summary>
    public class O8CSystemWebGLEnableMicrophoneSupport : MonoBehaviour {


        #region Base Methods

        /// <summary>
        /// Registers an XR change callback.
        /// </summary>
        private void Start() {
            O8CSystem.Instance.AppFocusState.AddOnXRChangeObserver(OnXRChange);
        }


        /// <summary>
        /// Unregisters an XR change callback.
        /// </summary>
        private void OnDestroy() {
            O8CSystem.Instance.AppFocusState.RemoveOnXRChangeObserver(OnXRChange);
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Callback called upon a change in the application focus state, this method sets the
        /// microphone support object as active.
        /// </summary>
        /// <param name="state">The new XR state.</param>
        private void OnXRChange(IO8CAppFocusState.XRState state) {
            if (state == IO8CAppFocusState.XRState.VR) {
                O8CSystem.Instance.MicrophoneSupport.SetSupportActive(true);
                Destroy(this);
            }
        }

        #endregion

    }


}

