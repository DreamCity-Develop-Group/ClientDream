using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using LitJson;
using WebSocketSharp;
using System.Text;

public class WebData
{
    /// <summary>  
    /// The WebSocket address to connect  
    /// </summary>  
    //private readonly string address = "ws://192.168.0.102:8010/dream/city/";
    private readonly string address = "ws://192.168.0.102:8011/dream/city/lili/你发";

    /// <summary>  
    /// Default text to send  
    /// </summary>  
    private string _msgToSend = "Hello World!";

    /// <summary>
    /// 心跳时间
    /// </summary>
    private int recTimes;

    /// <summary>
    /// 重连判断
    /// </summary>
    public  bool isReconnect=false;
    /// <summary>  
    /// Debug text to draw on the gui  
    /// </summary>  
    private string _text = string.Empty;

    /// <summary>  
    /// Saved WebSocket instance  
    /// </summary>  
    private WebSocket _webSocket;

    private Queue<SocketMsg> _msgQueue = new Queue<SocketMsg>();

    public Queue<SocketMsg> MsgQueue { get { return _msgQueue; } }
    public WebSocket WebSocket { get { return _webSocket; } }
    public string Address { get { return address; } }
    public string Text { get { return _text; } }

    //public string MsgToSend
    //{
    //    get { return _msgToSend; }
    //    set
    //    {
    //        _msgToSend = value;
    //        SendMsg(value);
    //    }
    //}
    public WebSocket testSocket;
   
    public  void OpenWebSocket()
    {
            if (_webSocket == null)
            {
            // Create the WebSocket instance  
            _webSocket = new WebSocket(address,null);
            // Start connecting to the server  
            _webSocket.Connect();
            //if (HTTPManager.Proxy != null)
            //    _webSocket.InternalRequest.Proxy = new HTTPProxy(HTTPManager.Proxy.Address, HTTPManager.Proxy.Credentials, false);
            // Subscribe to the WS events  
            _webSocket.OnOpen += (sender, e) => {
                OnOpen();
             };
            _webSocket.OnMessage += (sender, e) => {
               
                OnMessageReceived(e.Data);
               
            };
            //_webSocket.Accept
            _webSocket.OnClose += (sender, e) => {
                OnClosed(e.Reason);
            };
            _webSocket.OnError += (sender, e) => {
                OnError(e.Exception,e.Message);
            };
            //await _webSocket.ConnectAsync(new Uri(address), CancellationToken.None);
            //OnReceived();
            
        }
    }
    //readonly CancellationToken _cancellation = new CancellationToken();
    public   void SendMsg(object msg)
    {
        // Send message to the server  
     
            if (_webSocket == null)
            {
                ReConnect();
            }
            //string jsonmsg = JsonMapper.ToJson(msg);
            string jsonmsg = JsonMapper.ToJson(msg);
            Debug.Log(jsonmsg);
        _webSocket.Send(jsonmsg);
        //TODO

        //var bsend = new byte[1024];
        ////bsend = jsonmsg.System.Text.Encoding.Default.GetBytes(str);
        //await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Text, true, CancellationToken.None); //发送数据

    }
    //WebSocketCloseStatus closeStatus;
    string statusDescription;
    public void CloseSocket()
    {
        // Close the connection  
       
        threads.Enqueue(t1);
        t1.Abort();
        _webSocket.Close(1000, "Bye!");
        //_webSocket.CloseAsync( closeStatus, statusDescription, CancellationToken.None);
        _webSocket = null;
    }
    /// <summary>
    /// 心跳检测
    /// </summary> 
    Thread t1;
    int timeout = 3000;
    private static object lockObj = new object();
    private void heartCheck()
    {
        while (true)
        {
            lock (lockObj)
            {
                Thread.Sleep(timeout);
            //  SocketMsg msg = new SocketMsg(null, null, "ping", null);

                isReconnect = false;

                _webSocket.Send("ping_"+PlayerPrefs.GetString("username"));
            }
           
        }

    }

