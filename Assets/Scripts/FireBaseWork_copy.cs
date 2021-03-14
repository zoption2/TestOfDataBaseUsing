//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase;
//using Firebase.Auth;
//using UnityEngine.UI;

//public class FireBaseWork : IDatabase
//{
//    public FireBaseWork()
//    {
//        CheckAndInitDatabase();
//    }

//    private DependencyStatus dependencyStatus;
//    private FirebaseAuth authentication;
//    private FirebaseUser user;




//    public void RegistrNewAccount(string login, string email, string password)
//    {
//        string errorMessage = "";
//        var registrTask = authentication.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled)
//            {
//                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
//                Message.MessageToUser("Connection canceled", MessageKind.Warning);
//                return;
//            }

//            if (task.IsFaulted)
//            {
//                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
//                //Message.Instance.MessageToUser("Connection failed", MessageKind.Warning);
//                FirebaseException fbExeption = task.Exception.GetBaseException() as FirebaseException;
//                AuthError errorCode = (AuthError)fbExeption.ErrorCode;

//                switch (errorCode)
//                {
//                    case AuthError.MissingEmail:
//                        Message.MessageToUser("Missing Email!", MessageKind.Warning);
//                        errorMessage = "Missing Email!";
//                        break;
//                    case AuthError.MissingPassword:
//                        // Message.Instance.MessageToUser("Missing password!", MessageKind.Warning);
//                        errorMessage = "Missing password!";
//                        break;
//                    case AuthError.WeakPassword:
//                        //Message.Instance.MessageToUser("Password is too weak!", MessageKind.Warning);
//                        errorMessage = "Password is too weak!";
//                        break;
//                    case AuthError.EmailAlreadyInUse:
//                        // Message.Instance.MessageToUser("Email already in use!", MessageKind.Warning);
//                        errorMessage = "Email already in use!";
//                        try
//                        {
//                            Message.MessageToUser("Email already in use!", MessageKind.Warning);
//                        }
//                        catch (System.Exception ex)
//                        {
//                            Debug.LogError(ex.ToString());
//                            //throw;
//                        }
//                        break;
//                    default:
//                        //Message.Instance.MessageToUser("Registration failed!", MessageKind.Warning);
//                        errorMessage = "Registration failed!";
//                        break;
//                }
//                return;
//            }

//            user = task.Result;

//            if (user != null)
//            {
//                UserProfile profile = new UserProfile { DisplayName = login };
//                var profileTask = user.UpdateUserProfileAsync(profile).ContinueWith(proTask =>
//                {
//                    if (proTask.IsCanceled)
//                    {
//                        Debug.LogError("UpdateUserProfileAsync was canceled.");
//                        Message.MessageToUser("User update canceled", MessageKind.Warning);

//                        return;
//                    }
//                    if (proTask.IsFaulted)
//                    {
//                        Debug.LogError("UpdateUserProfileAsync encountered an error: " + proTask.Exception);
//                        Message.MessageToUser("Authentication failed", MessageKind.Warning);
//                        return;
//                    }

//                    Debug.LogFormat("Firebase user created successfully: {0} ({1})", user.DisplayName, user.UserId);
//                    SwitchToLoginMenu();

//                });
//            }

//        });
//        Message.MessageToUser(errorMessage, MessageKind.Warning);
//    }

//    public void CheckAndInitDatabase()
//    {
//        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
//        {
//            dependencyStatus = task.Result;
//            if (dependencyStatus == DependencyStatus.Available)
//            {
//                InitializeFirebase();

//                // Set a flag here to indicate whether Firebase is ready to use by your app.
//                SetUpDatabaseAsMain();
//            }
//            else
//            {
//                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
//            }
//        });
//    }

//    private void InitializeFirebase()
//    {
//        authentication = FirebaseAuth.DefaultInstance;
//        Debug.Log("Setting up firebase authentication");
//    }
//    private void SetUpDatabaseAsMain()
//    {
//        DatabaseController.Instance.SetUpDatabase(this);
//    }

//    private void SwitchToLoginMenu()
//    {
//        DatabaseController.Instance.BackToLoginMenu();
//        Message.MessageToUser("Registration successful", MessageKind.Confirm);
//    }

//    public void LogInAccount(string email, string password)
//    {
//        throw new System.NotImplementedException();
//    }
//}
