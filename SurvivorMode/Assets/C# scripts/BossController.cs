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
    public AudioClip ZombieDeathSong;
    public Slider BossLifeBar;
    public UIController scrUIController;
    public Image SliderImage;
    public Color MaxLifeColor, MinLifeColor;
    public GameObject BossBlood;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossStatus = GetComponent<Status>();
        agent.speed = bossStatus.Velocity;
        bossAnimation = GetComponent<AnimationsController>();
        bossMovement = GetComponent<SpriteMovements>();
        scrUIController = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
        BossLifeBar.maxValue = bossStatus.InitialLife;
        SliderLifeUpdate();
    }
    private void Update()
    {
        agent.SetDestination(player.position);
        bossAnimation.MovementPlayer(agent.velocity.magnitude);
        if (agent.hasPath == true)
        {
            bool nearFromPlayer = agent.remainingDistance <= agent.stoppingDistance + 3.5;
            if (nearFromPlayer)
            {
                agent.velocity = Vector3.zero;
                Vector3 direction = player.position - transform.position;
                bossMovement.QuarternionRotation(direction);
                bossAnimation.ZombieAttackAnimation(true);
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
        AudioController.instance.PlayOneShot(ZombieDeathSong);
        scrUIController.ZombieCounterUpdate();
        Destroy(gameObject, 6);
    }
    public void SliderLifeUpdate()
    {
        BossLifeBar.value = bossStatus.Life;
        float lifePercentage = (float)bossStatus.Life / bossStatus.InitialLife;
        Color lifeColor = Color.Lerp(MinLifeColor, MaxLifeColor, lifePercentage);
        SliderImage.color = lifeColor;
    }
    public void BossBloodMethod(Vector3 position, Quaternion rotation)
    {
        Instantiate(BossBlood, position, rotation);
    }
}
