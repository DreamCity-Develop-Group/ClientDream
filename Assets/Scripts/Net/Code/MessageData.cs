using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MessageData
{
   
    // public string type;
   
    // protected string model;
    ////具体业务数据

    //事件类型
    public string type;// { get => type; set => type = value; }
    //接收事件处理的模块
    public string model;//{ get => model; set => model = value; }

    public Dictionary<string, string> t=new Dictionary<string, string>(); // { get => job; set => job = value; }
    public MessageData()
    {

    }
    public override string ToString()
    {
        return "type=" + type + "model=" + model;
    }
}