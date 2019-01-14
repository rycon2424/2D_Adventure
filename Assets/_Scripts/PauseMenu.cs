using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public Text party, inventory, skills, save, exit;
    public GameObject partyMenu, inventoryMenu, skillsMenu, saveMenu;
    private enum Menus {none,party,inventory,skills,save};
    private Menus currentMenu;
    private int active;
    private bool menuActive = true;

    private void Update()
    {
        if (menuActive)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (active <= 4)
                {
                    active++;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (active >= -1)
                {
                    active--;
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                this.gameObject.SetActive(false);
            }
        }
        MenuSelector();

        switch (currentMenu)
        {
            case Menus.party:
                Party();
            break;
            case Menus.inventory:
                Inventory();
            break;
            case Menus.skills:
                Skills();
            break;
            case Menus.save:
                Save();
            break;
            default:
                currentMenu = Menus.none;
            break;
        }

    }

    private void MenuSelector()
    {
        switch (active)
            {
                case -1:
                    party.color = Color.white;
                    party.fontStyle = FontStyle.Normal;
                    active = 4;
                break;
                case 0:
                    party.color = Color.yellow;
                    inventory.color = Color.white;

                    party.fontStyle = FontStyle.Bold;
                    inventory.fontStyle = FontStyle.Normal;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        partyMenu.SetActive(true);
                        menuActive = false;
                        currentMenu = Menus.party;
                    }
                break;
                case 1:
                    party.color = Color.white;
                    inventory.color = Color.yellow;
                    skills.color = Color.white;

                    party.fontStyle = FontStyle.Normal;
                    inventory.fontStyle = FontStyle.Bold;
                    skills.fontStyle = FontStyle.Normal;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        inventoryMenu.SetActive(true);
                        menuActive = false;
                        currentMenu = Menus.inventory;
                    }
                break;
                case 2:
                    inventory.color = Color.white;
                    skills.color = Color.yellow;
                    save.color = Color.white;

                    inventory.fontStyle = FontStyle.Normal;
                    skills.fontStyle = FontStyle.Bold;
                    save.fontStyle = FontStyle.Normal;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        skillsMenu.SetActive(true);
                        menuActive = false;
                    currentMenu = Menus.skills;
                    }
                break;
                case 3:
                    skills.color = Color.white;
                    save.color = Color.yellow;
                    exit.color = Color.white;

                    skills.fontStyle = FontStyle.Normal;
                    save.fontStyle = FontStyle.Bold;
                    exit.fontStyle = FontStyle.Normal;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        saveMenu.SetActive(true);
                        menuActive = false;
                        currentMenu = Menus.save;
                    }
                break;
                case 4:
                    save.color = Color.white;
                    exit.color = Color.yellow;

                    save.fontStyle = FontStyle.Normal;
                    exit.fontStyle = FontStyle.Bold;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Exit();
                    }
                break;
                case 5:
                    exit.color = Color.white;

                    exit.fontStyle = FontStyle.Normal;
                    active = 0;
                break;
                default:
                    active = 0;
                break;
            }
    }

    private void Party()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            partyMenu.SetActive(false);
            currentMenu = Menus.none;
            menuActive = true;
        }
    }
    private void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryMenu.SetActive(false);
            currentMenu = Menus.none;
            menuActive = true;
        }
    }
    private void Skills()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            skillsMenu.SetActive(false);
            currentMenu = Menus.none;
            menuActive = true;
        }
    }
    private void Save()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            saveMenu.SetActive(false);
            currentMenu = Menus.none;
            menuActive = true;
        }
    }
    private void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}