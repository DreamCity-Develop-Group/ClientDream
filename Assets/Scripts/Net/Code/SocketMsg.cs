using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 网络消息
/// 作用：发送的时候 都要发送这个类
/// </summary>
[System.Serializable]
public class SocketMsg
{
    //源clientid
    // private string source;
    // // 消息数据
    // private MessageData data;
    // // 发送目的地
    // private string target;
    // // 消息保存时间
    //// private string createtime;
    // // 其他信息
    // private string desc;

    public  MessageData data=new MessageData() ;//{ get => data; set => data = value; }
    public string desc;//{ get => desc; set => desc = value; }
    public string target;//{ get => target; set => target = value; }
    public string createtime;// { get => createtime; set => createtime = value; }
    public string source;//{ get => source; set => source = value; }
    public SocketMsg()
    {
        
    }

    public  SocketMsg(string Source,string desc, MessageData data, string target="server")
    {
        source = Source;
        this.target = target;
        createtime = GetTimeStamp();
        this.desc = desc;
        this.data = data;
    }
    /// <summary>
    /// 防止重复创建socket
    /// </summary>
    public void Change()
    {
        //this.source = source;
        //this.target = target;
        //this.createtime = GetTimeStamp();
        //this.desc = desc;
        //this.data = data;
        //if (source != null || source != "")
        //{
        //    ClientId = source;
        //    this.source = ClientId;
        //}
    }
    public override string ToString()
    {
        StringBuilder str = new StringBuilder(6);
        str.Append("Message[");
        str.Append("source="+source);
        str.Append("target=" + target);
        str.Append("createtime=" + createtime);
        str.Append("data="+data.ToString());
        str.Append("]");
        return str.ToString();
        //return source + messageType + msgContent+ target+ infoSourceIP+ createtime+ otherContent;
    }
    /// <summary>
    ///  获取时间戳
    /// </summary>
    /// <returns></returns>
    private string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }
}



