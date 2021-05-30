using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicPack : MonoBehaviour
{
    private int timeDestructionMedicPack = 5;
    private int cureValue = 20;
    private void Start()
    {
        Destroy(gameObject, timeDestructionMedicPack);
    }
    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject.CompareTag("Player"));
        {
            collisionObject.GetComponent<ControlaJogador>().CureValue(cureValue);
            Destroy(gameObject);
        }
    }
}
