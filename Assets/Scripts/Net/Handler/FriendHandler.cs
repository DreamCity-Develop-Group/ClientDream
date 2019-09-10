/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:50:30
  *
  * Description: ������ӣ�ɾ�������ޣ�������Ӧ����
  *
  * Version:    0.1
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FriendHandler : HandlerBase
{
    private UserInfo userInfo = new UserInfo();
    public override bool OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case EventType.addfriend:
                addfriendRespon(value);
                break;
            case EventType.listfriend:
                listfriendRespon(value);
                break;
            case EventType.searchfriend:
                searchfriendRespon(value);
                break;
            case EventType.applyfriend:

                applyfriendRespon(value);
                break;
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();

    /// <summary>
    /// �����б�
    /// </summary>
    /// <param name="value"></param>
    private void listfriendRespon(object value)
    {

    }
    private void searchfriendRespon(object value)
    {

    }
    private void addfriendRespon(object value)
    {

    }
    /// <summary>
    /// ��������б�
    /// </summary>
    List<UserInfo> applyList = new List<UserInfo>();
   
    /// <summary>
    /// ���������Ӧ
    /// </summary>
    private void applyfriendRespon(object msg)
    {
        if (msg == null)
        {
            //�Է��ܾ�
        }
        else
        {
            Dictionary<string,string> applyfriendDic = msg as Dictionary<string, string>;
            userInfo.Imgurl = applyfriendDic["imgurl"];
            userInfo.NickName = applyfriendDic["nick"];
            userInfo.FriendLink = applyfriendDic["friendlink"];
            //TODO
        }
    }
    /// <summary>
    /// ����Ӧ��
    /// </summary>
    /// <param name="msg"></param>
    private void searchuserReson(object msg)
    {

    }
}
