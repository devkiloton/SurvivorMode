using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, IDamage
{
    public GameObject Jogador;
    private PlayerController controlJogador;
    private SpriteMovements myMovements;
    private AnimationsController myAnimator;
    private Status myStatus;
    public AudioClip ZombieDeathSong;
    private Vector3 randomPosition;
    private Vector3 Direction;
    private float clockZombieChangePosition;
    private readonly float timeZombieChangePosition = 4;
    private readonly float probabilityGenerateMedicKit = 0.1f;
    public GameObject MedicKit;
    private UIController scrUIController;
    [HideInInspector]
    public ZombieGenerator zombieGenerator;
    public GameObject ZombieBlood;
    public int distanceZombiesFollowPlayer = 20;
    public float timeUpgradeDistanceZombiesFollowPlayer = 15;
    public float timeNextGen;
    private void Start()
    {
        timeNextGen = timeUpgradeDistanceZombiesFollowPlayer;
        Jogador = GameObject.FindWithTag(Tags.Player);
        controlJogador = Jogador.GetComponent<PlayerController>();
        myMovements = GetComponent<SpriteMovements>();
        myAnimator = GetComponent<AnimationsController>();
        ZombieRandomizer();
        myStatus = GetComponent<Status>();
        scrUIController = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);
        myMovements.QuarternionRotation(Direction);
        myAnimator.MovementPlayer(Direction.magnitude);
        if (distance > distanceZombiesFollowPlayer)
        {
            
            ZombieWalking();
            myAnimator.ZombieAttackAnimation(false);
            if (Time.timeSinceLevelLoad > timeNextGen)
            {
                distanceZombiesFollowPlayer += 10;
                timeNextGen = Time.timeSinceLevelLoad + timeUpgradeDistanceZombiesFollowPlayer;
            }
        }
        else if (distance > 2.8)
        {
            Direction = Jogador.transform.position - transform.position;
            myMovements.Movement(Direction, myStatus.Velocity);
            myAnimator.ZombieAttackAnimation(false);
        }
        else
        {
            Direction = Jogador.transform.position - transform.position;
            myAnimator.ZombieAttackAnimation(true);
        }
    }
    private void ZombieWalking()
    {
        clockZombieChangePosition -= Time.deltaTime;
        if(clockZombieChangePosition <= 0)
        {
            randomPosition = positionRandomizerSphere();
            clockZombieChangePosition += timeZombieChangePosition + Random.Range(-1.5f, 1.5f);
        }
        bool nearEnough = Vector3.Distance(transform.position, randomPosition) <= 0.1;
        
        if (nearEnough == false)
        {
            Direction = randomPosition - transform.position;
            myMovements.Movement(Direction, myStatus.Velocity);
        }
    }
    Vector3 positionRandomizerSphere()
    {
        Vector3 positionZombie = Random.insideUnitSphere * 10;
        positionZombie += transform.position;
        positionZombie.y = transform.position.y;
        return positionZombie;
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
    public void GetDamage(int damage)
    {
        myStatus.Life -= damage;
        if (myStatus.Life <= 0)
        {
            Death();
            scrUIController.ZombieCounterUpdate();
        }
    }
    public void Death()
    {
        Destroy(gameObject, 6);
        myAnimator.DeathAnimation();
        myMovements.Death();
        this.enabled = false;
        AudioController.Instance.PlayOneShot(ZombieDeathSong);
        verifyToGenerateMedicKit(probabilityGenerateMedicKit);
        zombieGenerator.ReduceZombies();
    }
    private void verifyToGenerateMedicKit(float probabilityGenerateMedicKit)
    {
        if(Random.value <= probabilityGenerateMedicKit)
        {
            Instantiate(MedicKit, transform.position, Quaternion.identity);
        }
    }
    public void ZombieBloodMethod(Vector3 position, Quaternion rotation)
    {
        Instantiate(ZombieBlood, position, rotation);
    }
}