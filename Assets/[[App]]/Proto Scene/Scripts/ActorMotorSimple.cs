using UnityEngine;


/// <summary>
/// A simple actor motor.
/// </summary>
public class ActorMotorSimple : MonoBehaviour, IActorMotor
{
    /// <summary>Move speed, in units per second.</summary>
    protected float moveSpeedUnitsPerSecond = 5.0f;

    /// <summary>Turn speed, in degrees per second.</summary>
    protected float turnSpeedDegreesPerSecond = 100.0f;



    /// <inheritdoc />
    public void Move(Vector3 directionUnitsPerSecond) {
        directionUnitsPerSecond *= Time.deltaTime * moveSpeedUnitsPerSecond;
        Vector3 pos = transform.position;
        pos += directionUnitsPerSecond;
        transform.position = pos;
    }


    /// <inheritdoc />
    public void Turn(float degreesPerSecond) {
        transform.rotation *= Quaternion.Euler(0, degreesPerSecond * Time.deltaTime * turnSpeedDegreesPerSecond, 0);
    }

}
