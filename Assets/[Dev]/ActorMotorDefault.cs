using UnityEngine;


public class ActorMotorDefault : MonoBehaviour, IActorMotor
{
    float motorSpeedUnitsPerSecond = 5.0f;

    public void Move(Vector3 direction) {

        direction.Normalize();
        direction *= Time.deltaTime * motorSpeedUnitsPerSecond;
        Vector3 pos = transform.position;
        pos += direction;
        transform.position = pos;
    }

}
