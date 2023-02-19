using UnityEngine;


namespace O8C {

    /// <summary>
    /// Provides access to the tracked devices.
    /// </summary>
    public interface IO8CDeviceTracking {

        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void AddHeadTarget(GameObject target);


        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void RemoveHeadTarget(GameObject target);


        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void AddLeftHandTarget(GameObject target);


        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void RemoveLeftHandTarget(GameObject target);


        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void AddRightHandTarget(GameObject target);


        /// <summary>
        /// Add a GameObject to be transformed by the head transform.
        /// </summary>
        /// <param name="target">Target GameObject.</param>
        public void RemoveRightHandTarget(GameObject target);


        /// <summary>
        /// Sets the play area follower.
        /// </summary>
        /// <param name="source">The object to follow.</param>
        public void SetPlayAreaFollower(GameObject source);

        /// <summary>
        /// Provides access to the head transform.
        /// </summary>
        /// <returns>The head transform.</returns>
        public Transform GetHeadTransform();

    }

}
