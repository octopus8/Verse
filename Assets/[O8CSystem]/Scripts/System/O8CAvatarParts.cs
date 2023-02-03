using UnityEngine;


namespace O8C {

    /// <summary>
    /// Provides access to avatar parts.
    /// </summary>
    public class O8CAvatarParts : MonoBehaviour {

        #region Inspector Variables

        /// <summary>The head GameObject.</summary>
        [SerializeField] protected GameObject head;

        /// <summary>The left hand GameObject.</summary>
        [SerializeField] protected GameObject leftHand;

        /// <summary>The right hand GameObject.</summary>
        [SerializeField] protected GameObject rightHand;

        /// <summary>The body joint GameObject.</summary>
        [SerializeField] protected GameObject bodyJoint;

        #endregion



        #region Accessors

        /// <summary>Accessor for the head GameObject.</summary>
        public GameObject Head { get { return head; } }

        /// <summary>Accessor for the left hand GameObject.</summary>
        public GameObject LeftHand { get { return leftHand; } }

        /// <summary>Accessor for the right hand GameObject.</summary>
        public GameObject RightHand { get { return rightHand; } }

        /// <summary>Accessor for the body joint GameObject.</summary>
        public GameObject BodyJoint { get { return bodyJoint; } }

        #endregion



        #region Base Methods

        /// <summary>
        /// Initializes avatar parts.
        /// </summary>
        /// <remarks>
        /// Offsets are set. These may need to be set on a platform basis.
        /// </remarks>
        private void Start() {
            SetLeftHandOffset(new Vector3(-0.03f, -0.03f, -0.06f), new Vector3(-90, 90, 0));
            SetRightHandOffset(new Vector3(0.03f, -0.03f, -0.06f), new Vector3(-90, -90, 0));
        }


        /// <summary>
        /// Updates the body joint.
        /// </summary>
        private void Update() {
            bodyJoint.transform.rotation = Quaternion.Euler(0, head.transform.rotation.eulerAngles.y, 0);
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Sets the offset from tracking for the left hand.
        /// </summary>
        /// <param name="pos">Positional offset.</param>
        /// <param name="rotation">Rotational offset.</param>
        private void SetLeftHandOffset(Vector3 pos, Vector3 rotation) {
            Transform offset = leftHand.transform.GetChild(0);
            offset.localPosition = pos;
            offset.localRotation = Quaternion.Euler(rotation);
        }


        /// <summary>
        /// Sets the offset from tracking for the right hand.
        /// </summary>
        /// <param name="pos">Positional offset.</param>
        /// <param name="rotation">Rotational offset.</param>
        private void SetRightHandOffset(Vector3 pos, Vector3 rotation) {
            Transform offset = rightHand.transform.GetChild(0);
            offset.localPosition = pos;
            offset.localRotation = Quaternion.Euler(rotation);
        }

        #endregion

    }

}
