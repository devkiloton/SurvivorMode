using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IDamage, ICure
{

    public Vector3 Direction;
    public LayerMask FloorMask;
    public GameObject GameOverText;
    public UIController ScrUIController;
    public AudioClip DamageSound;
    private PlayerMovement myPlayerAnimatorAndRotation;
    private AnimationsController myMovements;
    public Status myStatus;
    private int timeToDontReceiveDamageSec = 1;
    private void Start()
    {
        myPlayerAnimatorAndRotation = GetComponent<PlayerMovement>();
        myMovements = GetComponent<AnimationsController>();
        myStatus = GetComponent<Status>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Direction = new Vector3(x, 0, z);

        myMovements.MovementPlayer(Direction.magnitude);
    }
    void FixedUpdate()
    {
        myPlayerAnimatorAndRotation.KeyboardMovement(Direction, myStatus.Velocity);
        myPlayerAnimatorAndRotation.PlayerRotation(FloorMask);
    }
    public void GetDamage(int damage)
    {
        if (Time.timeSinceLevelLoad > timeToDontReceiveDamageSec)
        {
            myStatus.Life -= damage;
            AudioController.instance.PlayOneShot(DamageSound);
            ScrUIController.LifeBarClock();
            if (myStatus.Life <= 0)
            {
                Death();
            }
        }
    }
    public void Death()
    {
        ScrUIController.GameOver();
    }
    public void CureValue(int value)
    {
        myStatus.Life += value;
        if(myStatus.Life > myStatus.InitialLife)
        {
            myStatus.Life = myStatus.InitialLife;
        }
        ScrUIController.LifeBarClock();
    }
}
