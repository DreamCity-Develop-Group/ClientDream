using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesMgr : ManagerBase
{
    public static ScenesMgr Instance = null;
    void Awake()
    {
        Instance = this;

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;

        Add(SceneEvent.MENU_PLAY_SCENE,this);
    }
    SceneMsg msg;
    private void Start()
    {
        msg = new SceneMsg();
    }
    public override void Execute(int eventCode,  object message)
    {
        switch (eventCode)
        {
            case SceneEvent.MENU_PLAY_SCENE:
                msg = message as SceneMsg;
                LoadScene(msg);
                break;
            default:
                break;
        }
    }

    private Action OnSceneLoaded = null;

    private void LoadScene(SceneMsg msg)
    {
        if (msg.SceneBuildIndex!=-1)
        {
            SceneManager.LoadScene(msg.SceneBuildIndex);
        }
        if (msg.SceneName!=null)
        {
            SceneManager.LoadScene(msg.SceneName);
        }
        if(msg.OnSceneLoaded !=null)
        {
            OnSceneLoaded = msg.OnSceneLoaded;
        }
      
    }
    /// <summary>
    /// 当场景加载完成的时候调用
    /// </summary>
    private void SceneManager_sceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        if(OnSceneLoaded != null)
        {
            OnSceneLoaded();

            OnSceneLoaded = null;
        }
    }

}
