using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static void GoToLoginMenu()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public static void GoToDataScene()
    {
        SceneManager.LoadScene("DataScene");
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
