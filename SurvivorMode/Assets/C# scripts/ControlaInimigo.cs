using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocity = 4;
    private ControlaJogador controlJogador;
    private Rigidbody rigidZombie;
    private Animator animatorZombie;
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        int RandNum = Random.Range(1, 28);
        transform.GetChild(RandNum).gameObject.SetActive(true);
        controlJogador = Jogador.GetComponent<ControlaJogador>();
        rigidZombie = GetComponent<Rigidbody>();
        animatorZombie = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 Direction = Jogador.transform.position - transform.position;
        Quaternion NewRotation = Quaternion.LookRotation(Direction);
        rigidZombie.MoveRotation(NewRotation);
        if (distance > 2.5)
        {
            rigidZombie.MovePosition
                (rigidZombie.position +
                Direction.normalized * Velocity * Time.deltaTime);
            animatorZombie.SetBool("Atacando", false);
        }
        else
        {
            animatorZombie.SetBool("Atacando", true);
        }
    }
    void ZombieAttack()
    {
        Time.timeScale = 0;
        controlJogador.GameOverText.SetActive(true);
        controlJogador.Life = false;
    } 
}