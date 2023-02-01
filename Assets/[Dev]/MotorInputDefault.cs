using UnityEngine;
using UnityEngine.InputSystem;

public class MotorInputDefault : MonoBehaviour, IMotorInput {

    protected IActorMotor actorMotor;


    VerseInputActions inputActions;

    void Start() {
        inputActions = new VerseInputActions();
        inputActions.Player.Move.performed += MovePerformed;
    }

    private void OnDestroy() {
        inputActions.Player.Move.performed -= MovePerformed;
    }

    private void MovePerformed(InputAction.CallbackContext context) {
        var axis = context.ReadValue<Vector2>();
        actorMotor.Move(new Vector3(axis.x, 0, axis.y));
        Debug.Log("moving actor");
    }

    public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }



}
