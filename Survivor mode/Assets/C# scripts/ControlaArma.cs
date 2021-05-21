using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControlaArma : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject bullet_out;
    public GameObject bullet_out_running;
    public Vector3 Direction;
    void Start()
    {

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Direction = new Vector3(x, 0, z);
        if (Input.GetButtonDown("Fire1"))
        {
            if (Direction != Vector3.zero)
            {
                Instantiate(Bullet, bullet_out_running.transform.position, bullet_out_running.transform.rotation);
            }
            else
            {
                Instantiate(Bullet, bullet_out.transform.position, bullet_out.transform.rotation);
            }
        }
    }
}