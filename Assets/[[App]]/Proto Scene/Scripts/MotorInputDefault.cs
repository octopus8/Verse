using O8C;
using UnityEngine;

public class MotorInputDefault : MonoBehaviour, IMotorInput {

    protected IActorMotor actorMotor;


    VerseInputActions inputActions;

    protected Transform inputTransform;


    void Start() {
        inputActions = new VerseInputActions();
        inputActions.Player.Move.Enable();
    }

    protected void Update() {
        if (null == actorMotor) {
            return;
        }
        var axis = inputActions.Player.Move.ReadValue<Vector2>();
        float yRotation = inputTransform.rotation.eulerAngles.y;
        Vector3 dir = new Vector3(axis.x, 0, axis.y);
        dir = Quaternion.Euler(0, yRotation, 0) * dir;
        actorMotor.Move(dir);

    }

    public void SetInputTransform(Transform transform) {
        inputTransform = transform;
    }

    public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }



}
