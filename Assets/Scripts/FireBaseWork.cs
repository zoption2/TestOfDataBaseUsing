using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class FireBaseWork : MonoBehaviour, IDatabase
{
    private DependencyStatus dependencyStatus;
    private DatabaseController databaseController;
    private FirebaseAuth authentication;
    private FirebaseUser user;

    private void Awake()
    {
        databaseController = DatabaseController.Instance;
    }
    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    private void InitializeFirebase()
    {
        authentication = FirebaseAuth.DefaultInstance;
        Debug.Log("Setting up firebase authentication");
    }

    private void SetUpThisBaseAsMain()
    {
        databaseController.SetUpDatabase(this);
    }
}
