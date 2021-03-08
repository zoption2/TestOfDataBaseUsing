using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour, IDatabase, IMenuUI
{
    public static DatabaseController Instance;
    private static IDatabase dataBase;

    public void SetUpDatabase(IDatabase database)
    {
        if (dataBase == null)
        {
            dataBase = database;
        }
        else
        {
            throw new System.Exception("Main Database is already exist!");
        }

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
