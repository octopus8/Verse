using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.LowLevel;
using System.Runtime.InteropServices;
using UnityEngine;


namespace O8C.WebGL {


    /// <summary>
    /// Holds WebXR controller state info.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 63)]
    public struct O8CWebXRControllerState : IInputStateTypeInfo {
        [FieldOffset(0)]
        [InputControl(usage = "Primary2DAxis", aliases = new string[]
        {
            "thumbstick",
            "joystick"
        })]
        public Vector2 primary2DAxis;

        [FieldOffset(8)]
        [InputControl(usage = "Trigger", layout = "Axis")]
        public float trigger;

        [FieldOffset(12)]
        [InputControl(usage = "Grip", layout = "Axis")]
        public float grip;

        [FieldOffset(16)]
        [InputControl(usage = "Secondary2DAxis")]
        public Vector2 secondary2DAxis;

        [FieldOffset(24)]
        [InputControl(name = "primaryButton", usage = "PrimaryButton", layout = "Button", bit = 0u)]
        [InputControl(name = "primaryTouch", usage = "PrimaryTouch", layout = "Button", bit = 1u)]
        [InputControl(name = "secondaryButton", usage = "SecondaryButton", layout = "Button", bit = 2u)]
        [InputControl(name = "secondaryTouch", usage = "SecondaryTouch", layout = "Button", bit = 3u)]
        [InputControl(name = "gripButton", usage = "GripButton", layout = "Button", bit = 4u, alias = "gripPressed")]
        [InputControl(name = "triggerButton", usage = "TriggerButton", layout = "Button", bit = 5u, alias = "triggerPressed")]
        [InputControl(name = "menuButton", usage = "MenuButton", layout = "Button", bit = 6u)]
        [InputControl(name = "primary2DAxisClick", usage = "Primary2DAxisClick", layout = "Button", bit = 7u)]
        [InputControl(name = "primary2DAxisTouch", usage = "Primary2DAxisTouch", layout = "Button", bit = 8u)]
        [InputControl(name = "secondary2DAxisClick", usage = "Secondary2DAxisClick", layout = "Button", bit = 9u)]
        [InputControl(name = "secondary2DAxisTouch", usage = "Secondary2DAxisTouch", layout = "Button", bit = 10u)]
        [InputControl(name = "userPresence", usage = "UserPresence", layout = "Button", bit = 11u)]
        public ushort buttons;

        [FieldOffset(26)]
        [InputControl(usage = "BatteryLevel", layout = "Axis")]
        public float batteryLevel;

        [FieldOffset(30)]
        [InputControl(usage = "TrackingState", layout = "Integer")]
        public int trackingState;

        [FieldOffset(34)]
        [InputControl(usage = "IsTracked", layout = "Button")]
        public bool isTracked;

        [FieldOffset(35)]
        [InputControl(usage = "DevicePosition")]
        public Vector3 devicePosition;

        [FieldOffset(47)]
        [InputControl(usage = "DeviceRotation")]
        public Quaternion deviceRotation;

        public static FourCC formatId => new FourCC('W', 'X', 'R', 'C');

        public FourCC format => formatId;

        public void Reset() {
            primary2DAxis = default(Vector2);
            trigger = 0f;
            grip = 0f;
            secondary2DAxis = default(Vector2);
            buttons = 0;
            batteryLevel = 0f;
            trackingState = 0;
            isTracked = false;
            devicePosition = default(Vector3);
            deviceRotation = Quaternion.identity;
        }


        public O8CWebXRControllerState WithButton(ControllerButton button, bool state = true) {
            int num = 1 << (int)button;
            if (state) {
                buttons |= (ushort)num;
            }
            else {
                buttons &= (ushort)(~num);
            }

            return this;
        }


        public enum ControllerButton {
            PrimaryButton,
            PrimaryTouch,
            SecondaryButton,
            SecondaryTouch,
            GripButton,
            TriggerButton,
            MenuButton,
            Primary2DAxisClick,
            Primary2DAxisTouch,
            Secondary2DAxisClick,
            Secondary2DAxisTouch,
            UserPresence
        }

    }
}
