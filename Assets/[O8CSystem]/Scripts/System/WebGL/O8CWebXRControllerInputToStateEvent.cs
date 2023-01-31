using UnityEngine;
using UnityEngine.InputSystem;
using WebXR;


namespace O8C.WebGL {

    /// <summary>
    /// Reads controller input and passes the data to the InputSystem.
    /// </summary>
    [RequireComponent(typeof(WebXRController))]
    public class O8CWebXRControllerInputToStateEvent : MonoBehaviour {

        #region Class Variables

        /// <summary>The attached WebXRController component.</summary>
        protected WebXRController controller;

        /// <summary>The left controller input device.</summary>
        protected WebXRControllerLeft leftController;

        /// <summary>The right controller input device.</summary>
        protected WebXRControllerRight rightController;

        /// <summary>Controller state passed to the InputSystem.</summary>
        protected O8CWebXRControllerState controllerState;

        #endregion



        #region Base Metods

        /// <summary>
        /// Initializes values.
        /// </summary>
        private void Start() {
            controllerState = new();
            controller = GetComponent<WebXRController>();
            if (controller.hand == WebXRControllerHand.LEFT) {
                leftController = InputSystem.GetDevice<WebXRControllerLeft>();
            }
            else {
                rightController = InputSystem.GetDevice<WebXRControllerRight>();
            }
        }


        /// <summary>
        /// Updates the controllerState object with the current controller status and sends the data to the InputSystem.
        /// </summary>
        void Update() {
            controllerState.primary2DAxis = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
            controllerState.secondary2DAxis = controller.GetAxis2D(WebXRController.Axis2DTypes.Touchpad);
            controllerState.WithButton(O8CWebXRControllerState.ControllerButton.GripButton, controller.GetButton(WebXRController.ButtonTypes.Grip));
            controllerState.WithButton(O8CWebXRControllerState.ControllerButton.TriggerButton, controller.GetButton(WebXRController.ButtonTypes.Trigger));
            controllerState.WithButton(O8CWebXRControllerState.ControllerButton.PrimaryButton, controller.GetButton(WebXRController.ButtonTypes.ButtonA));
            controllerState.WithButton(O8CWebXRControllerState.ControllerButton.Primary2DAxisClick, controller.GetButton(WebXRController.ButtonTypes.Thumbstick));
            if (controller.hand == WebXRControllerHand.LEFT) {
                InputSystem.QueueStateEvent(leftController, controllerState);
            }
            else {
                InputSystem.QueueStateEvent(rightController, controllerState);
            }
        }

        #endregion

    }

}