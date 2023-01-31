using System;
using UnityEngine;


namespace O8C {

    /// <summary>
    /// The Mirror implementation of O8CNetwork.
    /// </summary>
    [RequireComponent(typeof(O8CMirrorNetworkManager))]
    public class O8CMirrorNetwork : O8CNetwork {

        #region Class Variables

        /// <summary>Event handler upon connecting.</summary>
        public event Action OnConnect;

        /// <summary>Event handler upon disconnecting.</summary>
        public event Action OnDisconnect;

        /// <summary>The O8CMirrorNetworkManager this class is a facade for.</summary>
        protected O8CMirrorNetworkManager o8CMirrorNetworkManager;

        #endregion


        #region Base Methods

        /// <summary>
        /// Stores references and attaches platform specific startup components.
        /// </summary>
        private void Awake() {
            o8CMirrorNetworkManager = GetComponent<O8CMirrorNetworkManager>();
        }


        /// <summary>
        /// Adds event handlers.
        /// </summary>
        private void Start() {
            o8CMirrorNetworkManager.OnConnect += HandleConnectEvent;
            o8CMirrorNetworkManager.OnDisconnect += HandleDisconnectEvent;
        }


        /// <summary>
        /// Removes event handlers.
        /// </summary>
        void OnDestroy() {
            o8CMirrorNetworkManager.OnConnect -= HandleConnectEvent;
            o8CMirrorNetworkManager.OnDisconnect -= HandleDisconnectEvent;
        }


        override public void AddOnConnectObserver(Action observer) {
            OnConnect += observer;
        }

        override public void RemoveOnConnectObserver(Action observer) {
            OnConnect -= observer;
        }

        override public void AddOnDisconnectObserver(Action observer) {
            OnDisconnect += observer;
        }

        override public void RemoveOnDisconnectObserver(Action observer) {
            OnDisconnect -= observer;
        }



        #endregion





        #region Private Methods

        /// <summary>
        /// Callback registered for O8CMirrorNetworkManager.OnConnect events, this method calls the OnConnect action.
        /// </summary>
        private void HandleConnectEvent() {
            OnConnect?.Invoke();
        }


        /// <summary>
        /// Callback registered for O8CMirrorNetworkManager.OnDisconnect events, this method calls the OnDisconnect action.
        /// </summary>
        private void HandleDisconnectEvent() {
            OnDisconnect?.Invoke();
        }



        #endregion
    }

}

