using UnityEngine;
using UnityEngine.UI;

public class Message: MonoBehaviour
{
    public static Message Instance;

    [Header("Message Panel")]
    [SerializeField] private Text confirmText;
    [SerializeField] private Text warningText;


    #region Awake
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this);
    }
    #endregion


    public static void MessageToUser(string message, MessageKind kind)
    {
        switch (kind)
        {
            case MessageKind.Warning:

                Instance.confirmText.text = "";
                Instance.warningText.text = message;
                break;
            case MessageKind.Confirm:
                Instance.warningText.text = "";
                Instance.confirmText.text = message;
                break;
            default:
                break;
        }
    }


}
