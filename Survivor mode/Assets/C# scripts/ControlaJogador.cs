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
    public bool Life = true;
    private Rigidbody rigibodyPlayer;
    private Animator animatorPlayer;
    private void Start()
    {
        Time.timeScale = 1;
        rigibodyPlayer = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Direction = new Vector3(x, 0, z);

        if (Direction != Vector3.zero)
        {
            animatorPlayer.SetBool("movendo", true);
        }
        else
        {
            animatorPlayer.SetBool("movendo", false);
        }
        if (Life == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }

        }

    }
    void FixedUpdate()
    {
        rigibodyPlayer.MovePosition
                (rigibodyPlayer.position +
                (Direction * Velocity * Time.deltaTime));
        Ray sight = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impact;
        Debug.DrawRay(sight.origin, sight.direction*100, Color.red);
        if(Physics.Raycast(sight, out impact, 100, FloorMask))
        {
            Vector3 PlayerSight = impact.point - transform.position;
            PlayerSight.y = transform.position.y;
            Quaternion NewRotation = Quaternion.LookRotation(PlayerSight);
            rigibodyPlayer.MoveRotation(NewRotation);
        }
    }
}
