using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginInfo 
{
    //string phone;
    //string password;
    //string identity;
    public LoginInfo()
    {

    }

    public LoginInfo(string phone, string password)
    {
        this.Phone = phone;
        this.Password = password;
      //  this.Identity = identity;
    }
    public string IsIdentityLog;
    public string Phone;//{ get => phone; set => phone = value; }
    public string Password;// { get => password; set => password = value; }
    public string Identity;// { get => identity; set => identity = value; }

    public override string ToString()
    {

        return "phone="+Phone + "password="+Password + "identity=" +Identity;
    }
}
