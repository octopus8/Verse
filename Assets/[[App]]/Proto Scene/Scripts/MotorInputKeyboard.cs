using UnityEngine;

public class MotorInputKeyboard : MonoBehaviour, IMotorInput {

    protected IActorMotor actorMotor;

    protected Transform inputTransform;


    public void SetInputTransform(Transform transform) {
        inputTransform = transform;
    }

    public void SetMotor(IActorMotor motor) {
        actorMotor = motor;
    }


    protected void Update() {

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
        Vector3 dir = new Vector3(moveDir.x, 0, moveDir.y);
        dir = Quaternion.Euler(0, yRotation, 0) * dir;

        actorMotor.Move(dir);

    }


}
