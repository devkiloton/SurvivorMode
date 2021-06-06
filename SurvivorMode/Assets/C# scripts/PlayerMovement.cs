using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SpriteMovements
{
    public GameObject AimPosition;
    public void PlayerRotation(LayerMask FloorMask)
    {
        Ray sight = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane aimPlane = new Plane(Vector3.up, AimPosition.transform.position);
        if (aimPlane.Raycast(sight, out float colisionDistance))
        {
            Vector3 colisionCoordinates = sight.GetPoint(colisionDistance);
            colisionCoordinates.y = 0;
            Vector3 PlayerSight = colisionCoordinates - transform.position;
            QuarternionRotation(PlayerSight);
        }
    }
}