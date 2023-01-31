using System;


namespace O8C.System {

    /// <summary>
    /// Provides access to network functionality.
    /// </summary>
    public interface IO8CNetwork {

        /// <summary>
        /// Add an observer to the "on connect" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void AddOnConnectObserver(Action observer);


        /// <summary>
        /// Remove an observer to the "on connect" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void RemoveOnConnectObserver(Action observer);


        /// <summary>
        /// Add an observer to the "on disconnect" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void AddOnDisconnectObserver(Action observer);


        /// <summary>
        /// Remove an observer to the "on disconnect" event.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void RemoveOnDisconnectObserver(Action observer);

    }

}