using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour, IMenuUI
{
    public static DatabaseController Instance;
    public static IDatabase dataBase;

    private static bool isDatabaseReady = false;

    public bool IsDatabaseReady
    {
        get 
        { 
            return isDatabaseReady;
        }
        private set { }
    }




    public void ConnectToFirebase()
    {
        IDatabase baseToConnect = new FireBaseWork();
    }

    public void SetUpDatabase(IDatabase database)
    {
        if (dataBase == null && database != null)
        {
            dataBase = database;
            IsDatabaseReady = true;
            Debug.LogFormat("Database {0} is ready to use ass singlebase!", dataBase.ToString());
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
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ConnectToFirebase();
    }

}
