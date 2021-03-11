using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUser
{
    private string login;
    private string email;
    private string password;

    public NewUser(string _login, string _email, string _password)
    {
        this.login = _login;
        this.email = _email;
        this.password = _password;
    }

    public string Login
    {
        get
        { 
            return login;
        }
        private set { }
    }

    public string Email
    {
        get
        {
            return email;
        }
        private set { }
    }

    public string Password
    {
        get
        {
            return password;
        }
        private set { }
    }
}
