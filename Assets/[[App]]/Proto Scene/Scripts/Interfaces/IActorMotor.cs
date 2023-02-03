using UnityEngine;

public interface IActorMotor 
{

    public void Move(Vector3 direction);

    public void Turn(float value);

}
