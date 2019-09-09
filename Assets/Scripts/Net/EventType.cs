using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *
 *  请求操作事件码
 **/
public class EventType
{
    public const int init = int.MinValue; //连接
    public const int login = 0;//登入
    public const int pwlogin = 1; //密码登入
    public const int idlogin = 2; //验证码登入
    public const int regist = 3;//注册
    public const int identy = 4;//验证码获取
    public const int voiceset = 5;//
    public const int pwforget=6;//忘记密码
    public const int addfriend = 7;//添加好友
    public const int expw = 8;
    public const int expwshop = 9;
    public const int searchfriend = 10;//搜索用户
    public const int likefriend = 11;//好友点赞
    public const int squarefriend = 12;//广场玩家列表
    public const int listfriend = 13;//好友列表
    public const int applyfriend = 14;//申请列表




    public const int exit = int.MaxValue;
}