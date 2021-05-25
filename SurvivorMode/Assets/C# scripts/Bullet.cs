using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Velocity = 50;
    public AudioClip ZombieDeathSong;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward * Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider CollisionObject)
    {
        if (CollisionObject.tag == "Inimigo")
        {
            Destroy(CollisionObject.gameObject);
            AudioController.instance.PlayOneShot(ZombieDeathSong);
        }
        Destroy(gameObject);
    }
}