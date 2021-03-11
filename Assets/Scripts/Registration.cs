using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : IRegistration
{
    public Registration(IMenuUI menuUI)
    {
        this.menuUI = menuUI;
    }
    private IMenuUI menuUI;

    public void SetNewName()
    {

    }
    //private string TryNewUsername()
    //{
    //    string name = menuUI.;
    //    if (name.Length < 4)
    //    {
    //        Color32 textColor = new Color32(255, 0, 0, 1);
    //        loginRegistrField.caretColor = textColor;
    //        loginRegistrField.text = "UserName is too short!";
    //        textColor = new Color32(0, 0, 0, 1);
    //        loginRegistrField.caretColor = textColor;
    //        return "Unknown user";
    //    }
    //    else
    //    {
    //        return name;
    //    }
    //}
}
