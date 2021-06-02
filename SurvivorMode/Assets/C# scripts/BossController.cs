using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossController : MonoBehaviour, IDamage
{
    public Transform player;
    private NavMeshAgent agent;
    private Status bossStatus;
    private AnimationsController bossAnimation;
    private SpriteMovements bossMovement;
    public GameObject MedicPack;
    public Slider BossLifeBar;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossStatus = GetComponent<Status>();
        agent.speed = bossStatus.Velocity;
        bossAnimation = GetComponent<AnimationsController>();
        bossMovement = GetComponent<SpriteMovements>();
        BossLifeBar.maxValue = bossStatus.InitialLife;
        SliderLifeUpdate();
    }
    private void Update()
    {
        agent.SetDestination(player.position);
        bossAnimation.MovementPlayer(agent.velocity.magnitude);
        bool nearFromPlayer = agent.remainingDistance <= agent.stoppingDistance;
        if (agent.hasPath == true)
        {
            if (nearFromPlayer)
            {
                bossAnimation.ZombieAttackAnimation(true);
                Vector3 direction = player.position - transform.position;
                bossMovement.QuarternionRotation(direction);
            }
            else
            {
                bossAnimation.ZombieAttackAnimation(false);
            }
        }
    }
    public void ZombieAttack()
    {
        int damage = Random.Range(30, 40);
        player.GetComponent<ControlaJogador>().GetDamage(damage);
    }

    public void GetDamage(int damage)
    {
        bossStatus.Life -= damage;
        SliderLifeUpdate();
        if (bossStatus.Life <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        
        bossAnimation.DeathAnimation();
        bossMovement.Death();
        this.enabled = false;
        agent.enabled = false;
        Instantiate(MedicPack, transform.position, Quaternion.identity);
        Destroy(gameObject, 6);

    }
    public void SliderLifeUpdate()
    {
        BossLifeBar.value = bossStatus.Life;
    }
}
