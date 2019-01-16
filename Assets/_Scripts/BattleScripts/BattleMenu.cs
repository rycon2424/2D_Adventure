using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{
    //turn = who.player;
    private enum who { player, enemy1, enemy2, enemy3};
    private who turn;

    private BattlePartyInfo battlePartyRef;

    [Header("Party Stats")]
    public string selectedCharacterName;

    [Header("Enemy Health")]
    public int enemyHP1;
    private int maxHpEnemy1;
    public int enemyHP2;
    private int maxHpEnemy2;
    public int enemyHP3;
    private int maxHpEnemy3;

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
    public GameObject playerInfoBar;
    public GameObject choiceIcon;
    private int choice;
    public bool choiceMade;
    public int whatCharacter = 1;

    [Header("Choose Enemy")]
    public GameObject enemyNameBar;
    public Text displayedEnemyName;
    public GameObject chooseEnemyIcon;
    public RawImage chooseEnemySR;
    public Animator enemyChoiceAnim;
    private int enemyChoice = 1;

    [Header("Finger Options")]
    public bool characterSelected;
    public GameObject fingerObject;
    public Animator fingerAnimation;

    [Header("Effects Animator")]
    public Animator effect1;
    public Animator effect2;
    public Animator effect3;
    public Animator effectPlayer;

    void Start()
    {
        #region EnemyHealthSystem
        maxHpEnemy1 = enemyHP1;
        maxHpEnemy2 = enemyHP2;
        maxHpEnemy3 = enemyHP3;
        #endregion
        battlePartyRef = GameObject.FindGameObjectWithTag("PlayerPartyStats").GetComponent<BattlePartyInfo>();
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

        if (turn == who.player)
        {
            if (!characterSelected)
            {
                SelectCharacter();
                wholeChoiceBar.SetActive(false);
            }
            if (characterSelected && choiceMade == false)
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
    }

    #region PlayerInfo

    // FIRST OPTION
    void SelectCharacter()
    {
        if (battlePartyRef.numberOfPartyMembers != 1)
        {
            if (battlePartyRef.numberOfPartyMembers == 2)
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
            selectedCharacterName = battlePartyRef.partyNames[0];
            fingerAnimation.Play("FingerAnimationPlayer1");
        }
        else if (whatCharacter == 2)
        {
            selectedCharacterName = battlePartyRef.partyNames[1];
            fingerAnimation.Play("FingerAnimationPlayer2");
        }
        else if (whatCharacter == 3)
        {
            selectedCharacterName = battlePartyRef.partyNames[2];
            fingerAnimation.Play("FingerAnimationPlayer3");
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J))
        {
            choice = 1;
            characterSelected = true;
            fingerObject.SetActive(false);
            choiceIcon.SetActive(true);
            StartCoroutine(TempFix());
        }

    }

    // SECOND OPTION
    void SelectOption()
    {
        #region Hovering
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fingerObject.SetActive(true);
            choiceIcon.SetActive(false);
            characterSelected = false;
            tempfix = false;
        }
        #endregion

        if (choice == 1 && tempfix)
        {
            choiceAnimation.Play("Attack");
            if (Input.GetKeyDown(KeyCode.Space))
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                choiceIcon.SetActive(false);
                choiceMade = true;
            }
        }
        else if (choice == 4)
        {
            choiceAnimation.Play("Inventory");
            if (Input.GetKeyDown(KeyCode.Space))
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
        #region Hovering
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
        #endregion
    }

    // FINAL CHOICE VV
    void Attack()
    {
        #region Hovering
        if (Input.GetKeyDown(KeyCode.Q))
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
        #endregion
        ///WHAT ENEMY
        if (enemyChoice == 1 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy1");
            displayedEnemyName.text = enemyName1;
            #region HealthIcon
            if (enemyHP1 <= (maxHpEnemy1 / 4))
            {
                chooseEnemySR.color = Color.red;
            }
            else if (enemyHP1 <= (maxHpEnemy1 / 2))
            {
                chooseEnemySR.color = Color.yellow;
            }
            else
            {
                chooseEnemySR.color = Color.blue;
            }
            #endregion
            if (Input.GetKeyDown(KeyCode.Space))
            {
                #region Throw attack on 1 + Effect
                if (selectedCharacterName == "Player")
                {
                    effect1.Play("Slash");
                }
                if (selectedCharacterName == "Rebecca")
                {
                    effect1.Play("BasicMagic");
                }
                if (selectedCharacterName == "Ivan")
                {
                    effect1.Play("GreenShot");
                }
                #endregion
                NextTurn();
            }
        }
        if (enemyChoice == 2 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy2");
            displayedEnemyName.text = enemyName2;
            #region HealthIcon
            if (enemyHP2 <= (maxHpEnemy2 / 4))
            {
                chooseEnemySR.color = Color.red;
            }
            else if (enemyHP2 <= (maxHpEnemy2 / 2))
            {
                chooseEnemySR.color = Color.yellow;
            }
            else
            {
                chooseEnemySR.color = Color.blue;
            }
            #endregion
            if (Input.GetKeyDown(KeyCode.Space))
            {
                #region Throw attack on 2 + Effect
                if (selectedCharacterName == "Player")
                {
                    effect2.Play("Slash");
                }
                if (selectedCharacterName == "Rebecca")
                {
                    effect2.Play("BasicMagic");
                }
                if (selectedCharacterName == "Ivan")
                {
                    effect2.Play("GreenShot");
                }
                #endregion
                NextTurn();
            }
        }
        if (enemyChoice == 3 && tempfix2)
        {
            enemyChoiceAnim.Play("SelectEnemy3");
            displayedEnemyName.text = enemyName3;
            #region HealthIcon
            if (enemyHP3 <= (maxHpEnemy3 / 4))
            {
                chooseEnemySR.color = Color.red;
            }
            else if (enemyHP3 <= (maxHpEnemy3 / 2))
            {
                chooseEnemySR.color = Color.yellow;
            }
            else
            {
                chooseEnemySR.color = Color.blue;
            }
            #endregion
            if (Input.GetKeyDown(KeyCode.Space))
            {
                #region Throw attack on 3 + Effect
                if (selectedCharacterName == "Player")
                {
                    effect3.Play("Slash");
                }
                if (selectedCharacterName == "Rebecca")
                {
                    effect3.Play("BasicMagic");
                }
                if (selectedCharacterName == "Ivan")
                {
                    effect3.Play("GreenShot");
                }
                #endregion
                NextTurn();
            }
        }
    }
    void Shield()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Heal for 10%");
            choiceMade = true;
            NextTurn();
        }
    }
    void Magic()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            choiceMade = false;
            choiceIcon.SetActive(true);
        }
    }
    void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            choiceMade = false;
            choiceIcon.SetActive(true);
        }
    }
    void Flee()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Flee");
        }
    }

    #endregion

    IEnumerator TempFix()
    {
        yield return null;
        tempfix = true;
    }
    IEnumerator TempFix2()
    {
        yield return null;
        tempfix2 = true;
    }
    
    public void NextTurn() ////TURN SYSTEM
    {
        if (turn == who.player)
        {
            choice = 0;
            int randomInt;
            randomInt = Random.Range(1, enemyCount + 1);
            switch (enemyCount)
            {
                case 1:
                    turn = who.enemy1;
                    break;
                case 2:
                    turn = who.enemy2;
                    break;
                case 3:
                    turn = who.enemy3;
                    break;
            }
            Debug.Log(turn +" has the turn;");
            enemyNameBar.SetActive(false);
            chooseEnemyIcon.SetActive(false);
            wholeChoiceBar.SetActive(false);
            playerInfoBar.SetActive(false);
            EnemyTurn();
        }
        else
        {
            turn = who.player;
            StartCoroutine(ResetPlayerTurn());
        }
    }

    #region Enemy Settings & Attacks
    void BattleSettings()
    {
        // Enemy Sprites
        if (enemyCount > 0)
        {
            if (enemyName1 == "Rebecca")
            {
                enemy1Sprite.texture = enemySprites[0];
            }
        }
        if (enemyCount > 1)
        {
            if (enemyName2 == "Test")
            {
                //enemy1Sprite.texture = enemySprites[0];
            }
        }
        if (enemyCount > 2)
        {
            if (enemyName3 == "Test")
            {
                //enemy1Sprite.texture = enemySprites[0];
            }
        }

        // Backgrounds
        if (areaName == "Beach")
        {
            background.texture = backgrounds[0];
        }
    }

    IEnumerator ResetPlayerTurn()
    {
        yield return new WaitForSeconds(3f);
        characterSelected = false;
        choiceMade = false;
        chooseEnemyIcon.SetActive(false);
        choiceIcon.SetActive(false);
        wholeChoiceBar.SetActive(false);
        enemyNameBar.SetActive(false);
        fingerObject.SetActive(true);
        playerInfoBar.SetActive(true);
        tempfix = false;
        tempfix2 = false;
    }

    void EnemyTurn()
    {
        int randomAttack;
        randomAttack = Random.Range(1, battlePartyRef.numberOfPartyMembers + 1);
        Debug.Log("Attack party member " + randomAttack);
        NextTurn();
    }

    #endregion

}