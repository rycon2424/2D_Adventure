﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool walkTest;
    public GameObject walkText;
    public GameObject followText;
    public GameObject enterHouseText;
    public GameObject inhouseChat;
    public _Player playerScript;
    public bool following;
    public Animator anim;
    public bool startPart3;
    public bool houseChat;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<_Player>();
        playerScript.enabled = false;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (walkTest)
        {
            Walk();
        }
        
    }

    void Walk()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            playerScript.enabled = true;
            following = true;
            walkTest = false;
            Destroy(walkText);
            followText.SetActive(true);
            anim.Play("TutorialPart2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (houseChat)
        {
            if (collision.CompareTag("Player"))
            {
                inhouseChat.SetActive(true);
                anim.Play("TutorialPart4");
                houseChat = false;
            }
        }

        if (following)
        {
            if (collision.CompareTag("Player"))
            {
                following = false;
                startPart3 = true;
                anim.Play("TutorialPart3");
                houseChat = true;
                Destroy(followText);
                enterHouseText.SetActive(true);
            }
        }
    }

}
