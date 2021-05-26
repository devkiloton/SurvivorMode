using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovements : MonoBehaviour
{
    public Rigidbody myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }
    public void Movement(Vector3 direction, float velocity)
    {
        myBody.MovePosition(myBody.position +
                           (direction.normalized * velocity * Time.deltaTime));
    }
    public void KeyboardMovement(Vector3 direction, float velocity)
    {
        myBody.MovePosition(myBody.position +
                           (direction * velocity * Time.deltaTime));
    }
    public void QuarternionRotation(Vector3 direction)
    {
        Quaternion NewRotation = Quaternion.LookRotation(direction);
        myBody.MoveRotation(NewRotation);
    }
}
