using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject Jogador;
    Vector3 DistCompensar;
    void Start()
    {
        DistCompensar = transform.position - Jogador.transform.position;
    }
    void Update()
    {
        GetComponent<Transform>().position = Jogador.transform.position + DistCompensar;
    }
}
