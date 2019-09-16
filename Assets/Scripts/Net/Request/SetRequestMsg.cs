
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 09:23:12
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetRequestMsg 
{
    /// <summary>
    /// 设置交易密码
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqExPwShopMsg(object msg)
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
        messageData.model = "set";
        messageData.type = "expwshop";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "注册操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 音效设置
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqVoiceSetMsg(object msg)
    {
        SetInfo setInfo = msg as SetInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["bg"] = setInfo.BgVoice,
            ["game"] = setInfo.GameVoice

        };
        messageData.model = "set";
        messageData.type = "voice";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "音效设置", messageData);
        return socketMsg;
    }
}
