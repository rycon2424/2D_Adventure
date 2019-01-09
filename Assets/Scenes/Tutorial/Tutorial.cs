using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool WalkTest;
    public GameObject WalkText;
    public _Player playerScript;
    public bool following;
    public Animator anim;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<_Player>();
        playerScript.enabled = false;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (WalkTest)
        {
            Walk();
        }

        if (following)
        {
            Follow();
        }
    }

    void Walk()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            playerScript.enabled = true;
            following = true;
            WalkTest = false;
            Destroy(WalkText);
            anim.Play("TutorialPart2");
        }
    }

    void Follow()
    {

    }

}