    /// <summary>  
    /// Called when the web socket is open, and we are ready to send and receive data  
    /// </summary>  
    void OnOpen()
    {
        recTimes = 0;
        isReconnect = true;
        if (PlayerPrefs.HasKey("token"))
        {
            Dictionary<string, string> logMsg = new Dictionary<string, string>()
            {
                ["token"] = PlayerPrefs.GetString("token"),
            };
            SendMsg(logMsg);
        }
        Debug.Log("-WebSocket Open!\n");
    }
    //async void OnReceived()
    //{
    //    while (true)
    //    {
    //        try
    //        {
    //            var array = new byte[1024];

    //            var result =await _webSocket.ReceiveAsync(new ArraySegment<byte>(array), new CancellationToken());//接受数据
    //            if (result.MessageType == WebSocketMessageType.Text)
    //            {
    //                string msg = Encoding.UTF8.GetString(array, 0, result.Count);
    //                Console.WriteLine(msg);
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            Console.WriteLine(e.Message);
    //        }
    //    }

    //}

    /// <summary>  
    /// Called when we received a text message from the server  
    /// </summary>  
    void OnMessageReceived(string jsonmsg)
     {

        if (jsonmsg.Contains("success"))
        {
            if (jsonmsg.Length>7)
            {
                PlayerPrefs.SetString("token", jsonmsg.Substring(8));
            }
            isReconnect = true;
            Debug.Log("isconnect"+jsonmsg);
            return;
        }
        //TODO

        //var result = new byte[1024];

        //await _webSocket.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());//接受数据

        //var lastbyte = ByteCut(result, 0x00);

        //var str = Encoding.UTF8.GetString(lastbyte, 0, lastbyte.Length);

        //if(datainfo.info[0].OpCode.Equals("init"))
        //PlayerPrefs.SetString("clientId", datainfo.info[0].ClientId);
       
        Debug.LogError(jsonmsg);
        //SocketMsg info = JsonUtility.FromJson<Serialization<SocketMsg>>(jsonmsg).ToList();
        SocketMsg info = JsonMapper.ToObject<SocketMsg>(jsonmsg);
        // SocketMsg info = JsonUtility.FromJson<SocketMsg>(jsonmsg);
        
        Debug.Log("test"+info.target+","+info.desc+","+info.data.model);
        if (info != null)
        {
            //TODO 过滤过时消息
            //if()
            _msgQueue.Enqueue(info);
        }
    }

    private byte[] ByteCut(byte[] result, int v)
    {
        throw new NotImplementedException();
    }

    /// <summary>  
    /// Called when the web socket closed  
    /// </summary>  
    void OnClosed(string message)
    {
        t1.Abort();
        isReconnect = false;
        ReConnect();
        Debug.Log(string.Format("-WebSocket closed! Code:  Message: [0]\n", message));
    }

    /// <summary>
    /// 断线重连
    /// </summary>
    private void ReConnect()
    {
        if (!isReconnect)
        {
            if (recTimes < 59)
            {
                recTimes += 1;
                OpenWebSocket();
            }
            else
            {
                //TODO跳到登入场景中去
                Debug.LogError("网络断开");
            }
        }
    }
    /// <summary>
    ///线程处理
    /// </summary>
    Queue<Thread> threads = new Queue<Thread>();
    public void ThreadStart()
    {
        if (threads.Count > 0)
        {
            t1 = threads.Dequeue();
        }
        else
        {
            t1 = new Thread(heartCheck);
            t1.Start();
            t1.IsBackground = true;
        }
    }
    /// <summary>  
    /// Called when an error occured on client side  
    /// </summary>  
    void OnError(Exception ex, string  error)
    {
        //string errorMsg = string.Empty;
        //if (ws.InternalRequest.Response != null)
        //    errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);

        Debug.Log(string.Format("-An error occured: {0}\n", ex != null ? ex.Message : "Unknown Error " + error));
        _webSocket = null;
    }
}



