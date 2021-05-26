using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SpriteMovements
{
    private Vector3 diference;
    private ControlaJogador direction;
    private void Awake()
    {
        direction = GetComponent<ControlaJogador>();
    }
    public void PlayerRotation(LayerMask FloorMask)
    {
        Ray sight = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impact;
        Debug.DrawRay(sight.origin, sight.direction);
        if (Physics.Raycast(sight, out impact, 100, FloorMask))
        {
            Vector3 PlayerSight = impact.point - transform.position;
            PlayerSight.y = transform.position.y;
            QuarternionRotation(PlayerSight);
        }
    }
}
