using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class MainMenuUI : MonoBehaviour, IMenuUI
{
    [Header("Login Panel")] 
    [SerializeField] private Transform loginPanel;
    [SerializeField] public InputField emailField;
    [SerializeField] public InputField passwordField;

    [Space]
    [Header("Registr Panel")]
    [SerializeField] private Transform registrPanel;
    [SerializeField] public InputField usernameRegistrField;
    [SerializeField] public InputField emailRegistrField;
    [SerializeField] public InputField passwordRegistrField;
    [SerializeField] public InputField repeatPassRegistrField;

    [Space]
    [Header("Password visibility")]
    [SerializeField] public List<Button> passwordVisionButtons;
    [SerializeField] public List<InputField> Passwords;

    [Space]
    [Header("Bottom Panel")]
    [SerializeField] private Transform bottomPanel;


    private ICorrectRegistr correctRegistr;
    private ICorrectLogin correctLogin;
    private enum MainMenuState {Login, Registr}

    private Transform showPassImage;
    private Transform hidePassImage;
    private static bool isPasswordShown = false;



    #region Start
    private void Start()
    {
        correctRegistr = new RegistrCorrector(this);
        correctLogin = new LoginCorrector(this);
        SwitchPanel(MainMenuState.Login);
        DatabaseController.menuUI = this;
       // ChangePasswordVision();
    }
    #endregion

    public void ChangePasswordVision()
    {
        isPasswordShown = !isPasswordShown;
        SetVisionOfPassword(isPasswordShown);
    }

    public void BackToLoginMenu()
    {
        SwitchPanel(MainMenuState.Login);
    }

    public void SwitchToSignUpMenu()
    {
        SwitchPanel(MainMenuState.Registr);
    }
    
    public void CheckLoginEmail()
    {
        correctLogin.CheckLoginEmail();
    }

    public void CheckLoginPassword()
    {
        correctLogin.CheckLoginPassword();
    }

    public void IsAllLoginFieldsReady()
    {
        correctLogin.IsAllLoginFieldsReady();
    }

    public void CheckLoginRegistr()
    {
        correctRegistr.CheckUsernameRegistr();
    }

    public void CheckEmailRegistr()
    {
        correctRegistr.CheckEmailRegistr();
    }

    public void CheckPasswordRegistr()
    {
        correctRegistr.CheckPasswordRegistr();
    }

    public void CheckRepeatPasswordRegistr()
    {
        correctRegistr.CheckRepeatPasswordRegistr();
    }

    public void IsAllRegistrFieldsReady()
    {
        correctRegistr.IsAllRegistrFieldsReady();
    }

    public void SignUpNewUser()
    {
        if (correctRegistr == null)
        {
            Debug.LogWarning("There is no Registr corrector for inputing field! Setup corrector to prevent input data misstakes.");
        }
        else if (!correctRegistr.IsAllRegistrFieldsReady())
        {
            Message.MessageToUser("Incorrect input data", MessageKind.Warning);
        }
        else
        {
            string name = usernameRegistrField.text;
            string email = emailRegistrField.text;
            string pass = passwordRegistrField.text;
            DatabaseController.dataBase.RegistrNewAccount(name, email, pass);
        }
    }

    public void LogInAccount()
    {
        if (correctLogin == null)
        {
            Debug.LogWarning("There is no Login corrector for inputing field! Setup corrector to prevent input data misstakes.");
        }
        else if (!correctLogin.IsAllLoginFieldsReady())
        {
            Message.MessageToUser("Incorrect input data", MessageKind.Warning);
        }
        else
        {
            string email = emailField.text;
            string password = passwordField.text;
            DatabaseController.dataBase.LogInAccount(email, password);
        }
    }

    private void SwitchPanel(MainMenuState panel)
    {
        switch (panel)
        {
            case MainMenuState.Login:
                loginPanel.gameObject.SetActive(true);
                registrPanel.gameObject.SetActive(false);
                bottomPanel.gameObject.SetActive(true);

                FieldsNullifier();
                Message.MessageToUser("Welcome!", MessageKind.Confirm);
                break;

            case MainMenuState.Registr:
                loginPanel.gameObject.SetActive(false);
                registrPanel.gameObject.SetActive(true);
                bottomPanel.gameObject.SetActive(false);

                FieldsNullifier();
                Message.MessageToUser("Enter fields", MessageKind.Confirm);
                break;
            default:
                break;
        }
    }
    
    private void FieldsNullifier()
    {
        emailField.text = "";
        passwordField.text = "";
        usernameRegistrField.text = "";
        emailRegistrField.text = "";
        passwordRegistrField.text = "";
        repeatPassRegistrField.text = "";
    }

    private void SetVisionOfPassword(bool isVisible)
    {
        switch (isVisible)
        {
            case false:

                for (int i = 0; i < passwordVisionButtons.Count; i++)
                {
                    passwordVisionButtons[i].transform.Find("Hide").gameObject.SetActive(true);
                    passwordVisionButtons[i].transform.Find("Show").gameObject.SetActive(false);
                }

                for (int i = 0; i < Passwords.Count; i++)
                {
                    Passwords[i].contentType = InputField.ContentType.Password;
                    Passwords[i].ActivateInputField();
                }
                break;
            case true:

                for (int i = 0; i < passwordVisionButtons.Count; i++)
                {
                    passwordVisionButtons[i].transform.Find("Hide").gameObject.SetActive(false);
                    passwordVisionButtons[i].transform.Find("Show").gameObject.SetActive(true);
                }

                for (int i = 0; i < Passwords.Count; i++)
                {
                    Passwords[i].contentType = InputField.ContentType.Standard;
                    Passwords[i].ActivateInputField();
                }
                break;
            default:
                break;
        }
    }

}
