using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocity = 4;
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
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);
        if (distance > 2.5)
        {
            Vector3 Direction = Jogador.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                Direction.normalized * Velocity * Time.deltaTime);
        

        Quaternion NewRotation = Quaternion.LookRotation(Direction);

        GetComponent<Rigidbody>().MoveRotation(NewRotation);
        }
    }
}
