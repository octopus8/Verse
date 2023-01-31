using UnityEngine;

namespace O8C {

    /// <summary>
    /// Sets the WebXR and Oculus platform active depending on the current platform.
    /// </summary>
    public class O8CPlatformRigPlatformSelector : MonoBehaviour {

        /// <summary>The WebXR platform object.</summary>
        [Tooltip("The WebXR platform object.")]
        [SerializeField] protected GameObject webXRPlatform;

        /// <summary>The Oculus platform object.</summary>
        [Tooltip("The Oculus platform object.")]
        [SerializeField] protected GameObject oculusPlatform;


        /// <summary>
        /// Sets the platform objects active depending on the platform.
        /// </summary>
        private void Awake() {
#if UNITY_WEBGL
            webXRPlatform.SetActive(true);
            oculusPlatform.SetActive(false);
#else
        webXRPlatform.SetActive(false);
        oculusPlatform.SetActive(true);
#endif
        }
    }
}