using TMPro;
using UnityEngine;

namespace O8C {

    /// <summary>
    /// Displays a message upon network disconnect, and removes it upon reconnecting.
    /// </summary>
    public class O8CNetworkConnectionInterruptedHudMessage : MonoBehaviour {

        #region Inspector Variables

        /// <summary>The message display GameObject.</summary>
        [Tooltip("The message display GameObject.")]
        [SerializeField] protected GameObject display;

        /// <summary>The message text.</summary>
        [Tooltip("The message text.")]
        [SerializeField] protected TextMeshProUGUI messageText;

        #endregion



        #region Class Variables

        /// <summary>The displayed second value.</summary>
        protected int currentSecond = 0;

        /// <summary>The next time to update the display.</summary>
        protected float nextUpdateTime = 0;

        #endregion



        #region Base Methods

        /// <summary>
        /// Ensures the display is not active.
        /// </summary>
        private void Awake() {
            display.SetActive(false);
        }


        /// <summary>
        /// Subscribes to events.
        /// </summary>
        private void Start() {
            O8CSystem.Instance.Network.AddOnConnectObserver(OnNetworkConnect);
            O8CSystem.Instance.Network.AddOnDisconnectObserver(OnNetworkDisconnect);
        }


        /// <summary>
        /// Unsubscribes to events.
        /// </summary>
        private void OnDestroy() {
            O8CSystem.Instance.Network.RemoveOnConnectObserver(OnNetworkConnect);
            O8CSystem.Instance.Network.RemoveOnDisconnectObserver(OnNetworkDisconnect);
        }


        /// <summary>
        /// If the display is active, the message is updated.
        /// </summary>
        private void Update() {
            if (!display.activeInHierarchy) {
                return;
            }
            if (Time.time > nextUpdateTime) {
                nextUpdateTime = Time.time + 1;
                messageText.text = string.Format("Reconnecting: {0}", ++currentSecond);
            }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Callback called upon network connection.
        /// </summary>
        private void OnNetworkConnect() {
            currentSecond = 0;
            display.SetActive(false);
        }


        /// <summary>
        /// Callback called upon network disconnect.
        /// </summary>
        private void OnNetworkDisconnect() {
            display.SetActive(true);
        }

        #endregion

    }


}

