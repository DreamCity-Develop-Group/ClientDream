/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:50:30
  *
  * Description: 好友添加，删除，点赞，搜索响应处理
  *
  * Version:    0.1
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FriendHandler : HandlerBase
{
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
                applyfriendRespon();
                break;
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();
    private void listfriendRespon(object value)
    {
        
    }
    private void searchfriendRespon(object value)
    {
       
    }
    private void addfriendRespon(object value)
    {
        
    }
    List<UserInfo> applyList = new List<UserInfo>();
    private void applyfriendRespon()
    {

    }
}
