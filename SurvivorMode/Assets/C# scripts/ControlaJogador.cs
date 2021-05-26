using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float Velocity = 10;
    public Vector3 Direction;
    public LayerMask FloorMask;
    public GameObject GameOverText;
    public int LifeBar = 100;
    public UIController ScrUIController;
    public AudioClip DamageSound;
    private PlayerMovement myPlayerAnimatorAndRotation;
    private AnimationsController myMovements;
    private void Start()
    {
        Time.timeScale = 1;
        myPlayerAnimatorAndRotation = GetComponent<PlayerMovement>();
        myMovements = GetComponent<AnimationsController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Direction = new Vector3(x, 0, z);

        myMovements.MovementPlayer("Moving", Direction.magnitude);
        if (LifeBar <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }
    void FixedUpdate()
    {
        myPlayerAnimatorAndRotation.KeyboardMovement(Direction,Velocity);
        myPlayerAnimatorAndRotation.PlayerRotation(FloorMask);
    }
    public void GetDamage(int damage)
    {
        LifeBar -= damage;
        AudioController.instance.PlayOneShot(DamageSound);
        ScrUIController.LifeBarClock();
        if (LifeBar <= 0)
        {
            Time.timeScale = 0;
            GameOverText.SetActive(true);
        }
    }
}
