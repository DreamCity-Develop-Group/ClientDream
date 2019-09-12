
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 09:22:48
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


public class FriendRequestMsg :RequestBase
{
   

    /// <summary>
    /// 申请消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqAddFriendMsg(object msg)
    {
        string applyUserName = msg.ToString();
       // ApplyInfo.applyList.Add(applyUserName);
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["nick"] = applyUserName
        };
        messageData.model = "friend";
        messageData.type = "addfriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "申请好友操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 申请好友通过/拒绝
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqAgreeFriendMsg(object msg)
    {
        Dictionary<string, string> msgDci = msg as Dictionary<string, string>;
        MessageData messageData = new MessageData();
        //TODO
        messageData.t = msgDci;
        messageData.model = "friend";
        messageData.type = "addfriend";

        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "添加好友操作", messageData);
        //TODO
        //Dispatch(AreaCode.UI,11111,"removeList");
        return socketMsg;
    }
    /// <summary>
    /// 好友点赞
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqLikeFriendMsg(object msg)
    {
        UserInfo userInfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["nick"] = userInfo.NickName,
            ["likes"] = userInfo.Like

        };
        messageData.model = "friend";
        messageData.type = "likefriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "好友点赞", messageData);
        //Dispatch(AreaCode.UI,11111,"activefalse");
        return socketMsg;
    }
    /// <summary>
    /// 搜索用户消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqSearchUserMsg(object msg)
    {
        string nickName = msg.ToString();
        if (nickName == null)
        {
            //TODO提示界面
            return null;
        }
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["nick"] = nickName,
        };
        messageData.model = "friend";
        messageData.type = "searchfriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "搜索用户", messageData);
        return socketMsg;
    }
}
