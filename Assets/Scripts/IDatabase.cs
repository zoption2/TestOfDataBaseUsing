using UnityEngine;

public interface IDatabase
{
    void CheckAndInitDatabase();
    void RegistrNewAccount(string login, string email, string password);
    void LogInAccount(string email, string password);
    string GetInformationAboutUser();
}
