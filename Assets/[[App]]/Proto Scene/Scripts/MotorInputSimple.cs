using UnityEngine;


/// <summary>
/// Simple motor input.
/// </summary>
public class MotorInputSimple : MonoBehaviour, IMotorInput {

    #region Class Variables

    /// <summary>The motor to apply the input to.</summary>
    protected IActorMotor actorMotor;

    /// <summary>Input actions.</summary>
    protected VerseInputActions inputActions;

    /// <summary>The transform to transform input before applying.</summary>
    protected Transform inputTransform;

    #endregion



    #region Base Methods

    /// <summary>
    /// Creates and enables input.
    /// </summary>
    void Start() {
        inputActions = new VerseInputActions();
        inputActions.Player.Move.Enable();
        inputActions.Player.Turn.Enable();
    }


    /// <summary>
    /// Sends input to the motor.
    /// </summary>
    protected void Update() {
        if (null == actorMotor) {
            return;
        }
        var axis = inputActions.Player.Move.ReadValue<Vector2>();
        float yRotation = inputTransform.rotation.eulerAngles.y;
        Vector3 dir = new Vector3(axis.x, 0, axis.y);
        dir = Quaternion.Euler(0, yRotation, 0) * dir;
        actorMotor.Move(dir);

        axis = inputActions.Player.Turn.ReadValue<Vector2>();
        actorMotor.Turn(axis.x);
    }


    /// <inheritdoc />
    public void SetInputTransform(Transform transform) {
        inputTransform = transform;
    }


    /// <inheritdoc />
    public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }

    #endregion

}
