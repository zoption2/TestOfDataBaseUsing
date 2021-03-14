using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginCorrector : ICorrectLogin
{
    public LoginCorrector(MainMenuUI mainMenuUI)
    {
        this.menu = mainMenuUI;
    }

    private MainMenuUI menu;
    private List<bool> registrFildsStatus;

    public bool CheckLoginEmail()
    {
        if (!menu.emailField.text.Contains("@") || !menu.emailField.text.Contains("."))
        {
            Message.MessageToUser("Incorrect Email format!", MessageKind.Warning);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool CheckLoginPassword()
    {
        if (menu.passwordField.text.Length < 6)
        {
            Message.MessageToUser("Password is too short!", MessageKind.Warning);
            menu.passwordField.text = "";
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsAllLoginFieldsReady()
    {
        PrepareLoginStatuses();
        for (int i = 0; i < registrFildsStatus.Count; i++)
        {
            if (registrFildsStatus[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    private void PrepareLoginStatuses()
    {
        registrFildsStatus = new List<bool>();
        registrFildsStatus.Add(CheckLoginEmail());
        registrFildsStatus.Add(CheckLoginPassword());
    }
}
