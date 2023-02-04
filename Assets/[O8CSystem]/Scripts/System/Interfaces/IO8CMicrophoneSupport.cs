
namespace O8C {

    /// <summary>
    /// Provides access to microphone support.
    /// </summary>
    public interface IO8CMicrophoneSupport {

        /// <summary>
        /// Sets the active state for support.
        /// </summary>
        /// <remarks>
        /// This is only used by O8CSystem on deployed WebGL versions.
        /// </remarks>
        /// <param name="supportActive"></param>
        public void SetSupportActive(bool supportActive);


        /// <summary>
        /// Start record.
        /// </summary>
        public void StartRecord();


        /// <summary>
        /// Stop record.
        /// </summary>
        public void StopRecord();


        public bool IsRecording();

    }


}