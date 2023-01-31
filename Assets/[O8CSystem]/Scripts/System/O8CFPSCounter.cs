using UnityEngine;

namespace O8C {

    /// <summary>
    /// Updates a FPS display text.
    /// </summary>
    public class O8CFPSCounter : MonoBehaviour {

        #region Inspector Variables

        /// <summary>The FPS display text.</summary>
        [SerializeField] protected TextMesh text;

        #endregion


        #region Class Variables

        /// <summary>The computed FPS.</summary>
        private float fps = 0;

        /// <summary>Frame count.</summary>
        private float framesCount = 0;

        /// <summary>Last report time.</summary>
        private float lastReportTime = 0;

        /// <summary>Update rate</summary>
        private float updateRate = 0.5f;

        #endregion


        /// <summary>
        /// At the specified update rate, the FPS is computed and the display is updated.
        /// </summary>
        void Update() {
            framesCount++;
            if (Time.time >= lastReportTime + updateRate) {
                fps = framesCount / (Time.time - lastReportTime);
                lastReportTime = Time.time;
                framesCount = 0;
                text.text = fps.ToString("F0");
            }
        }

    }

}
