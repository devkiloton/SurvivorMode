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
    private SpriteMovements myMovements;
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        int RandNum = Random.Range(1, 28);
        transform.GetChild(RandNum).gameObject.SetActive(true);
        controlJogador = Jogador.GetComponent<ControlaJogador>();
        rigidZombie = GetComponent<Rigidbody>();
        animatorZombie = GetComponent<Animator>();
        myMovements = GetComponent<SpriteMovements>();
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 Direction = Jogador.transform.position - transform.position;
        myMovements.QuarternionRotation(Direction);
        if (distance > 2.8)
        {
            myMovements.Movement(Direction, Velocity);
            animatorZombie.SetBool("Atacando", false);
        }
        else
        {
            animatorZombie.SetBool("Atacando", true);
        }
    }
    public void ZombieAttack()
    {
        int damage = Random.Range(20, 30);
        controlJogador.GetDamage(damage);
    } 
}