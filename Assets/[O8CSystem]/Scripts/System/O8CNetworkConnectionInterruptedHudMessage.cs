using TMPro;
using UnityEngine;

namespace O8C.System {

    /// <summary>
    /// Displays a message upon network disconnect, and removes it upon reconnecting.
    /// </summary>
    public class O8CNetworkConnectionInterruptedHudMessage : MonoBehaviour {

        #region Editor Variables

        /// <summary>The message display GameObject.</summary>
        [Tooltip("The message display GameObject.")]
        [SerializeField] GameObject display;

        /// <summary>The message text.</summary>
        [Tooltip("The message text.")]
        [SerializeField] TextMeshProUGUI messageText;

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
            O8CSystem.Instance.Network.OnConnect += OnNetworkConnect;
            O8CSystem.Instance.Network.OnDisconnect += OnNetworkDisconnect;
        }


        /// <summary>
        /// Unsubscribes to events.
        /// </summary>
        private void OnDestroy() {
            O8CSystem.Instance.Network.OnConnect -= OnNetworkConnect;
            O8CSystem.Instance.Network.OnDisconnect -= OnNetworkDisconnect;
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

