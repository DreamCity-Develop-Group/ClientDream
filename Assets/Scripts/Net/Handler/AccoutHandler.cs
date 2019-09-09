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
            case AccountCode.INIT:
               return  initResponse(value.ToString());
            case AccountCode.LOGIN:
                return loginResponse(value.ToString());
            case AccountCode.REG:
                return registResponse(value.ToString());
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();
 

    private bool initResponse(string  msg)
    {
        PlayerPrefs.SetString("ClientId", msg);
        Debug.LogError("initResponse"+msg);
        return true;
    }

    /// <summary>
    /// 登录响应
    /// </summary>
    private bool loginResponse(string result)
    {
        //switch (result)
        //{
        //    case 0:
        //        //跳转场景
        //        //SceneMsg sceneMsg = new SceneMsg("1-menu",
        //        //    delegate ()
        //        //    {
        //        //        //TODO
        //        //        Debug.Log("场景加载完成");
        //        //    }
        //        // );
        //        //Dispatch(AreaCode.SCENE,SceneEvent.MENU_PLAY_SCENE,sceneMsg);

        //        break;
        //    case -1:
        //        promptMsg.Change("账号不存在", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    case -2:
        //        promptMsg.Change("账号在线", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    case -3:
        //        promptMsg.Change("账号密码不匹配", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    default:
        //        break;
        //}
        promptMsg.Change(result, Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        if (result == "登入成功")
        {
            promptMsg.Change(result.ToString(), Color.green);
            //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
            //跳转场景 TODO
            SceneMsg msg = new SceneMsg("testmenu", 
                delegate () {

                Debug.Log("场景加载完成");
            });

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
        //switch (result)
        //{
        //    case 0:
        //        promptMsg.Change("注册成功", Color.green);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    case -1:
        //        promptMsg.Change("账号已经存在", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    case -2:
        //        promptMsg.Change("账号输入不合法", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    case -3:
        //        promptMsg.Change("密码不合法", Color.red);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        break;
        //    default:
        //        break;
        //}
        promptMsg.Change(result, Color.red);
        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        if (result == "注册成功")
        {
            promptMsg.Change(result.ToString(), Color.green);
            Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, null);
            
            return true;
        }
        return false;
        //注册错误
          promptMsg.Change(result.ToString(), Color.red);
        //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
    }
}
