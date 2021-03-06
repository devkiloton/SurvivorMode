using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject Zombie;
    float Clock = 0;
    private readonly float timeToGenZombie = 1;
    public LayerMask LayerZombie;
    private readonly float generatorDistance = 3;
    private readonly float distanceFromPlayerToGenerateZombie = 20;
    private GameObject player;
    private int maxNumberZombiesAlive = 3;
    public int numberZombiesAlive;
    private int timeNextLevelSec = 10;
    private int numZombies;

    private void Start()
    {
        numZombies = timeNextLevelSec;
        player = GameObject.FindWithTag("Player");
        for (int i = 0; i < maxNumberZombiesAlive; i++)
        {
            StartCoroutine(newZombie());
        }
    }
    private void Update()
    {
        bool distanceToGenerate = Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayerToGenerateZombie;
        bool maxNumber = numberZombiesAlive < maxNumberZombiesAlive;
        if (distanceToGenerate == true && maxNumber)
        {
            Clock += Time.deltaTime;
            if (Clock >= timeToGenZombie)
            {
                StartCoroutine(newZombie());
                Clock = 0;
            }
            int timeToLoadNextLevel = (int)Time.timeSinceLevelLoad;
            if (timeToLoadNextLevel > timeNextLevelSec)
            {
                maxNumberZombiesAlive++;
                timeNextLevelSec += timeToLoadNextLevel + numZombies;
            }
        } 
    }
    private Vector3 positionRandomizerSphere()
    {
        Vector3 positionZombie = Random.insideUnitSphere * generatorDistance;
        positionZombie += transform.position;
        positionZombie.y = 0;
        return positionZombie;
    }
    private IEnumerator newZombie()
    {
        Vector3 position = positionRandomizerSphere();
        Collider[] colliders = Physics.OverlapSphere(position, 1, LayerZombie);
        while(colliders.Length > 0)
        {
            position = positionRandomizerSphere();
            colliders = Physics.OverlapSphere(position, 1, LayerZombie);
            yield return null;
        }
        ZombieController zombie = Instantiate(Zombie, position, transform.rotation)
                                            .GetComponent<ZombieController>();
        zombie.zombieGenerator = this;
        numberZombiesAlive++;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, generatorDistance);
    }
    public void ReduceZombies()
    {
        numberZombiesAlive--;
    }
}
