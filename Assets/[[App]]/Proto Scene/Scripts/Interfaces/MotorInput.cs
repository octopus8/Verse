using UnityEngine;



/// <summary>
/// Parent class for IMotorInput MonoBehaviour implementations.
/// </summary>
/// <remarks>
/// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
/// </remarks>
public abstract class MotorInput : MonoBehaviour, IMotorInput {

    /// <inheritdoc />
    abstract public void SetInputTransform(Transform transform);

    /// <inheritdoc />
    abstract public void SetMotor(IActorMotor motor);

}
