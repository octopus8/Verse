using UnityEngine;


/// <summary>
/// Actor motor.
/// </summary>
/// <remarks>
/// A "motor" is something that moves and turns an object.
/// </remarks>
public interface IActorMotor 
{

    /// <summary>
    /// Move in the direction specified.
    /// </summary>
    /// <param name="directionUnitsPerSecond">The direction to move in, in units per second.</param>
    public void Move(Vector3 directionUnitsPerSecond);


    /// <summary>
    /// Turn in the direction specified.
    /// </summary>
    /// <param name="degreesPerSecond">The amount to turn, in degrees per second.</param>
    public void Turn(float degreesPerSecond);

}
