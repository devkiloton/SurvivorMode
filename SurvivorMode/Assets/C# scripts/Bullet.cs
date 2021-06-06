using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Velocity = 50;
    public AudioClip ZombieDeathSong;
    private readonly int shotDamage = 1;
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward * Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider CollisionObject)
    {
        Quaternion oppositeRotationBullet = Quaternion.LookRotation(transform.forward);
        switch (CollisionObject.tag)
        {
            case "Inimigo":
                ZombieController player = CollisionObject.GetComponent<ZombieController>();
                player.ZombieBloodMethod(transform.position, oppositeRotationBullet);
                player.GetDamage(shotDamage);
                break;
            case "Boss":
                BossController boss = CollisionObject.GetComponent<BossController>();
                boss.BossBloodMethod(transform.position, oppositeRotationBullet);
                boss.GetDamage(shotDamage);
                break;
        }
        Destroy(gameObject);
    }
}