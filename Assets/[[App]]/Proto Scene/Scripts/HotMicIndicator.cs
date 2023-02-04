using O8C;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotMicIndicator : MonoBehaviour
{

    [SerializeField] protected GameObject indicator;


    void Start()
    {
        indicator.SetActive(false);
    }


    private void Update() {
        indicator.SetActive(O8CSystem.Instance.MicrophoneSupport.IsRecording());
    }
}
