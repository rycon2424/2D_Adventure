using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public Animator choiceAnimation;
    public int whatCharacter = 1;
    [Header("Finger Options")]
    public bool characterSelected;
    public GameObject fingerObject;
    public Animator fingerAnimation;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (!characterSelected)
        {
            SelectCharacter();
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
    }

}