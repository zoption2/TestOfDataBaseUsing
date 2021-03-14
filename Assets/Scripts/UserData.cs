using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    [SerializeField] private Text userInformation;


    public void DisplayUserInformation()
    {
        userInformation.text = $"Display information\nabout {GetUserInformation()}";
    }

    private string GetUserInformation()
    {
        return DatabaseController.dataBase.GetInformationAboutUser();
    }
}
