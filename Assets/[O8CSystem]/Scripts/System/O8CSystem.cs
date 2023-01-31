using O8C.System.WebGL;
using UnityEngine;
using UnityEngine.Assertions;


namespace O8C.System {

    /// <summary>
    /// The "Singleton" that acts as access to functionality provided by the O8CSystem.
    /// </summary>
    /// <remarks>
    /// * This class decreases dependencies by encapsulating many classes that would be singletons otherwise.
    /// </remarks>
    public sealed class O8CSystem : MonoBehaviour {

        #region Editor Variables

        /// <summary>The O8CDeviceTracking component in the O8CSystem.</summary>
        [Tooltip("The O8CDeviceTracking component in the O8CSystem.")]
        [SerializeField] private O8CDeviceTracking deviceTracking;

        /// <summary>The O8CNetwork component in the O8CSystem.</summary>
        [Tooltip("The O8CNetwork component in the O8CSystem.")]
        [SerializeField] private O8CNetwork network;

        /// <summary>The AppFocusState component in the O8CSystem.</summary>
        [Tooltip("The AppFocusState component in the O8CSystem.")]
        [SerializeField] private O8CAppFocusState appFocusState;

        /// <summary>The PlayerConnection component in the O8CSystem.</summary>
        [Tooltip("The O8CPlayerConnection component in the O8CSystem.")]
        [SerializeField] private O8CPlayerConnection playerConnection;

        /// <summary>The O8CMicrophoneSupport component in the O8CSystem.</summary>
        [Tooltip("The O8CMicrophoneSupport component in the O8CSystem.")]
        [SerializeField] private O8CMicrophoneSupport microphoneSupport;

        #endregion



        #region Accessors

        /// <summary>Accessor for the singleton instance.</summary>
        static public O8CSystem Instance { get; private set; }

        /// <summary>Accessor for the Network functionality.</summary>
        public IO8CNetwork Network { get { return network; } }

        /// <summary>Accessor for the DeviceTracking functionality.</summary>
        public IO8CDeviceTracking DeviceTracking { get { return deviceTracking; } }

        /// <summary>Accessor for the AppFocusEvent functionality.</summary>
        public IO8CAppFocusState AppFocusState { get { return appFocusState; } }

        /// <summary>Accessor for the PlayerConnection functionality.</summary>
        public IO8CPlayerConnection PlayerConnection { get { return playerConnection; } }

        /// <summary>Accessor for the MicrophoneSupport functionality.</summary>
        public IO8CMicrophoneSupport MicrophoneSupport { get { return microphoneSupport; } }

        #endregion



        #region Static Helper Methods

        /// <summary>
        /// Checks if the app is running as a deployed WebGL application.
        /// </summary>
        /// <returns>If the app is running as a deployed WebGL application.</returns>
        static public bool IsDeployedWebGL() {
            if ((Application.platform != RuntimePlatform.WindowsEditor) && (Application.platform != RuntimePlatform.LinuxEditor) && (Application.platform != RuntimePlatform.OSXEditor) && (Application.platform == RuntimePlatform.WebGLPlayer)) {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Checks if the app is running in Production mode.
        /// </summary>
        /// <returns>True if the app is running in Production mode.</returns>
        static public bool IsProduction() {
            if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.LinuxEditor) || (Application.platform == RuntimePlatform.OSXEditor)) {
                return false;
            }
            if (Application.platform == RuntimePlatform.WebGLPlayer) {
                if (Application.absoluteURL.Contains("dev")) {
                    return false;
                }
            }
            return true;
        }

        #endregion



        #region Base Methods

        /// <summary>
        /// Stores reference to singleton instance, and for deployed WebGL builds, microphone support is disabled and
        /// a O8CSystemWebGLEnableMicrophoneSupport component is added to enable microphone support later.
        /// </summary>
        private void Awake() {
            Assert.IsNull(Instance, "Multiple instances of O8CSystem singleton.");
            Instance = this;


            if (IsDeployedWebGL()) {
                microphoneSupport.SetSupportActive(false);
            }
            else {
                microphoneSupport.SetSupportActive(true);
            }

        }

        #endregion

    }
}

