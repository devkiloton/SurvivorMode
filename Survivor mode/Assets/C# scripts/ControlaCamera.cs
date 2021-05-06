using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject Jogador;
    Vector3 DistCompensar;

    // Start is called before the first frame update
    void Start()
    {
        DistCompensar = transform.position - Jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = Jogador.transform.position + DistCompensar;
    }
}
