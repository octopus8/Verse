using UnityEngine;


/// <summary>
/// Input to a motor.
/// </summary>
public interface IMotorInput 
{

    /// <summary>
    /// Sets the motor to apply the input to.
    /// </summary>
    /// <param name="motor">The motor to use for the input.</param>
    public void SetMotor(IActorMotor motor);


    /// <summary>
    /// Sets the transform to transform input before applying.
    /// </summary>
    /// <param name="transform">The transform to use.</param>
    public void SetInputTransform(Transform transform);

}
