using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int InitialLife = 100;
    public float Velocity = 4;
    //[HideInInspector]
    public int Life;
    private void Awake()
    {
        Life = InitialLife;
   
    }
}
