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
        Quaternion oppositeRotationBullet = Quaternion.LookRotation(transform.forward);
        switch (CollisionObject.tag)
        {
            case "Inimigo":
                ControlaInimigo player = CollisionObject.GetComponent<ControlaInimigo>();
                player.ZombieBloodMethod(transform.position, oppositeRotationBullet);
                player.GetDamage(danoDoTiro);
                break;
            case "Boss":
                BossController boss = CollisionObject.GetComponent<BossController>();
                boss.BossBloodMethod(transform.position, oppositeRotationBullet);
                boss.GetDamage(danoDoTiro);
                break;
        }
        Destroy(gameObject);
    }
}