using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour, IDamage
{
    
    public Vector3 Direction;
    public LayerMask FloorMask;
    public GameObject GameOverText;
    public UIController ScrUIController;
    public AudioClip DamageSound;
    private PlayerMovement myPlayerAnimatorAndRotation;
    private AnimationsController myMovements;
    public Status myStatus;
    private void Start()
    {
        Time.timeScale = 1;
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
        if (myStatus.Life <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }
    void FixedUpdate()
    {
        myPlayerAnimatorAndRotation.KeyboardMovement(Direction,myStatus.Velocity);
        myPlayerAnimatorAndRotation.PlayerRotation(FloorMask);
    }
    public void GetDamage(int damage)
    {
        myStatus.Life -= damage;
        AudioController.instance.PlayOneShot(DamageSound);
        ScrUIController.LifeBarClock();
        if (myStatus.Life <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Time.timeScale = 0;
        GameOverText.SetActive(true);
    }
}
