using System;
using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
public class WebSocketManager : ManagerBase
{
    public static WebSocketManager Instance = null;

    private void Awake()
    {
        Instance = this;
        Add(0, this);
    }
    #region 处理发送服务器的请求
    AccountRequestMsg accountRequestMsg = new AccountRequestMsg();
    SocketMsg socketMsg;

    public override void Execute(int eventCode,  object message)
    {
        switch (eventCode)
        {
            case EventType.init:
                //初始化操作
                if (_wabData.WebSocket == null)
                {
                    _wabData.OpenWebSocket();
                    if (PlayerPrefs.HasKey("token"))
                    {
                        Dictionary<string, string> logMsg = new Dictionary<string, string>()
                        {
                            ["token"] = PlayerPrefs.GetString("token"),
                        };
                        _wabData.SendMsg(logMsg);
                    }
                }
                break;
            case EventType.pwlogin:
                //密码登入操作
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.PWLoginMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.idlogin:
                //验证码登入
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.IDLoginMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.regist:
                //注册操作
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.ReRegMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.pwforget:
                //忘记密码
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.PWChangeMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.addfriend:
                //添加好友
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.AddFriendMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.identy:
                //获取验证码
                //TODO
                //if (_wabData.WebSocket != null && _wabData.WebSocket.IsOpen)
                //{

                //    //msg.Change(PlayerPrefs.GetString("clientId"), "", "", "", "", message.ToString());
                //   // _wabData.WebSocket.Send(msg.ToString());
                //}
                break;
            case EventType.expw:
                //修改密码TODO 暂时设置和忘记密码模块一样
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.PWChangeMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.expwshop:
                //设置交易密码
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.PWChangeMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.voiceset:
                //音效设置
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.ReVoiceSetMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.searchfriend:
                //搜索用户
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.SearchUserMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.likefriend:
                //好友点赞
                if (_wabData.WebSocket != null && _wabData.WebSocket.IsAlive)
                {
                    socketMsg = accountRequestMsg.SearchUserMsg(message);
                    _wabData.SendMsg(socketMsg);
                }
                break;
            case EventType.exit:
                //if (_wabData.WebSocket != null && _wabData.WebSocket.IsOpen)
                //{
                //   //msg.Change(PlayerPrefs.GetString("clientId"), "", "", "", "", message[0].ToString());
                //   // _wabData.WebSocket.Send(msg.ToString());
                //}
                //_wabData.WebSocket.Close(1000, "Bye!");

                break;
                
            default:
                break;
        }
    }
    #endregion
    #region Private Fields

    /// <summary>  
    /// The WebSocket address to connect  
    /// </summary>  
    string _address;

    /// <summary>  
    /// Debug text to draw on the gui  
    /// </summary>  
    string _text;

    /// <summary>  
    /// GUI scroll position  
    /// </summary>  
    Vector2 _scrollPos;

    private WebData _wabData;
    //private SocketMsg msg ;

    #endregion

    #region Unity Events

    void Start()
    {
        _wabData = new WebData();
        _address = _wabData.Address;
        _text = _wabData.Text;
        //msg = new SocketMsg();
    }

    void Update()
    {
        if (_wabData.MsgQueue.Count > 0)
        {
            SocketMsg info = _wabData.MsgQueue.Dequeue();
            //string json = JsonUtility.ToJson(info);
            processSocketMsg(info);
            //Debug.Log(json);
        }
    }

    
    void OnDestroy()
    {
        //if (_wabData.WebSocket != null)
        //    _wabData.WebSocket.Close();
    }

    void OnGUI()
    {
        _address = GUILayout.TextField(_address);
    }

   


    #region 处理接收到的服务器发来的消息
    HandlerBase accountHandler = new AccoutHandler();

    /// <summary>
    /// 账号模块
    /// </summary>
    /// <param name="msg"></param>
    private void accountSocketMsg(SocketMsg msg)
    {
        switch (msg.data.type)
        {
            case "log":
                if(accountHandler.OnReceive(EventType.login, msg.data.t["desc"]))
                {
                    if (msg.data.t.ContainsKey("token"))
                    {
                        PlayerPrefs.SetString("token", msg.data.t["token"]);
                    }
                    PlayerPrefs.SetString("username",msg.data.t["username"]);
                    _wabData.ThreadStart();
                }
                break;
           
            case "reg":
                accountHandler.OnReceive(AccountCode.REG, msg.desc);
                break;
            default:
                break;
        }
    }
    HandlerBase setHandler = new SetHandler();
    /// <summary>
    /// 设置模块
    /// </summary>
    /// <param name="msg"></param>
    private void setSocketMsg(SocketMsg msg)
    {
        switch (msg.data.type)
        {
            case "voice":
               // setHandler.OnReceive(EventType.voiceset, msg.data.t);
                break;

            case "expw":
                setHandler.OnReceive(EventType.expw, msg.data.t["desc"]);
                break;
            case "expwshop":
                setHandler.OnReceive(EventType.expw, msg.data.t["desc"]);
                break;
            default:
                break;
        }
    }
    HandlerBase friendHandler = new FriendHandler();
    /// <summary>
    /// friend模块
    /// </summary>
    /// <param name="msg"></param>
    private void friendSocketMsg(SocketMsg msg)
    {
        switch (msg.data.type)
        {
            case "addfriend":
                friendHandler.OnReceive(EventType.addfriend , msg.data.t["desc"]);
                break;
            case "likefriend":
               // friendHandler.OnReceive(EventType.likefriend, msg.data.t["desc"]);
                break;
            case "seachfriend":
                friendHandler.OnReceive(EventType.searchfriend, msg.data.t);
                break;
            case "squarefriend":
                friendHandler.OnReceive(EventType.squarefriend, msg.data.t["desc"]);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 处理接收到的服务器发来的消息模块
    /// </summary>
    /// <param name="msg"></param>
    private void processSocketMsg(SocketMsg msg)
    {
        switch (msg.data.model)
        {
            case "user":
                if (msg.data.t.ContainsKey("desc"))
                {
                    accountSocketMsg(msg);
                }
                break;
            case "socket":
                Debug.Log("target" + msg.target);
                PlayerPrefs.SetString("ClientId", msg.target);
                Debug.Log(PlayerPrefs.GetString("ClientId"));
                accountHandler.OnReceive(AccountCode.INIT, msg.target);
                break;
            case "set":
                setSocketMsg(msg);
                break;
            case "friend":
                friendSocketMsg(msg);
                break;
            default:
                break;
        }
    }
    #endregion
}
#endregion