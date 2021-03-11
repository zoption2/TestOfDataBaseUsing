using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour, IMenuUI
{
    [Header("Login Panel")] 
    [SerializeField] private Transform loginPanel;
    [SerializeField] public InputField loginField;
    [SerializeField] public InputField passwordField;

    [Space]
    [Header("Registr Panel")]
    [SerializeField] private Transform registrPanel;
    [SerializeField] public InputField loginRegistrField;
    [SerializeField] public InputField emailRegistrField;
    [SerializeField] public InputField passwordRegistrField;
    [SerializeField] public InputField repeatPassRegistrField;

    [Space]
    [Header("Bottom Panel")]
    [SerializeField] private Transform bottomPanel;

    [Space]
    [SerializeField] private Text confirmText;
    [SerializeField] private Text warningText;

    private enum MainMenuState {Login, Registr}

    #region Awake
    private void Awake()
    {
        SwitchPanel(MainMenuState.Login);
    }
    #endregion


    public void SwitchToSignUpMenu()
    {
        SwitchPanel(MainMenuState.Registr);
    }

    public void BackToLoginMenu()
    {
        SwitchPanel(MainMenuState.Login);
    }

    public void SignUp()
    {
        signUp(loginRegistrField.text, emailRegistrField.text, passwordRegistrField.text);
    }

    private void signUp(string login, string email, string password)
    {
        if (login == "")
        {
            warningText.text = "Missing username";
        }
        else if (password != repeatPassRegistrField.text)
        {
            warningText.text = "Password Does Not Match";
        }
        else
        {
           // var registr = DatabaseController.dataBase.g
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
                break;
            case MainMenuState.Registr:
                loginPanel.gameObject.SetActive(false);
                registrPanel.gameObject.SetActive(true);
                bottomPanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }



}
