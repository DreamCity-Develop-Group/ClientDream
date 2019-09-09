using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountRequestMsg
{
    public SocketMsg ReLoginMsg(object msg)
    {
            LoginInfo loginInfo = msg as LoginInfo;
            MessageData messageData = new MessageData();
            messageData.t = new Dictionary<string, string>
            {
               // ["IsIdentityLog"] = loginInfo.Identity,
                ["username"] = loginInfo.Phone,
                ["userpass"] = loginInfo.Password,
                //["Identity"] = loginInfo.Identity
            };
            messageData.model = "user";
            messageData.type = "log";
            SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "登入操作", messageData);
            return socketMsg;
    }


    public SocketMsg ReRegMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["Phone"] = userinfo.Phone,
            ["Password"] = userinfo.Password,
            ["Identity"] = userinfo.Identity,
            ["NickName"] = userinfo.NickName,
            ["InviteCode"] = userinfo.InviteCode
        };
        messageData.model = "account";
        messageData.type = "reg";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "", "注册操作", messageData);
        return socketMsg;
    }

}
