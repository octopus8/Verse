#if MIRROR_NETWORK_PROVIDER
using Cysharp.Threading.Tasks;
using FrostweepGames.VoicePro.NetworkProviders.Mirror;
using Mirror;
using Mirror.SimpleWeb;
using O8C;
using System;
using UnityEngine;
#endif

namespace O8C.System {


    /// <summary>
    /// Manages starting/stopping the server/client.
    /// </summary>
    public class O8CMirrorNetworkManager : NetworkManager {
        /// <summary>The Telepathy transport used for all platforms except for WebGL.</summary>
        [Tooltip("The Telepathy transport used for all platforms except for WebGL.")]
        [SerializeField] protected TelepathyTransport telepathyTransport;


        /// <summary>The Simple Web transport used for WebGL.</summary>
        [Tooltip("The Simple Web transport used for WebGL.")]
        [SerializeField] protected SimpleWebTransport simpleWebTransport;


        // Avoid unnecessary warnings on these.
#pragma warning disable CS0414

        /// <summary>Port used for the Telepathy transport in Dev mode.</summary>
        protected ushort telepathyTransportDevPort = 7775;

        /// <summary>Port used for the Simple Web transport in Dev mode.</summary>
        protected ushort simpleWebTransportDevPort = 7776;

        /// <summary>Port used for the Telepathy transport in Production mode.</summary>
        protected ushort telepathyTransportProdPort = 7777;

        /// <summary>Port used for the Simple Web transport in Production mode.</summary>
        protected ushort simpleWebTransportProdPort = 7778;

#pragma warning restore CS0414

        /// <summary>Flag indicating the client has made a connection.</summary>
        protected bool hasConnected = false;



        #region Network Connection Actions

        /// <summary>Action called on network connect.</summary>
        public event Action OnConnect;

        /// <summary>Action called on nectork disconnect.</summary>
        public event Action OnDisconnect;



        #endregion



        #region Base Methods

        /// <summary>
        /// Sets the ports to use for the network transports.
        /// </summary>
        private new void Awake() {
            base.Awake();

#if UNITY_SERVER
        if (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Contains("Dev")) {
            Debug.Log("Server Type: Dev");
            telepathyTransport.port = telepathyTransportDevPort;
            simpleWebTransport.port = simpleWebTransportDevPort;
        }
        else {
            Debug.Log("Server Type: PRODUCTION");
            telepathyTransport.port = telepathyTransportProdPort;
            simpleWebTransport.port = simpleWebTransportProdPort;
        }
#elif !UNITY_EDITOR && UNITY_WEBGL
        if (Application.absoluteURL.Contains("dev")) {
            telepathyTransport.port = telepathyTransportDevPort;
            simpleWebTransport.port = simpleWebTransportDevPort;
        }
        else {
            telepathyTransport.port = telepathyTransportProdPort;
            simpleWebTransport.port = simpleWebTransportProdPort;
        }
#elif UNITY_EDITOR
            telepathyTransport.port = telepathyTransportDevPort;
            simpleWebTransport.port = simpleWebTransportDevPort;
#else
        telepathyTransport.port = telepathyTransportProdPort;
        simpleWebTransport.port = simpleWebTransportProdPort;
#endif
        }


        /// <summary>
        /// If not the server, the client is started.
        /// </summary>
        private new void Start() {
            base.Start();

#if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log("URL: " + Application.absoluteURL);
        if (Application.absoluteURL.Contains("dev")) {
            Debug.Log("Server used: Dev");
        } else {
            Debug.Log("Server used: PRODUCTION");
        }
#endif
#if !UNITY_SERVER
            StartClient();
#endif
        }

        #endregion



        #region Server Event Handlers

        /// <summary>
        /// Called on the server upon server start, registers a handler for voice messages.
        /// </summary>
        public override void OnStartServer() {
            // Start the server.
            base.OnStartServer();

            // Register handler for FrostweepGames.VoicePro TransportVoiceMessages.
            NetworkServer.RegisterHandler<TransportVoiceMessage>(NetworkEventReceivedHandler);
            Debug.Log("Server Started!");
        }


        /// <summary>
        /// Called on the server upon server stop, unregisters a handler for voice messages.
        /// </summary>
        public override void OnStopServer() {
            // Stop the server.
            base.OnStopServer();

            // Unregister voice message handler.
            NetworkServer.UnregisterHandler<TransportVoiceMessage>();
            Debug.Log("Server Stopped!");
        }


        /// <summary>
        /// Called on the server upon a player connection, this method simply logs the connection.
        /// </summary>
        /// <param name="conn"></param>
        public override void OnServerConnect(NetworkConnectionToClient conn) {
            base.OnServerConnect(conn);
            Debug.Log("Client connected to server: IP:" + conn.address + ", ConnectionID:" + conn.connectionId);
        }


        /// <summary>
        /// Called on the server upon a player disconnect, this method simply logs the disconnect.
        /// </summary>
        /// <param name="conn"></param>
        public override void OnServerDisconnect(NetworkConnectionToClient conn) {
            Debug.Log("Client disconnected from server. ConnectionID:" + conn.connectionId);
            base.OnServerDisconnect(conn);
        }

        #endregion



        #region Client Event Handlers

        /// <summary>
        /// Called upon the client connecting, the OnConnect event is invoked.
        /// </summary>
        public override void OnClientConnect() {
            base.OnClientConnect();
            hasConnected = true;
            OnConnect?.Invoke();
            Debug.Log("Connected to server.");
        }


        /// <summary>
        /// Called upon the client disconnecting, the OnDisconnect event is invoked and a reconnection is attempted.
        /// </summary>
        public override void OnClientDisconnect() {
            base.OnClientDisconnect();
            Debug.LogWarning("Disconnected from server.");
            OnDisconnect?.Invoke();
            ReconnectWhenReady().Forget();
        }


        /// <summary>
        /// Attempts to reconnect to the server until a connection is re-established.
        /// </summary>
        /// <returns>UniTask</returns>
        async UniTask ReconnectWhenReady() {
            await UniTask.Delay(1000);
#if UNITY_EDITOR
            if (true) {
#else
            if ((O8CSystem.Instance.AppFocusState.GetCurrentVisibilityState() == IO8CAppFocusState.VisibilityState.visible) && (O8CSystem.Instance.AppFocusState.GetCurrentXRState() == IO8CAppFocusState.XRState.VR)) {
#endif
            Debug.Log("Attempting to restart client.");
                StartClient();
            }
        }

        /// <summary>
        /// Called upon a client connection error, the error is logged and a reconnection is attempted.
        /// </summary>
        /// <param name="exception"></param>
        public override void OnClientError(Exception exception) {
            base.OnClientError(exception);
            Debug.LogError(exception.Message);
            if (hasConnected) {
                ReconnectWhenReady().Forget();
            }
        }

        #endregion



        #region Server Helper Methods

        /// <summary>Distributes the voice message among ready users.</summary>
        private void NetworkEventReceivedHandler(NetworkConnection connection, TransportVoiceMessage message) {
            NetworkServer.SendToReady(message);
        }

        #endregion


    }
}