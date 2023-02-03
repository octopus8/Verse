using UnityEngine;


public class ActorMotorSimple : MonoBehaviour, IActorMotor
{
    float motorSpeedUnitsPerSecond = 5.0f;
    float turnSpeedDegreesPerSecond = 100.0f;

    public void Move(Vector3 direction) {
        direction *= Time.deltaTime * motorSpeedUnitsPerSecond;
        Vector3 pos = transform.position;
        pos += direction;
        transform.position = pos;
    }


    public void Turn(float value) {
        transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime * turnSpeedDegreesPerSecond, 0);
    }

}
