using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public Text party, inventory, skills, save, exit;
    private int active;

    private void Update()
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
        TextHighlight();

    }

    private void TextHighlight() {

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
                break;
            case 1:
                party.color = Color.white;
                inventory.color = Color.yellow;
                skills.color = Color.white;

                party.fontStyle = FontStyle.Normal;
                inventory.fontStyle = FontStyle.Bold;
                skills.fontStyle = FontStyle.Normal;
                break;
            case 2:
                inventory.color = Color.white;
                skills.color = Color.yellow;
                save.color = Color.white;

                inventory.fontStyle = FontStyle.Normal;
                skills.fontStyle = FontStyle.Bold;
                save.fontStyle = FontStyle.Normal;
                break;
            case 3:
                skills.color = Color.white;
                save.color = Color.yellow;
                exit.color = Color.white;

                skills.fontStyle = FontStyle.Normal;
                save.fontStyle = FontStyle.Bold;
                exit.fontStyle = FontStyle.Normal;
                break;
            case 4:
                save.color = Color.white;
                exit.color = Color.yellow;

                save.fontStyle = FontStyle.Normal;
                exit.fontStyle = FontStyle.Bold;
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

}