using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Velocity = 50;
    public AudioClip ZombieDeathSong;
    private int danoDoTiro = 1;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward * Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider CollisionObject)
    {
        switch(CollisionObject.tag)
        {
           case "Inimigo":
                CollisionObject.GetComponent<ControlaInimigo>().GetDamage(danoDoTiro);
                Destroy(gameObject);
            break;
           case "Boss":
                CollisionObject.GetComponent<BossController>().GetDamage(danoDoTiro);
                Destroy(gameObject);
            break;
        }
    }
}