using UnityEngine;


namespace O8C.Util {

    /// <summary>
    /// Simply adds the GameObject as a head follower on Start and removes it OnDestroy.
    /// </summary>
    public class O8CHeadFollower : MonoBehaviour {

        /// <summary>
        /// Add the GameObject as a head follower.
        /// </summary>
        void Start() {
            O8CSystem.Instance.DeviceTracking.AddHeadTarget(gameObject);
        }


        /// <summary>
        /// Removes the GameObject as a head follower.
        /// </summary>
        private void OnDestroy() {
            O8CSystem.Instance.DeviceTracking.RemoveHeadTarget(gameObject);
        }


    }


}
