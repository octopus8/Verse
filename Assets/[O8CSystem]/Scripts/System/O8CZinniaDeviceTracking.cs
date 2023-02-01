using UnityEngine;
using Zinnia.Tracking.Follow;

namespace O8C {

    /// <summary>
    /// Zinnia implementation of O8CDeviceTracking.
    /// </summary>
    public class O8CZinniaDeviceTracking : O8CDeviceTracking {

        #region Inspector Variables

        /// <summary>The play area.</summary>
        [Tooltip("The play area.")]
        [SerializeField] protected ObjectFollower playArea;

        /// <summary>The head tracked device.</summary>
        [Tooltip("The head tracked device.")]
        [SerializeField] protected ObjectFollower head;

        /// <summary>The left hand tracked device.</summary>
        [Tooltip("The left hand tracked device.")]
        [SerializeField] protected ObjectFollower leftHand;

        /// <summary>The right hand tracked device.</summary>
        [Tooltip("The right hand tracked device.")]
        [SerializeField] protected ObjectFollower rightHand;

        #endregion



        #region Base Methods

        /** {@inheritdoc} */
        override public void AddHeadTarget(GameObject target) {
            head.Targets.Add(target);
        }

        /** {@inheritdoc} */
        override public void AddLeftHandTarget(GameObject target) {
            leftHand.Targets.Add(target);
        }

        /** {@inheritdoc} */
        override public void AddRightHandTarget(GameObject target) {
            rightHand.Targets.Add(target);
        }

        /** {@inheritdoc} */
        override public void RemoveHeadTarget(GameObject target) {
            head.Targets.Remove(target);
        }

        /** {@inheritdoc} */
        override public void RemoveLeftHandTarget(GameObject target) {
            leftHand.Targets.Remove(target);
        }

        /** {@inheritdoc} */
        override public void RemoveRightHandTarget(GameObject target) {
            rightHand.Targets.Remove(target);
        }

        /** {@inheritdoc} */
        override public void SetPlayAreaFollower(GameObject source) {
            playArea.Sources.Add(source);
        }

        #endregion

    }

}
