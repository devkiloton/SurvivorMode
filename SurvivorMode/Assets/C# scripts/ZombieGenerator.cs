using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject Zombie;
    float Clock = 0;
    private float timeToGenZombie = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Clock += Time.deltaTime;
        if(Clock >= timeToGenZombie)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
            Clock = 0;
        }
    }
}
