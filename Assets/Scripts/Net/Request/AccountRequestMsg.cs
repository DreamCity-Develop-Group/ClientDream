using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountRequestMsg
{
    /// <summary>
    /// 登入消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg PWLoginMsg(object msg)
    {
            LoginInfo loginInfo = msg as LoginInfo;
            MessageData messageData = new MessageData();
            string userpass = MsgTool.MD5Encrypt(loginInfo.Password);
            messageData.t = new Dictionary<string, string>
            {
               // ["IsIdentityLog"] = loginInfo.Identity,
                ["username"] = loginInfo.UserName,
                ["userpass"] = userpass,
                //["Identity"] = loginInfo.Identity
            };
            messageData.model = "user";
            messageData.type = "pwlog";
            SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "登入操作", messageData);
            return socketMsg;
    }
    /// <summary>
    /// 忘记密码消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg PWChangeMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        MessageData messageData = new MessageData();
        string userpass = MsgTool.MD5Encrypt(loginInfo.Password);
        messageData.t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["userpass"] = userpass,
            ["Identity"] = loginInfo.Identity
        };
        messageData.model = "set";
        messageData.type = "expw";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "修改登入密码操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 添加好友消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg AddFriendMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        MessageData messageData = new MessageData();
        string userpass = MsgTool.MD5Encrypt(loginInfo.Password);
        messageData.t = new Dictionary<string, string>
        {
            ["username"] = loginInfo.UserName,
        };
        messageData.model = "friend";
        messageData.type = "addfriend";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "添加好友操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 验证码登入消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg IDLoginMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["userpass"] = loginInfo.Password,
            //["Identity"] = loginInfo.Identity
        };
        messageData.model = "user";
        messageData.type = "idlog";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "登入操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 注册消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReRegMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["username"] = userinfo.Phone,
            ["userpass"] = userinfo.Password,
            ["code"] = userinfo.Identity,
            ["nick"] = userinfo.NickName,
            ["invite"] = userinfo.InviteCode
        };
        messageData.model = "account";
        messageData.type = "reg";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "注册操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 设置交易密码
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReExPwShopMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["username"] = userinfo.Phone,
            ["userpass"] = userinfo.Password,
            ["code"] = userinfo.Identity,
            ["NickName"] = userinfo.NickName,
            ["invite"] = userinfo.InviteCode
        };
        messageData.model = "account";
        messageData.type = "reg";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "注册操作", messageData);
        return socketMsg;
    }

    /// <summary>
    /// 音效设置
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReVoiceSetMsg(object msg)
    {
        SetInfo setInfo = msg as SetInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["bg"] = setInfo.BgVoice,
            ["game"]=setInfo.GameVoice

        };
        messageData.model = "account";
        messageData.type = "reg";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "音效设置", messageData);
        return socketMsg;
    }
}
