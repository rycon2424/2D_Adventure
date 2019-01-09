using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    [Header("Attack Options")]
    public Animator choiceAnimation;
    public GameObject choiceIcon;
    private int choice;
    public int whatCharacter = 1;
    [Header("Finger Options")]
    public bool characterSelected;
    public GameObject fingerObject;
    public Animator fingerAnimation;

    void Start()
    {
        choiceIcon.SetActive(false);
    }

    void Update()
    {
        if (!characterSelected)
        {
            SelectCharacter();
        }
        if (characterSelected)
        {
            SelectOption();
        }
    }

    void SelectOption()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (choice == 5)
            {
                choice = 1;
            }
            else
            {
                choice++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (choice == 1)
            {
                choice = 5;
            }
            else
            {
                choice--;
            }
        }

        if (choice == 1)
        {
            choiceAnimation.Play("Attack");
        }
        else if (choice == 2)
        {
            choiceAnimation.Play("Shield");
        }
        else if (choice == 3)
        {
            choiceAnimation.Play("Magic");
        }
        else if (choice == 4)
        {
            choiceAnimation.Play("Inventory");
        }
        else if (choice == 5)
        {
            choiceAnimation.Play("Flee");
        }
    }

    void SelectCharacter()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (whatCharacter == 3)
            {
                whatCharacter = 1;
            }
            else
            {
                whatCharacter++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (whatCharacter == 1)
            {
                whatCharacter = 3;
            }
            else
            {
                whatCharacter--;
            }
        }
        if (whatCharacter == 1)
        {
            fingerAnimation.Play("FingerAnimationPlayer1");
        }
        else if (whatCharacter == 2)
        {
            fingerAnimation.Play("FingerAnimationPlayer2");
        }
        else if (whatCharacter == 3)
        {
            fingerAnimation.Play("FingerAnimationPlayer3");
        }
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.KeypadEnter))
        {
            choice = 1;
            characterSelected = true;
            fingerObject.SetActive(false);
            choiceIcon.SetActive(true);
            Debug.Log(whatCharacter);
        }
    }
}