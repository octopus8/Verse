using UnityEngine;

public class MotorInputDefault : MonoBehaviour, IMotorInput {

    protected IActorMotor actorMotor;


    VerseInputActions inputActions;

    void Start() {
        inputActions = new VerseInputActions();
        inputActions.Player.Move.Enable();
    }

    protected void Update() {
        if (null == actorMotor) {
            return;
        }
        var axis = inputActions.Player.Move.ReadValue<Vector2>();
        actorMotor.Move(new Vector3(axis.x, 0, axis.y));

    }


    public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }



}
