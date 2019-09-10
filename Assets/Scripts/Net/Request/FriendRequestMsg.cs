
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


public class FriendRequestMsg 
{
    /// <summary>
    /// ��UI��Ϣ
    /// </summary>
    /// <param name="areaCode">Area code.</param>
    /// <param name="eventCode">Event code.</param>
    /// <param name="message">Message.</param>
    public void Dispatch(int areaCode, int eventCode, object message)
    {
        MsgCenter.Instance.Dispatch(areaCode, eventCode, message);
    }

    /// <summary>
    /// ������Ϣ
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
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "������Ѳ���", messageData);
        return socketMsg;
    }
    /// <summary>
    /// �������ͨ��/�ܾ�
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

        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "���Ӻ��Ѳ���", messageData);
        //TODO
        //Dispatch(AreaCode.UI,11111,"removeList");
        return socketMsg;
    }
    /// <summary>
    /// ���ѵ���
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
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "���ѵ���", messageData);
        //Dispatch(AreaCode.UI,11111,"activefalse");
        return socketMsg;
    }
    /// <summary>
    /// �����û���Ϣ
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqSearchUserMsg(object msg)
    {
        string nickName = msg.ToString();
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, string>
        {
            ["nick"] = nickName,
        };
        messageData.model = "friend";
        messageData.type = "searchfriend";
        SocketMsg socketMsg = new SocketMsg(PlayerPrefs.GetString("ClientId"), "�����û�", messageData);
        return socketMsg;
    }
}