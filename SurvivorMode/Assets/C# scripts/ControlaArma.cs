using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControlaArma : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletOut;
    public GameObject BulletOutRunning;
    void Start()
    {

    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<ControlaJogador>().Direction != Vector3.zero)
            {
                Instantiate(Bullet, BulletOutRunning.transform.position, BulletOutRunning.transform.rotation);
            }
            else
            {
                Instantiate(Bullet, BulletOut.transform.position, BulletOut.transform.rotation);
            }
        }
    }
}