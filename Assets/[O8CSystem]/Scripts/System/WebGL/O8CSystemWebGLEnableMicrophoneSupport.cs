using UnityEngine;

namespace O8C.System.WebGL {


    /// <summary>
    /// Enables microphone support upon initial start of VR. This allows the webpage to request microphone privleges before
    /// enabling microphone support.
    /// </summary>
    public class O8CSystemWebGLEnableMicrophoneSupport : MonoBehaviour {

        #region Class Variables and Accessors

        /// <summary>Microphone support</summary>
        protected GameObject microphoneSupport;

        /// <summary>Setter for the microphoneSupport variable. This is set after being added to the GameObject.</summary>
        public GameObject MicrophoneSupport { set { microphoneSupport = value; } }

        #endregion



        #region Base Methods

        /// <summary>
        /// Registers an XR change callback.
        /// </summary>
        private void Start() {
            O8CSystem.Instance.AppFocusState.OnXRChange += OnXRChange;
        }


        /// <summary>
        /// Unregisters an XR change callback.
        /// </summary>
        private void OnDestroy() {
            O8CSystem.Instance.AppFocusState.OnXRChange -= OnXRChange;
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Callback called upon a change in the application focus state, this method sets the
        /// microphone support object as active.
        /// </summary>
        /// <param name="state">The new XR state.</param>
        private void OnXRChange(O8CAppFocusState.XRState state) {
            if (state == O8CAppFocusState.XRState.VR) {
                microphoneSupport.SetActive(true);
                Destroy(this);
            }
        }

        #endregion

    }


}

