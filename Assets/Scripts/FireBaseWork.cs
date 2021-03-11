using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class FireBaseWork : IDatabase
{
    public FireBaseWork()
    {
        CheckInFirebase();
    }

    private DependencyStatus dependencyStatus;
    private FirebaseAuth authentication;
    private FirebaseUser user;

    public FirebaseAuth GetAuthentication
    {
        get 
        {
            return authentication;
        }
      
    }

    private void CheckInFirebase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
               SetUpThisBaseAsMain();
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
        DatabaseController.Instance.SetUpDatabase(this);
    }
}
