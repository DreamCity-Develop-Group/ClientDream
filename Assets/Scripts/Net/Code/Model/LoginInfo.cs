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

    public LoginInfo(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
        //this.IsIdentity = Isidentity;
    }
    public static string ClientId;
    public string IsIdentityLog;
    public string UserName;//{ get => phone; set => phone = value; }
    public string Password;// { get => password; set => password = value; }
    public string Identity;// { get => identity; set => identity = value; }

    public override string ToString()
    {

        return "phone="+ UserName + ",password="+Password ;
    }
}
