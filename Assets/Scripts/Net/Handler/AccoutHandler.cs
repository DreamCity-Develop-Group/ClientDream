using System;
using System.Collections.Generic;
using UnityEngine;

public class AccoutHandler: HandlerBase
{
   // SocketMsg msg = new SocketMsg();

    public  override bool OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            //case EventType.init:
            //   return  initResponse(value.ToString());
            case EventType.login:
                return loginResponse(value.ToString());
            case EventType.regist:
                return registResponse(value.ToString());
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();
 

    //private bool initResponse(string  msg)
    //{
    //    PlayerPrefs.SetString("ClientId", msg);
    //    Debug.LogError("initResponse"+msg);
    //    return true;
    //}

    /// <summary>
    /// 登录响应
    /// </summary>
    private bool loginResponse(string result)
    {
        promptMsg.Change(result, Color.red);
        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        if (result == "登入成功")
        {
            //跳转场景 TODO
            SceneMsg msg = new SceneMsg("menu", 
                delegate () {

                Debug.Log("场景加载完成");
            });
            //
            Dispatch(AreaCode.SCENE,SceneEvent.MENU_PLAY_SCENE,msg);
            return true;
        }
        return false;
        //登录错误
        //promptMsg.Change(result.ToString(), Color.red);
        //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
    }

    /// <summary>
    /// 注册响应
    /// </summary>
    private bool registResponse(string result)
    {
        if (result == "注册成功!")
        {
            promptMsg.Change(result.ToString(), Color.green);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            Dispatch(AreaCode.UI, UIEvent.REG_ACTIVE, false);
            Dispatch(AreaCode.UI,UIEvent.LOG_ACTIVE,true);
            return true;
        }
        promptMsg.Change(result, Color.red);
        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
       
        return false;
        //注册错误
       // promptMsg.Change(result.ToString(), Color.red);
        //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
    }
    private bool forgetpwReponse(string result)
    {
        if (result == "修改成功!")
        {
            promptMsg.Change(result.ToString(), Color.green);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
            return true;
        }
        return false;
    }
}
