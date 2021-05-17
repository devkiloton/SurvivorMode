using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocity = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 Direction = Jogador.transform.position - transform.position;
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            Direction.normalized * Velocity * Time.deltaTime);
    }
}
