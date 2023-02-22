using O8C;
using UnityEngine;


/// <summary>
/// Controls the visibility of the hot mic indicator.
/// </summary>
public class HotMicIndicator : MonoBehaviour
{
    /// <summary>The indicator GameObject.</summary>
    [Tooltip("The indicator GameObject.")]
    [SerializeField] protected GameObject indicator;


    /// <summary>
    /// Initialises the component.
    /// </summary>
    void Start()
    {
        indicator.SetActive(false);
    }


    /// <summary>
    /// Sets the indicator GameObject active according to if the microphone is recording.
    /// </summary>
    private void Update() {
        indicator.SetActive(O8CSystem.Instance.MicrophoneSupport.IsRecording());
    }

}
