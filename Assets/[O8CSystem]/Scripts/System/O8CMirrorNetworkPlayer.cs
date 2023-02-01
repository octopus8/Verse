using Mirror;
using UnityEngine;

namespace O8C {



    /// <summary>
    /// On Start, this component notifies the system of a new player and connects tracked objects to tracked targets.
    /// OnDestroy, the system is notified of the player removal and tracked objects are removed from tracked targets.
    /// </summary>
    public class O8CMirrorNetworkPlayer : NetworkBehaviour {

        #region Inspector Variables

        /// <summary>The head GameObject.</summary>
        [Tooltip("The head GameObject.")]
        [SerializeField] protected GameObject head;

        /// <summary>The left hand GameObject.</summary>
        [Tooltip("The left hand GameObject.")]
        [SerializeField] protected GameObject handLeft;

        /// <summary>The right hand GameObject.</summary>
        [Tooltip("The right hand GameObject.")]
        [SerializeField] protected GameObject handRight;

        #endregion

        protected bool isApplicationQuitting = false;


        #region Base Methods

        /// <summary>
        /// If the player is a local player, the networked tracked objects are added to tracked targets. Additionally, the system is notified of the new player.
        /// </summary>
        private void Start() {
            if (isLocalPlayer) {
                O8CSystem.Instance.DeviceTracking.AddHeadTarget(head);
                O8CSystem.Instance.DeviceTracking.AddRightHandTarget(handRight);
                O8CSystem.Instance.DeviceTracking.AddLeftHandTarget(handLeft);
            }
            O8CSystem.Instance.PlayerConnection.PlayerConnected(gameObject, isLocalPlayer);
        }


        /// <summary>
        /// Sets a flag indicating the application is quitting.
        /// </summary>
        /// <remarks>
        /// The isApplicationQuitting is used by OnDestroy to handle a network player leaving as opposed to the application quitting.
        /// </remarks>
        private void OnApplicationQuit() {
            isApplicationQuitting = true;
        }


        /// <summary>
        /// The system is notified of the player being destroyed, and if the player is a local player, the networked tracked objects are removed from
        /// tracked targets.
        /// </summary>
        /// <remarks>
        /// If the application is quitting, then system objects may have been destroyed. The app is quitting so proper destruction of objects is not important.
        /// Therefore, if the application is quitting, then nothing is done.
        /// </remarks>
        private void OnDestroy() {
            if (isApplicationQuitting) {
                return;
            }
            O8CSystem.Instance.PlayerConnection.PlayerDisconnected(gameObject, isLocalPlayer);

            if (isLocalPlayer) {
                O8CSystem.Instance.DeviceTracking.RemoveHeadTarget(head);
                O8CSystem.Instance.DeviceTracking.RemoveRightHandTarget(handRight);
                O8CSystem.Instance.DeviceTracking.RemoveLeftHandTarget(handLeft);
            }
        }

        #endregion


    }
}