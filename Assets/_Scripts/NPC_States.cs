using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_States : MonoBehaviour {

    public bool idleForward, idleBack, idleLeft, idleRight;

    public bool walkForward, walkBack, walkLeft, walkRight;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        if (idleForward)
        {
            anim.Play("Idle_Forward");
        }
        else if (idleBack)
        {
            anim.Play("Idle_Back");
        }
        else if (idleLeft)
        {
            anim.Play("Idle_Left");
        }
        else if (idleRight)
        {
            anim.Play("Idle_Right");
        }
        else if (walkForward)
        {
            anim.Play("Walk_Forward");
        }
        else if (walkBack)
        {
            anim.Play("Walk_Back");
        }
        else if (walkLeft)
        {
            anim.Play("Walk_Left");
        }
        else if (walkRight)
        {
            anim.Play("Walk_Right");
        }
	}
}