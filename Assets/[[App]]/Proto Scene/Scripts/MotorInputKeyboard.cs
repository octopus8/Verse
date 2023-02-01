using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorInputKeyboard : MonoBehaviour, IMotorInput {

    protected IActorMotor actorMotor;

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

        actorMotor.Move(moveDir);

    }


}
