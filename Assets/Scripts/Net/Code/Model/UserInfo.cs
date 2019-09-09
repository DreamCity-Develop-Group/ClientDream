using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserInfo
{
    //private string phone;
    //private string password;
    //private string identity;
    //private string inviteCode;
    //private string nickName;

    public UserInfo()
    {

    }
    public UserInfo(string phone, string password, string identity, string inviteCode, string nickName)
    {
        this.Phone = phone;
        this.Password = password;
        this.Identity = identity;
        this.InviteCode = inviteCode;
        this.NickName = nickName;
    }
    public string Like;
    public string Imgurl;
    public string FriendLink;
    public string Phone;//{ get => phone; set => phone = value; }
    public string Password;// { get => password; set => password = value; }
    public string Identity;//{ get => identity; set => identity = value; }
    public string InviteCode;// { get => inviteCode; set => inviteCode = value; }
    public string NickName;//{ get => nickName; set => nickName = value; }

    public override string ToString()
    {
        return "phone="+Phone + ",password"+Password + ",inviteCode" +InviteCode+",nickName"+NickName;
    }
}
