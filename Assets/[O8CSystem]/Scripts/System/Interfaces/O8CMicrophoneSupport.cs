using UnityEngine;


namespace O8C {


    public abstract class O8CMicrophoneSupport : MonoBehaviour, IO8CMicrophoneSupport {

        abstract public void SetSupportActive(bool supportActive);

        abstract public void StartRecord();

        abstract public void StopRecord();

    }

}