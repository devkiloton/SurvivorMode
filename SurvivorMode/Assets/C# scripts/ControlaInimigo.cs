using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IDamage
{
    public GameObject Jogador;
    private ControlaJogador controlJogador;
    private SpriteMovements myMovements;
    private AnimationsController myAnimator;
    private Status myStatus;
    public AudioClip ZombieDeathSong;
    private Vector3 randomPosition;
    private Vector3 Direction;
    private float clockZombieChangePosition;
    private float timeZombieChangePosition = 4;
    private float probabilityGenerateMedicKit = 0.1f;
    public GameObject MedicKit;
    private UIController scrUIController;
    void Start()
    {
        Jogador = GameObject.FindWithTag(Tags.Player);
        controlJogador = Jogador.GetComponent<ControlaJogador>();
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
        if (distance > 15)
        {
            
            ZombieWalking();
            myAnimator.ZombieAttackAnimation(false);
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
    void ZombieWalking()
    {
        clockZombieChangePosition -= Time.deltaTime;
        if(clockZombieChangePosition <= 0)
        {
            randomPosition = positionRandomizerSphere();
            clockZombieChangePosition += timeZombieChangePosition;
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
        Destroy(gameObject);
        AudioController.instance.PlayOneShot(ZombieDeathSong);
        verifyToGenerateMedicKit(probabilityGenerateMedicKit);
    }
    void verifyToGenerateMedicKit(float probabilityGenerateMedicKit)
    {
        if(Random.value <= probabilityGenerateMedicKit)
        {
            Instantiate(MedicKit, transform.position, Quaternion.identity);
        }
    }
}