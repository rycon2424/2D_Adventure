using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerPartyStats : MonoBehaviour
{

    #region Singleton

    private static _PlayerPartyStats instance = null;

    public static _PlayerPartyStats Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    [Header("Player Stats")]
    public int playerxp;
    public int playerlevel;
    public int playerhealth;
    public int playerstamina;
    public int playermagica;
    public int partyCount;

    #region Party member statistics
    [Header("member1 Stats")]
    public string member1Name;
    public int member1Level;
    public float member1XP;
    public int member1Health;
    public int member1Stamina;
    public int member1Magica;
    [Header("member2 Stats")]
    public string member2Name;
    public int member2Level;
    public float member2XP;
    public int member2Health;
    public int member2Stamina;
    public int member2Magica;
    [Header("member3 Stats")]
    public string member3Name;
    public int member3Level;
    public float member3XP;
    public int member3Health;
    public int member3Stamina;
    public int member3Magica;
    [Header("member4 Stats")]
    public string member4Name;
    public int member4Level;
    public float member4XP;
    public int member4Health;
    public int member4Stamina;
    public int member4Magica;
    [Header("member5 Stats")]
    public string member5Name;
    public int member5Level;
    public float member5XP;
    public int member5Health;
    public int member5Stamina;
    public int member5Magica;
    [Header("member6 Stats")]
    public string member6Name;
    public int member6Level;
    public float member6XP;
    public int member6Health;
    public int member6Stamina;
    public int member6Magica;
    [Header("member7 Stats")]
    public string member7Name;
    public int member7Level;
    public float member7XP;
    public int member7Health;
    public int member7Stamina;
    public int member7Magica;
    [Header("member8 Stats")]
    public string member8Name;
    public int member8Level;
    public float member8XP;
    public int member8Health;
    public int member8Stamina;
    public int member8Magica;
    [Header("member9 Stats")]
    public string member9Name;
    public int member9Level;
    public float member9XP;
    public int member9Health;
    public int member9Stamina;
    public int member9Magica;
    [Header("member10 Stats")]
    public string member10Name;
    public int member10Level;
    public float member10XP;
    public int member10Health;
    public int member10Stamina;
    public int member10Magica;
    [Header("member11 Stats")]
    public string member11Name;
    public int member11Level;
    public float member11XP;
    public int member11Health;
    public int member11Stamina;
    public int member11Magica;
    #endregion

    public void IncreaseParty(string name, int level, int health, int stamina, int magica) {

        if (partyCount == 0)
        {
            member1Name = name;
            member1Level = level;
            member1Health = health;
            member1Stamina = stamina;
            member1Magica = magica;
        }
        else if (partyCount == 1)
        {
            member2Name = name;
            member2Level = level;
            member2Health = health;
            member2Stamina = stamina;
            member2Magica = magica;
        }
        else if (partyCount == 2)
        {
            member3Name = name;
            member3Level = level;
            member3Health = health;
            member3Stamina = stamina;
            member3Magica = magica;
        }
        else if (partyCount == 3)
        {
            member4Name = name;
            member4Level = level;
            member4Health = health;
            member4Stamina = stamina;
            member4Magica = magica;
        }
        else if (partyCount == 4)
        {
            member5Name = name;
            member5Level = level;
            member5Health = health;
            member5Stamina = stamina;
            member5Magica = magica;
        }
        else if (partyCount == 5)
        {
            member6Name = name;
            member6Level = level;
            member6Health = health;
            member6Stamina = stamina;
            member6Magica = magica;
        }
        else if (partyCount == 6)
        {
            member7Name = name;
            member7Level = level;
            member7Health = health;
            member7Stamina = stamina;
            member7Magica = magica;
        }
        else if (partyCount == 7)
        {
            member8Name = name;
            member8Level = level;
            member8Health = health;
            member8Stamina = stamina;
            member8Magica = magica;
        }
        else if (partyCount == 8)
        {
            member9Name = name;
            member9Level = level;
            member9Health = health;
            member9Stamina = stamina;
            member9Magica = magica;
        }
        else if (partyCount == 9)
        {
            member10Name = name;
            member10Level = level;
            member10Health = health;
            member10Stamina = stamina;
            member10Magica = magica;
        }
        else if (partyCount == 10)
        {
            member11Name = name;
            member11Level = level;
            member11Health = health;
            member11Stamina = stamina;
            member11Magica = magica;
        }
        else if (partyCount == 11)
        {
            member11Name = name;
            member11Level = level;
            member11Health = health;
            member11Stamina = stamina;
            member11Magica = magica;
        }
        partyCount++;
    }

}