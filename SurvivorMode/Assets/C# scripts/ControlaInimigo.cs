using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocity = 4;
    private ControlaJogador controlJogador;
    private SpriteMovements myMovements;
    private AnimationsController myAnimator;
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        controlJogador = Jogador.GetComponent<ControlaJogador>();
        myMovements = GetComponent<SpriteMovements>();
        myAnimator = GetComponent<AnimationsController>();
        ZombieRandomizer();

    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 Direction = Jogador.transform.position - transform.position;
        myMovements.QuarternionRotation(Direction);
        if (distance > 2.8)
        {
            myMovements.Movement(Direction, Velocity);
            myAnimator.ZombieAttackAnimation(false);
        }
        else
        {
            myAnimator.ZombieAttackAnimation(true);
        }
    }
    public void ZombieAttack()
    {
        int damage = Random.Range(20, 30);
        controlJogador.GetDamage(damage);
    } 

    public void ZombieRandomizer()
    {
        int RandNum = Random.Range(1, 28);
        transform.GetChild(RandNum).gameObject.SetActive(true);
    }
}