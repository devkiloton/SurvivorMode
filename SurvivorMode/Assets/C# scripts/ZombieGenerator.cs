using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject Zombie;
    float Clock = 0;
    private float timeToGenZombie = 1;
    public LayerMask LayerZombie;
    private float generatorDistance = 3;
    private float distanceFromPlayerToGenerateZombie = 20;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayerToGenerateZombie)
        {
            Clock += Time.deltaTime;
            if (Clock >= timeToGenZombie)
            {
                StartCoroutine(newZombie());
                Clock = 0;
            }
        } 
    }
    Vector3 positionRandomizerSphere()
    {
        Vector3 positionZombie = Random.insideUnitSphere * generatorDistance;
        positionZombie += transform.position;
        positionZombie.y = transform.position.y;
        return positionZombie;
    }
    IEnumerator newZombie()
    {
        Vector3 position = positionRandomizerSphere();
        Collider[] colliders = Physics.OverlapSphere(position, 1, LayerZombie);
        while(colliders.Length > 0)
        {
            position = positionRandomizerSphere();
            colliders = Physics.OverlapSphere(position, 1, LayerZombie);
            yield return null;
        }
        Instantiate(Zombie, position, transform.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, generatorDistance);
    }
}
