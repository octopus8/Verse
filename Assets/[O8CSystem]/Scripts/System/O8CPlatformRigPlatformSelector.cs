using UnityEngine;
using Zinnia.Tracking.CameraRig;
using Zinnia.Tracking.CameraRig.Collection;

namespace O8C {

    /// <summary>
    /// Sets the WebXR and Oculus platform active depending on the current platform.
    /// </summary>
    public class O8CPlatformRigPlatformSelector : MonoBehaviour {

        #region Inspector Variables

        /// <summary>The WebXR platform object.</summary>
        [Tooltip("The WebXR platform object.")]
        [SerializeField] protected GameObject webXRPlatform;

        /// <summary>The Oculus platform object.</summary>
        [Tooltip("The Oculus platform object.")]
        [SerializeField] protected GameObject oculusPlatform;

        #endregion



        /// <summary>
        /// Sets the platform objects active depending on the platform.
        /// </summary>
        private void Awake() {
            LinkedAliasAssociationCollectionObservableList list = FindObjectOfType<LinkedAliasAssociationCollectionObservableList>();
#if UNITY_WEBGL
            webXRPlatform.SetActive(true);
            list.Add(webXRPlatform.GetComponent<LinkedAliasAssociationCollection>());
            Destroy(oculusPlatform);
#else
            oculusPlatform.SetActive(true);
            list.Add(oculusPlatform.GetComponent<LinkedAliasAssociationCollection>());
            Destroy(webXRPlatform);
#endif
        }

    }

}