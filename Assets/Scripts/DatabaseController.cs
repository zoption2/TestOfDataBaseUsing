using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour, IMenuUI
{
    public static DatabaseController Instance;
    public static IDatabase dataBase;
    public static IMenuUI menuUI;


    public void BackToLoginMenu()
    {
        menuUI.BackToLoginMenu();
    }

    public void ConnectToFirebase()
    {
        IDatabase baseToConnect = gameObject.AddComponent<FireBaseWork>();
    }

    public void SetUpDatabase(IDatabase database)
    {
        if (dataBase == null && database != null)
        {
            dataBase = database;
            Debug.LogFormat($"Database {dataBase.GetType().Name.ToString()} is ready to use ass singlebase!");
        }
        else
        {
            Debug.LogWarningFormat("New database {0} is trying to set as main.", database.ToString());
            throw new System.Exception("Main Database is already exist!");
        }

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ConnectToFirebase();
    }

}
