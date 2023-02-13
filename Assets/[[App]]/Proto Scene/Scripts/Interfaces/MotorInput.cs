using UnityEngine;

public abstract class MotorInput : MonoBehaviour, IMotorInput {
    abstract public void SetInputTransform(Transform transform);

    abstract public void SetMotor(IActorMotor motor);
}
