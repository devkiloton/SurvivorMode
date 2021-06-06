using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Player;
    Vector3 DistCompensar;
    private void Start()
    {
        DistCompensar = transform.position - Player.transform.position;
    }
    private void Update()
    {
        GetComponent<Transform>().position = Player.transform.position + DistCompensar;
    }
}
