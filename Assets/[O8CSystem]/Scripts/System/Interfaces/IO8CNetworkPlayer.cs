using UnityEngine;

namespace O8C {

    /// <summary>
    /// Provides functionality related to a networked player.
    /// </summary>
    public interface IO8CNetworkPlayer {

        Transform GetHeadTransform();

        /// <summary>
        /// Add a head follower object.
        /// </summary>
        /// <param name="head">Object to add.</param>
        void AddHeadFollower(GameObject head);


        /// <summary>
        /// Add left hand follower object.
        /// </summary>
        /// <param name="leftHand">Object to add.</param>
        void AddLeftHandFollower(GameObject leftHand);


        /// <summary>
        /// Add right hand follower object.
        /// </summary>
        /// <param name="rightHand">Object to add.</param>
        void AddRightHandFollower(GameObject rightHand);


        /// <summary>
        /// Remove a head follower object.
        /// </summary>
        /// <param name="head">Object to remove.</param>
        void RemoveHeadFollower(GameObject head);


        /// <summary>
        /// Remove left hand follower object.
        /// </summary>
        /// <param name="leftHand">Object to remove.</param>
        void RemoveLeftHandFollower(GameObject leftHand);


        /// <summary>
        /// Remove right hand follower object.
        /// </summary>
        /// <param name="rightHand">Object to remove.</param>
        void RemoveRightHandFollower(GameObject rightHand);
    }


}