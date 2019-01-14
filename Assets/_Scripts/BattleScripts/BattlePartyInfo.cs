using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePartyInfo : MonoBehaviour
{
    public bool tutorial;
    public _PlayerPartyStats stats;
    public int numberOfPartyMembers;

    [Header("Party Names")]
    public string[] partyNames = new string[3];
    public GameObject[] playerUis = new GameObject[3];
    public Text[] partyNamesText = new Text[3];

    [Header("Party Stats")]
    public int[] health = new int[3];
    public int[] stamina = new int[3];
    public int[] magicka = new int[3];
    private int[] maxHealth = new int[3];
    private int[] maxStamina = new int[3];
    private int[] maxMagicka = new int[3];
    public Text[] partyHealth = new Text[3];
    public Text[] partyMaxHealth = new Text[3];
    public Text[] partyStamina = new Text[3];
    public Text[] partyMaxStamina = new Text[3];
    public Text[] partyMagicka = new Text[3];
    public Text[] partyMaxMagicka = new Text[3];

    void Start()
    {
        switch (numberOfPartyMembers)
        {
            case 1:
                playerUis[0].SetActive(true);
                playerUis[1].SetActive(false);
                playerUis[2].SetActive(false);
                break;
            case 2:
                playerUis[0].SetActive(true);
                playerUis[1].SetActive(true);
                playerUis[2].SetActive(false);
                break;
            case 3:
                playerUis[0].SetActive(true);
                playerUis[1].SetActive(true);
                playerUis[2].SetActive(true);
                break;
        }
        for (int i = 0; i < numberOfPartyMembers; i++)
        {
            if (!tutorial)
            {
                //_PlayerPartyStats get info of the 3 players selected
            }

            //NAMES
            partyNamesText[i].text = partyNames[i];

            //MAX HP ST MAG
            maxHealth[i] = health[i];
            partyMaxHealth[i].text = maxHealth[i].ToString();
            maxStamina[i] = stamina[i];
            partyMaxStamina[i].text = maxStamina[i].ToString();
            maxMagicka[i] = magicka[i];
            partyMaxMagicka[i].text = maxMagicka[i].ToString();
        }
    }
    
    void Update()
    {
        UiSettings();
    }

    void UiSettings()
    {
        for (int i = 0; i < partyHealth.Length; i++)
        {
            partyHealth[i].text = health[i].ToString();
        }
        for (int i = 0; i < partyStamina.Length; i++)
        {
            partyStamina[i].text = stamina[i].ToString();
        }
        for (int i = 0; i < partyMagicka.Length; i++)
        {
            partyMagicka[i].text = magicka[i].ToString();
        }
    }

}
