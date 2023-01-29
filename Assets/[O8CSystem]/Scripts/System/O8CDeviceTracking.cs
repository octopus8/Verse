using UnityEngine;

namespace O8C.System {

    /// <summary>
    /// Provides access to the tracked devices.
    /// </summary>
    public class O8CDeviceTracking : MonoBehaviour {

        /// <summary>The head tracked device.</summary>
        [Tooltip("The head tracked device.")]
        [SerializeField] protected O8CTrackedDevice head;

        /// <summary>The left hand tracked device.</summary>
        [Tooltip("The left hand tracked device.")]
        [SerializeField] protected O8CTrackedDevice leftHand;

        /// <summary>The right hand tracked device.</summary>
        [Tooltip("The right hand tracked device.")]
        [SerializeField] protected O8CTrackedDevice rightHand;


        /// <summary>Accessor for the head tracked device.</summary>
        public O8CTrackedDevice Head { get { return head; } }

        /// <summary>Accessor for the left hand tracked device.</summary>
        public O8CTrackedDevice LeftHand { get { return leftHand; } }

        /// <summary>Accessor for the right hand tracked device.</summary>
        public O8CTrackedDevice RightHand { get { return rightHand; } }

    }

}
