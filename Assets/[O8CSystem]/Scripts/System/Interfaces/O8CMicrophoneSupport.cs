using UnityEngine;


namespace O8C {


    /// <summary>
    /// Parent class for IO8CMicrophoneSupport MonoBehaviour implementations.
    /// </summary>
    /// <remarks>
    /// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
    /// </remarks>
    public abstract class O8CMicrophoneSupport : MonoBehaviour, IO8CMicrophoneSupport {

        /// <inheritdoc />
        abstract public void SetSupportActive(bool supportActive);


        /// <inheritdoc />
        abstract public void StartRecord();


        /// <inheritdoc />
        abstract public void StopRecord();


        /// <inheritdoc />
        abstract public bool IsRecording();

    }

}