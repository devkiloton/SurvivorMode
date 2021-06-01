using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    private float timeNextGen = 0;
    public float TimeBetweenGen = 10;
    public GameObject BossPrefab;
    private void Start()
    {
        timeNextGen = TimeBetweenGen;
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= timeNextGen)
        {
            Instantiate(BossPrefab, transform.position, Quaternion.identity);
            timeNextGen = Time.timeSinceLevelLoad + TimeBetweenGen;
        }
    }
}
