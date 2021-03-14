using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrCorrector : ICorrectRegistr
{
    public RegistrCorrector(MainMenuUI mainMenuUI)
    {
        this.menu = mainMenuUI;
    }

    private MainMenuUI menu;
    private List<bool> registrFildsStatus;


    public bool IsAllRegistrFieldsReady()
    {
        PrepareRegistrStatuses();
        for (int i = 0; i < registrFildsStatus.Count; i++)
        {
            if (registrFildsStatus[i] == false)
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckUsernameRegistr()
    {
        if (menu.usernameRegistrField.text.Length < 2)
        {
            Message.MessageToUser("Username is too short!", MessageKind.Warning);
            menu.usernameRegistrField.text = "";
            return false;
        }
        else
        {
            Message.MessageToUser("Login is availible", MessageKind.Confirm);
            return true;
        } 
    }

    public bool CheckEmailRegistr()
    {
        if (!menu.emailRegistrField.text.Contains("@") || !menu.emailRegistrField.text.Contains("."))
        {
            Message.MessageToUser("Incorrect Email format!", MessageKind.Warning);
            return false;
        }
        else
        {
            Message.MessageToUser("Email format is right", MessageKind.Confirm);
            return true;
        } 
    }

    public bool CheckPasswordRegistr()
    {
        if (menu.passwordRegistrField.text.Length < 6)
        {
            Message.MessageToUser("Password is too short!\nIt should be at least 6 symbols long.", MessageKind.Warning);
            menu.passwordRegistrField.text = "";
            return false;
        }
        else
        {
            Message.MessageToUser("Password availible", MessageKind.Confirm);
            return true;
        }
    }

    public bool CheckRepeatPasswordRegistr()
    {
        if (menu.passwordRegistrField.text != menu.repeatPassRegistrField.text)
        {
            Message.MessageToUser("Incorrect password repeat!", MessageKind.Warning);
            menu.passwordRegistrField.text = "";
            menu.repeatPassRegistrField.text = "";
            return false;
        }
        else
        {
            Message.MessageToUser("Password confirmed", MessageKind.Confirm);
            return true;
        } 
    }



    private void PrepareRegistrStatuses()
    {
        registrFildsStatus = new List<bool>();
        registrFildsStatus.Add(CheckUsernameRegistr());
        registrFildsStatus.Add(CheckEmailRegistr());
        registrFildsStatus.Add(CheckPasswordRegistr());
        registrFildsStatus.Add(CheckRepeatPasswordRegistr());
    }
}
