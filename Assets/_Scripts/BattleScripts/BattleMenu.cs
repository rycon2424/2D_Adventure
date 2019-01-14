using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{
    //turn = who.player;
    public enum who { player, enemy1, enemy2, enemy3};
    public who turn;
    private BattlePartyInfo chars;

    [Header("Enemy Names")]
    public string enemyName1;
    public RawImage enemy1Sprite;
    public string enemyName2;
    public RawImage enemy2Sprite;
    public string enemyName3;
    public RawImage enemy3Sprite;
    public Texture[] enemySprites = new Texture[3];

    [Header("Background")]
    public string areaName;
    public RawImage background;
    public Texture[] backgrounds = new Texture[3];
    [Header("EnemyNumbers")]
    public int enemyCount;
    public GameObject[] enemys = new GameObject[3];

    private bool tempfix;
    private bool tempfix2;
    [Header("Attack Options")]
    public GameObject wholeChoiceBar;
    public Animator choiceAnimation;
    public GameObject choiceIcon;
    private int choice;
    private bool choiceMade;
    public int whatCharacter = 1;
    [Header("Choose Enemy")]
    public GameObject enemyNameBar;
    public Text displayedEnemyName;
    public GameObject chooseEnemyIcon;
    public Animator enemyChoiceAnim;
    private int enemyChoice = 1;
    [Header("Finger Options")]
    public bool characterSelected;
    public GameObject fingerObject;
    public Animator fingerAnimation;

    void Start()
    {
        chars = GameObject.FindGameObjectWithTag("PlayerPartyStats").GetComponent<BattlePartyInfo>();
        choiceMade = false;
        chooseEnemyIcon.SetActive(false);
        choiceIcon.SetActive(false);
        enemyNameBar.SetActive(false);
        if (enemyCount > 0)
        {
            enemys[0].SetActive(true);
        }
        else
        {
            enemys[0].SetActive(false);
        }
        if (enemyCount > 1)
        {
            enemys[1].SetActive(true);
        }
        else
        {
            enemys[1].SetActive(false);
        }
        if (enemyCount > 2)
        {
            enemys[2].SetActive(true);
        }
        else
        {
            enemys[2].SetActive(false);
        }
    }

    void Update()
    {

        BattleSettings();

        if (!characterSelected)
        {
            SelectCharacter();
            wholeChoiceBar.SetActive(false);
        }
        if (characterSelected && !choiceMade)
        {
            SelectOption();
            wholeChoiceBar.SetActive(true);
        }
        if (choiceMade)
        {
            ShowOptions();
            wholeChoiceBar.SetActive(false);
        }
    }

    // FIRST OPTION
    void SelectCharacter()
    {
        if (chars.numberOfPartyMembers != 1)
        {
            if (chars.numberOfPartyMembers == 2)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (whatCharacter == 2)
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
                        whatCharacter = 2;
                    }
                    else
                    {
                        whatCharacter--;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
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
                if (Input.GetKeyDown(KeyCode.D))
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
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            choice = 1;
            characterSelected = true;
            fingerObject.SetActive(false);
            choiceIcon.SetActive(true);
            Debug.Log("Character " + whatCharacter);
            StartCoroutine(TempFix());
        }

    }

    // SECOND OPTION
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

        if (Input.GetMouseButtonDown(1))
        {
            fingerObject.SetActive(true);
            choiceIcon.SetActive(false);
            characterSelected = false;
            tempfix = false;
        }

        if (choice == 1 && tempfix)
        {
            choiceAnimation.Play("Attack");
            if (Input.GetMouseButtonDown(0))
            {
                choiceIcon.SetActive(false);
                choiceMade = true;
                chooseEnemyIcon.SetActive(true);
                enemyNameBar.SetActive(true);
                StartCoroutine(TempFix2());
            }
        }
        else if (choice == 2)
        {
            choiceAnimation.Play("Shield");
            Shield();
        }
        else if (choice == 3)
        {
            choiceAnimation.Play("Magic");
            if (Input.GetMouseButtonDown(0))
            {
                choiceIcon.SetActive(false);
                choiceMade = true;
            }
        }
        else if (choice == 4)
        {
            choiceAnimation.Play("Inventory");
            if (Input.GetMouseButtonDown(0))
            {
                choiceIcon.SetActive(false);
                choiceMade = true;
            }
        }
        else if (choice == 5)
        {
            choiceAnimation.Play("Flee");
            Flee();
        }
    }

    void ShowOptions()
    {
        if (choice == 1)
        {
            Attack();
        }
        if (choice == 2)
        {
            Shield();
        }
        if (choice == 3)
        {
            Magic();
        }
        if (choice == 4)
        {
            Inventory();
        }
        if (choice == 5)
        {
            Flee();
        }
    }

    // FINAL CHOICE VV
    void Attack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            choiceMade = false;
            choiceIcon.SetActive(true);
            chooseEnemyIcon.SetActive(false);
            tempfix2 = false;
            enemyNameBar.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
             if (enemyChoice == enemyCount)
             {
                    enemyChoice = 1;
             }
             else
             {
                    enemyChoice++;
             }
            }
        if (Input.GetKeyDown(KeyCode.A))
        {
                if (enemyChoice == 1)
             {
                    enemyChoice = enemyCount;
             }
                else
             {
                    enemyChoice--;
             }
        }
        
        if (enemyChoice == 1 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy1");
            displayedEnemyName.text = enemyName1;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ThrowAttack1");
            }
        }
        if (enemyChoice == 2 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy2");
            displayedEnemyName.text = enemyName2;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ThrowAttack2");
            }
        }
        if (enemyChoice == 3 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy3");
            displayedEnemyName.text = enemyName3;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ThrowAttack3");
            }
        }
    }
    void Shield()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Heal for 10%");
        }
    }
    void Magic()
    {
        if (Input.GetMouseButtonDown(1))
        {
            choiceMade = false;
            choiceIcon.SetActive(true);
        }
    }
    void Inventory()
    {
        if (Input.GetMouseButtonDown(1))
        {
            choiceMade = false;
            choiceIcon.SetActive(true);
        }
    }
    void Flee()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Flee");
        }
    }

    IEnumerator TempFix()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        tempfix = true;
    }
    IEnumerator TempFix2()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        tempfix2 = true;
    }


    void BattleSettings()
    {
        #region Enemy Sprites
        if (enemyCount > 0)
        {
            if (enemyName1 == "Rebecca")
            {
                enemy1Sprite.texture = enemySprites[0];
            }
        }
        if (enemyCount > 1)
        {
            
        }
        if (enemyCount > 2)
        {
            
        }
        #endregion

        #region Backgrounds
        if (areaName == "Beach")
        {
            background.texture = backgrounds[0];
        }
        #endregion
    }

}