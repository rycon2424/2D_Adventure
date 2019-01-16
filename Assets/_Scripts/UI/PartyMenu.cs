using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour
{
    [Header("Party Menu")]
    public GameObject main1;
    public GameObject main2;
    public GameObject main3;
    public GameObject opt1, opt2, opt3, opt4, opt5, opt6, opt7, opt8, opt9;

    public _PlayerPartyStats GameManager;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<_PlayerPartyStats>();
    }

    private void Update()
    {
        FillChildren(GameManager.partyCount);
    }

    private void FillChildren(int totalChildren) {

        if (totalChildren >= 0)
        {
            main1.transform.GetChild(0).GetComponent<Text>().text = "Player";
            main1.transform.GetChild(1).GetComponent<Text>().text = GameManager.playerhealth.ToString();
            main1.transform.GetChild(2).GetComponent<Text>().text = GameManager.playerstamina.ToString();
            main1.transform.GetChild(3).GetComponent<Text>().text = GameManager.playermagica.ToString();
        }
        if (totalChildren >= 1)
        {
            main2.SetActive(true);
            main2.transform.GetChild(0).GetComponent<Text>().text = GameManager.member1Name;
            main2.transform.GetChild(1).GetComponent<Text>().text = GameManager.member1Health.ToString();
            main2.transform.GetChild(2).GetComponent<Text>().text = GameManager.member1Stamina.ToString();
            main2.transform.GetChild(3).GetComponent<Text>().text = GameManager.member1Magica.ToString();
        }
        if (totalChildren >= 2)
        {
            main3.SetActive(true);
            main3.transform.GetChild(0).GetComponent<Text>().text = GameManager.member2Name;
            main3.transform.GetChild(1).GetComponent<Text>().text = GameManager.member2Health.ToString();
            main3.transform.GetChild(2).GetComponent<Text>().text = GameManager.member2Stamina.ToString();
            main3.transform.GetChild(3).GetComponent<Text>().text = GameManager.member2Magica.ToString();
        }
        if (totalChildren >= 3)
        {
            opt1.SetActive(true);
            opt1.transform.GetChild(0).GetComponent<Text>().text = GameManager.member3Name;
            opt1.transform.GetChild(1).GetComponent<Text>().text = GameManager.member3Level.ToString();
        }
        if (totalChildren >= 4)
        {
            opt2.SetActive(true);
            opt2.transform.GetChild(0).GetComponent<Text>().text = GameManager.member4Name;
            opt2.transform.GetChild(1).GetComponent<Text>().text = GameManager.member4Level.ToString();
        }
        if (totalChildren >= 5)
        {
            opt3.SetActive(true);
            opt3.transform.GetChild(0).GetComponent<Text>().text = GameManager.member5Name;
            opt3.transform.GetChild(1).GetComponent<Text>().text = GameManager.member5Level.ToString();
        }
        if (totalChildren >= 6)
        {
            opt4.SetActive(true);
            opt4.transform.GetChild(0).GetComponent<Text>().text = GameManager.member6Name;
            opt4.transform.GetChild(1).GetComponent<Text>().text = GameManager.member6Level.ToString();
        }
        if (totalChildren >= 7)
        {
            opt5.SetActive(true);
            opt5.transform.GetChild(0).GetComponent<Text>().text = GameManager.member7Name;
            opt5.transform.GetChild(1).GetComponent<Text>().text = GameManager.member7Level.ToString();
        }
        if (totalChildren >= 8)
        {
            opt6.SetActive(true);
            opt6.transform.GetChild(0).GetComponent<Text>().text = GameManager.member8Name;
            opt6.transform.GetChild(1).GetComponent<Text>().text = GameManager.member8Level.ToString();
        }
        if (totalChildren >= 9)
        {
            opt7.SetActive(true);
            opt7.transform.GetChild(0).GetComponent<Text>().text = GameManager.member9Name;
            opt7.transform.GetChild(1).GetComponent<Text>().text = GameManager.member9Level.ToString();
        }
        if (totalChildren >= 10)
        {
            opt8.SetActive(true);
            opt8.transform.GetChild(0).GetComponent<Text>().text = GameManager.member10Name;
            opt8.transform.GetChild(1).GetComponent<Text>().text = GameManager.member10Level.ToString();
        }
        if (totalChildren >= 11)
        {
            opt9.SetActive(true);
            opt9.transform.GetChild(0).GetComponent<Text>().text = GameManager.member11Name;
            opt9.transform.GetChild(1).GetComponent<Text>().text = GameManager.member11Level.ToString();
        }

    }

}