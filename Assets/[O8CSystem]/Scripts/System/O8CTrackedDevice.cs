using UnityEngine;
using Zinnia.Tracking.Follow;

namespace O8C {

    /// <summary>
    /// Provides functionality related to tracked devices.
    /// </summary>
    /// 
    /// <remarks>
    /// * This class acts as a "Bridge" to imported library functionality.
    /// </remarks>
    public class O8CTrackedDevice : MonoBehaviour {

        /// <summary>The related ObjectFollower in the PlatformRig aliases.</summary>
        [Tooltip("The related ObjectFollower in the PlatformRig aliases.")]
        [SerializeField] ObjectFollower objectFollower;



        /// <summary>
        /// Adds an object to be transformed by the tracked transform.
        /// </summary>
        /// <param name="target">The target to add.</param>
        public void AddTarget(GameObject target) {
            objectFollower.Targets.Add(target);
        }



        /// <summary>
        /// Removes an object to be transformed by the tracked transform.
        /// </summary>
        /// <param name="target">The target to remove.</param>
        public void RemoveTarget(GameObject target) {
            if (null == target) {
                objectFollower.Targets.Remove(target);
            }
        }

    }

}
