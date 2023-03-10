using Cysharp.Threading.Tasks;
using FrostweepGames.Plugins.Native;
using FrostweepGames.VoicePro;
using UnityEngine;

namespace O8C {

    /// <summary>
    /// Waits a period of time after start, then sets the microphone for the attached recorder component.
    /// </summary>
    [RequireComponent(typeof(Recorder))]
    public class O8CVoiceProMicrophoneSupport : O8CMicrophoneSupport {

        /// <summary>The Recorder component.</summary>
        protected Recorder recorder;


        /// <summary>Stores references and schedules microphone refreshing.</summary>
        void Start() {
            recorder = GetComponent<Recorder>();
            RefreshMicrophonesOnStart().Forget();
        }


        /// <summary>
        /// Waits a period of time, then sets the microphone for the recorder.
        /// </summary>
        /// <returns>UniTask</returns>
        private async UniTask RefreshMicrophonesOnStart() {
            await UniTask.DelayFrame(30);
            recorder.RefreshMicrophones();

            if (CustomMicrophone.HasConnectedMicrophoneDevices()) {
                recorder.SetMicrophone(CustomMicrophone.devices[0]);
            }
        }


        /// <summary>
        /// Starts microphone record.
        /// </summary>
        override public void StartRecord() {
            recorder.StartRecord();
        }


        /// <summary>
        /// Stops microphone record.
        /// </summary>
        override public void StopRecord() {
            recorder.StopRecord();
        }

        public override void SetSupportActive(bool supportActive) {
            gameObject.SetActive(supportActive);
        }


        public override bool IsRecording() {
            return recorder.recording;
        }
    }

}
