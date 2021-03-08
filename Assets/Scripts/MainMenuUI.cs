using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour, IMenuUI
{
    [Header("Login Panel")] 
    [SerializeField] private Transform loginPanel;
    [SerializeField] private InputField loginField;
    [SerializeField] private InputField passwordField;

    [Space]
    [Header("Registr Panel")]
    [SerializeField] private Transform registrPanel;
    [SerializeField] private InputField loginRegistrField;
    [SerializeField] private InputField emailRegistrField;
    [SerializeField] private InputField passwordRegistrField;
    [SerializeField] private InputField repeatPassRegistrField;

    [Space]
    [Header("Bottom Panel")]
    [SerializeField] private Transform bottomPanel;

    private enum MainMenuPanel {Login, Registr}

    private void Awake()
    {
        SwitchPanel(MainMenuPanel.Login);
    }
    public void SwitchToSignUpMenu()
    {
        SwitchPanel(MainMenuPanel.Registr);
    }

    public void BackToLoginMenu()
    {
        SwitchPanel(MainMenuPanel.Login);
    }
    private void SwitchPanel(MainMenuPanel panel)
    {
        switch (panel)
        {
            case MainMenuPanel.Login:
                loginPanel.gameObject.SetActive(true);
                registrPanel.gameObject.SetActive(false);
                bottomPanel.gameObject.SetActive(true);
                break;
            case MainMenuPanel.Registr:
                loginPanel.gameObject.SetActive(false);
                registrPanel.gameObject.SetActive(true);
                bottomPanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }


}
