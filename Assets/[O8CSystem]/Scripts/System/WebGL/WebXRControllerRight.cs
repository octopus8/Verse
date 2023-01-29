using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace O8C.System.WebGL {

    /// <summary>
    /// The WebXR right controller InputDevice.
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad] // Call static class constructor in editor.
#endif
    [InputControlLayout(stateType = typeof(O8CWebXRControllerState))]
    public class WebXRControllerRight : InputDevice {

        #region Class Variables

        /// <summary>
        /// The primary touchpad or joystick on a device.
        /// </summary>
        public Vector2Control Primary2DAxis { get; private set; }

        /// <summary>
        /// A trigger-like control, pressed with the index finger.
        /// </summary>
        public AxisControl Trigger { get; private set; }

        /// <summary>
        /// Represents the users grip on the controller.
        /// </summary>
        public AxisControl Grip { get; private set; }

        /// <summary>
        /// A secondary touchpad or joystick on a device.
        /// </summary>
        public Vector2Control Secondary2DAxis { get; private set; }

        /// <summary>
        /// The primary face button being pressed on a device, or sole button if only one is available.
        /// </summary>
        public ButtonControl PrimaryButton { get; private set; }

        /// <summary>
        /// The primary face button being touched on a device.
        /// </summary>
        public ButtonControl PrimaryTouch { get; private set; }

        /// <summary>
        /// The secondary face button being pressed on a device.
        /// </summary>
        public ButtonControl SecondaryButton { get; private set; }

        /// <summary>
        /// The secondary face button being touched on a device.
        /// </summary>
        public ButtonControl SecondaryTouch { get; private set; }

        /// <summary>
        /// A binary measure of whether the device is being gripped.
        /// </summary>
        public ButtonControl GripButton { get; private set; }

        /// <summary>
        /// A binary measure of whether the index finger is activating the trigger.
        /// </summary>
        public ButtonControl TriggerButton { get; private set; }

        /// <summary>
        /// Represents a menu button, used to pause, go back, or otherwise exit gameplay.
        /// </summary>
        public ButtonControl MenuButton { get; private set; }

        /// <summary>
        /// Represents the primary 2D axis being clicked or otherwise depressed.
        /// </summary>
        public ButtonControl Primary2DAxisClick { get; private set; }

        /// <summary>
        /// Represents the primary 2D axis being touched.
        /// </summary>
        public ButtonControl Primary2DAxisTouch { get; private set; }

        /// <summary>
        /// Represents the secondary 2D axis being clicked or otherwise depressed.
        /// </summary>
        public ButtonControl Secondary2DAxisClick { get; private set; }

        /// <summary>
        /// Represents the secondary 2D axis being touched.
        /// </summary>
        public ButtonControl Secondary2DAxisTouch { get; private set; }

        /// <summary>
        /// Value representing the current battery life of this device.
        /// </summary>
        public AxisControl BatteryLevel { get; private set; }

        /// <summary>
        /// Indicates whether the user is present and interacting with the device.
        /// </summary>
        public ButtonControl UserPresence { get; private set; }

        #endregion



        /// <summary>
        /// Constructor; Calls Initialize.
        /// </summary>
        /// <remarks>
        /// [InitializeOnLoad] will ensure this gets called on every domain (re)load in the editor.
        /// </remarks>
#if UNITY_EDITOR
        static WebXRControllerRight() {
            Initialize();
        }
#endif



        /// <summary>
        /// Registers the input layout and ensures the device exists.
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize() {
            InputSystem.RegisterLayout<WebXRControllerRight>(
                matches: new InputDeviceMatcher()
                    .WithInterface("WebXRControllerRight"));

            var device = InputSystem.devices.FirstOrDefault(x => x is WebXRControllerRight);
            if (device == null) {
                InputSystem.AddDevice(new InputDeviceDescription {
                    interfaceName = "WebXRControllerRight",
                    product = "WebXRControllerRight",
                });
            }
        }



        /// <summary>
        /// Stores references to inputs.
        /// </summary>
        protected override void FinishSetup() {
            base.FinishSetup();

            Primary2DAxis = GetChildControl<Vector2Control>(nameof(Primary2DAxis));
            Trigger = GetChildControl<AxisControl>(nameof(Trigger));
            Grip = GetChildControl<AxisControl>(nameof(Grip));
            Secondary2DAxis = GetChildControl<Vector2Control>(nameof(Secondary2DAxis));
            PrimaryButton = GetChildControl<ButtonControl>(nameof(PrimaryButton));
            PrimaryTouch = GetChildControl<ButtonControl>(nameof(PrimaryTouch));
            SecondaryButton = GetChildControl<ButtonControl>(nameof(SecondaryButton));
            SecondaryTouch = GetChildControl<ButtonControl>(nameof(SecondaryTouch));
            GripButton = GetChildControl<ButtonControl>(nameof(GripButton));
            TriggerButton = GetChildControl<ButtonControl>(nameof(TriggerButton));
            MenuButton = GetChildControl<ButtonControl>(nameof(MenuButton));
            Primary2DAxisClick = GetChildControl<ButtonControl>(nameof(Primary2DAxisClick));
            Primary2DAxisTouch = GetChildControl<ButtonControl>(nameof(Primary2DAxisTouch));
            Secondary2DAxisClick = GetChildControl<ButtonControl>(nameof(Secondary2DAxisClick));
            Secondary2DAxisTouch = GetChildControl<ButtonControl>(nameof(Secondary2DAxisTouch));
            BatteryLevel = GetChildControl<AxisControl>(nameof(BatteryLevel));
            UserPresence = GetChildControl<ButtonControl>(nameof(UserPresence));
        }



#if UNITY_EDITOR

        /// <summary>
        /// Adds a menu item to add a right controller.
        /// </summary>
        [MenuItem("Tools/Add Right WebXRController")]
        private static void CreateDevice() {
            // This is the code that you would normally run at the point where
            // you discover devices of your custom type.
            InputSystem.AddDevice(new InputDeviceDescription {
                interfaceName = "WebXRController",
                product = "WebXRController"
            });
        }


        /// <summary>
        /// For completeness sake, a menu item is added to remove the device.
        /// </summary>
        /// <remarks>
        /// Note: The device can be manually removed from the input debugger by right-clicking in and selecting "Remove Device".
        /// </remarks>
        [MenuItem("Tools/Remove Right WebXRController")]
        private static void RemoveDevice() {
            var device = InputSystem.devices.FirstOrDefault(x => x is WebXRControllerRight);
            if (device != null)
                InputSystem.RemoveDevice(device);
        }

#endif

    }
}