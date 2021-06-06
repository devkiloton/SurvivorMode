using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicPack : MonoBehaviour
{
    private readonly int timeDestructionMedicPack = 5;
    private readonly int cureValue = 20;
    private void Start()
    {
        Destroy(gameObject, timeDestructionMedicPack);
    }
    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject.CompareTag("Player"))
        {
            collisionObject.GetComponent<PlayerController>().CureValue(cureValue);
            Destroy(gameObject);
        }
    }
}
