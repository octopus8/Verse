using UnityEngine;


namespace O8C.System {


    /// <summary>
    /// Destroys the debug display if running as a production build.
    /// </summary>
    public class O8CDebugDisplay : MonoBehaviour {

        /// <summary>
        /// Destroys this object if running as a production build.
        /// </summary>
        protected void Awake() {
            if (O8CSystem.IsProduction()) {
                Destroy(gameObject);
            }
        }

    }


}

