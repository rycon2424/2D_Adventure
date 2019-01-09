using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool WalkTest;
    public _Player playerScript;
    public bool following;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<_Player>();
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
        }
    }

    void Follow()
    {

    }

}
