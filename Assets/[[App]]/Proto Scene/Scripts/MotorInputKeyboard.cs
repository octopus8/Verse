using UnityEngine;


/// <summary>
/// Keyboard motor input, used for debugging.
/// </summary>
public class MotorInputKeyboard : MotorInput {

    #region Class Variables

    /// <summary>The motor to apply the input to.</summary>
    protected IActorMotor actorMotor;

    /// <summary>The transform to transform input before applying.</summary>
    protected Transform inputTransform;

    #endregion



    #region Base Methods


    /// <summary>
    /// Sends input to the motor.
    /// </summary>
    protected void FixedUpdate() {

        if (null == actorMotor) {
            return;
        }

        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) {
            moveDir.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            moveDir.z -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveDir.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            moveDir.x += 1;
        }

        moveDir.Normalize();

        float yRotation = inputTransform.rotation.eulerAngles.y;
        Vector3 dir = new Vector3(moveDir.x, 0, moveDir.z);
        dir = Quaternion.Euler(0, yRotation, 0) * dir;

        actorMotor.Move(dir);

    }

    /// <inheritdoc />
    override public void SetInputTransform(Transform transform) {
        inputTransform = transform;
    }

    /// <inheritdoc />
    override public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }

    #endregion

}
