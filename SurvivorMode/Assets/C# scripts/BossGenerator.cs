using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    private float timeNextGen = 0;
    public float TimeBetweenGen = 15;
    public GameObject BossPrefab;
    public Transform[] PossibleCoordinatesBossBorns;
    private Transform player;
    private void Start()
    {
        timeNextGen = TimeBetweenGen;
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad >= timeNextGen)
        {
            Vector3 genPosition = computeBiggestDistanceFromPlayer();
            Instantiate(BossPrefab, genPosition, Quaternion.identity);
            timeNextGen = Time.timeSinceLevelLoad + TimeBetweenGen;
        }
    }
    private Vector3 computeBiggestDistanceFromPlayer()
    {
        Vector3 biggestDistanceFromPlayer = Vector3.zero;
        float biggestDistance = 0;
        foreach(Transform position in PossibleCoordinatesBossBorns)
        {
            float distanceBetweenGeneratorFromPlayer = Vector3.Distance(position.position, player.position);
            if (distanceBetweenGeneratorFromPlayer > biggestDistance)
            {
                biggestDistance = distanceBetweenGeneratorFromPlayer;
                biggestDistanceFromPlayer = position.position;
            }
        }
        return biggestDistanceFromPlayer;
    }
}
