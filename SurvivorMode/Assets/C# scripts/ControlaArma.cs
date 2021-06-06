using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControlaArma : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletOut;
    public GameObject BulletOutRunning;
    public GameObject FireOnGun;
    public GameObject FireOnGunPosition;
    public GameObject FireOnGunPositionRunning;
    public AudioClip BulletSound;
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<ControlaJogador>().Direction != Vector3.zero)
            {
                Instantiate(Bullet, BulletOutRunning.transform.position, BulletOutRunning.transform.rotation);
                Instantiate(FireOnGun, FireOnGunPositionRunning.transform.position, FireOnGunPositionRunning.transform.rotation);
                AudioController.instance.PlayOneShot(BulletSound);
            }
            else
            {
                Instantiate(Bullet, BulletOut.transform.position, BulletOut.transform.rotation);
                Instantiate(FireOnGun, FireOnGunPosition.transform.position, FireOnGunPosition.transform.rotation);
                AudioController.instance.PlayOneShot(BulletSound);
            }
        }
    }
}