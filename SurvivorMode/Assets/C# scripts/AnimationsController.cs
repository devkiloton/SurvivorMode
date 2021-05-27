using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void ZombieAttackAnimation(bool state)
    {
        myAnimator.SetBool("Atacando", state);
    }
    public void MovementPlayer(float x)
    {
        myAnimator.SetFloat("Moving", x);
    }
}
