using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;

public class FireBaseWork : MonoBehaviour, IDatabase
{
    private void Start()
    {
        CheckAndInitDatabase();
    }

    private DependencyStatus dependencyStatus;
    private FirebaseAuth authentication;
    private FirebaseUser user;

    public string GetInformationAboutUser()
    {
        var info = user.DisplayName;
        return info;
    }

    public void LogInAccount(string email, string password)
    {
        StartCoroutine(_logInAccount(email, password));
    }

    public void RegistrNewAccount(string login, string email, string password)
    {
        StartCoroutine(_registrNewAccount(login, email, password));
    }

    private IEnumerator _registrNewAccount(string login, string email, string password)
    {
        var registrTask = authentication.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registrTask.IsCompleted);
        if (registrTask.Exception != null)
        {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + registrTask.Exception);
            //Message.Instance.MessageToUser("Connection failed", MessageKind.Warning);
            FirebaseException fbExeption = registrTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)fbExeption.ErrorCode;
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    Message.MessageToUser("Missing Email!", MessageKind.Warning);
                    break;
                case AuthError.MissingPassword:
                    Message.MessageToUser("Missing password!", MessageKind.Warning);
                    break;
                case AuthError.WeakPassword:
                    Message.MessageToUser("Password is too weak!", MessageKind.Warning);
                    break;
                case AuthError.EmailAlreadyInUse:
                    Message.MessageToUser("Email already in use!", MessageKind.Warning);
                    break;
                default:
                    Message.MessageToUser("Registration failed!", MessageKind.Warning);
                    break;
            }
        }
        else
        {
            user = registrTask.Result;
            if (user != null)
            {
                UserProfile profile = new UserProfile { DisplayName = login };
                var profileTask = user.UpdateUserProfileAsync(profile);
                yield return new WaitUntil(() => profileTask.IsCompleted);
                if (profileTask.Exception != null)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + profileTask.Exception);
                    Message.MessageToUser("Authentication failed", MessageKind.Warning);
                }
                else
                {
                    Debug.LogFormat("Firebase user created successfully: {0} ({1})", user.DisplayName, user.UserId);
                    Message.MessageToUser("Registration successful!", MessageKind.Confirm);
                    SwitchToLoginMenu();

                }
            }
        }
    }

    private IEnumerator _logInAccount(string email, string password)
    {
        var LoginTask = authentication.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogError("Fail to login with " + LoginTask.Exception);
            FirebaseException firebaseException = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError error = (AuthError)firebaseException.ErrorCode;

            switch (error)
            {
                case AuthError.MissingEmail:
                    Message.MessageToUser("Missing Email!", MessageKind.Warning);
                    break;
                case AuthError.MissingPassword:
                    Message.MessageToUser("Missing password!", MessageKind.Warning);
                    break;
                case AuthError.WrongPassword:
                    Message.MessageToUser("Wrong password!", MessageKind.Warning);
                    break;
                case AuthError.InvalidEmail:
                    Message.MessageToUser("Invalid Email!", MessageKind.Warning);
                    break;
                case AuthError.UserNotFound:
                    Message.MessageToUser("User not found!", MessageKind.Warning);
                    break;
                default:
                    break;
            }
        }
        else
        {
            user = LoginTask.Result;
            Debug.LogFormat("User logged in successfully: {0}, ({1})", user.DisplayName, user.Email);
            Message.MessageToUser($"Log In Successful!\nWelcome, {user.DisplayName}", MessageKind.Confirm);

            yield return new WaitForSeconds(1);

            SceneControl.GoToDataScene();
        }

    }

    public void CheckAndInitDatabase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                SetUpDatabaseAsMain();
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

    private void SetUpDatabaseAsMain()
    {
        DatabaseController.Instance.SetUpDatabase(this);
    }

    private void SwitchToLoginMenu()
    {
        DatabaseController.Instance.BackToLoginMenu();
        Message.MessageToUser("Registration successful", MessageKind.Confirm);
    }
}
