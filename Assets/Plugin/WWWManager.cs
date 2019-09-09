using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
/*
    支持所有加载
    www.text; 返回文本字符串[http,json,xml]
    www.texture; 返回贴图[图片]
    www.movie; 返回视频
	www.size;取加载的文件
    www.assetBundle; 返回打包的资源文件[自己打包的压缩文件]
*/



public class WWWManager
{
    enum WWWType
    {
        TEXT, ASSETBUNDEL, MOVIE, TEXTURE,AUDIOCLIP,SCENE,FILE
    }
    private static string _url = null;
    //加载www.assetBundle使用
    private static Dictionary<string, Object> dict = new Dictionary<string, Object>();
    private static int _version = -1;

    private static WWWType types;//加载的类型
    static WWW www = null;
    private static float _progress = 0.1f;
    private static UnityAction<object> _callBackComplate = null;
    private static UnityAction<string> _callBackError = null;

    public static void LoadTexture(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        WWWManager.types = WWWManager.WWWType.TEXTURE;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    public static void LoadText(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        WWWManager.types = WWWManager.WWWType.TEXT ;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    public static void LoadAssetBundel(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        //Debug.Log("urls: " + _urls);
        WWWManager.types = WWWManager.WWWType.ASSETBUNDEL;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    public static void LoadAudioClip(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        WWWManager.types = WWWManager.WWWType.AUDIOCLIP;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    public static void LoadScene(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        WWWManager.types = WWWManager.WWWType.SCENE;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    public static void LoadFile(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err = null, int _verstion = -1)
    {
        WWWManager.types = WWWManager.WWWType.FILE;
        WWWManager.Load(_urls, _parents, _complate, _err, _verstion);
    }
    private static void Load(string _urls, MonoBehaviour _parents, UnityAction<object> _complate, UnityAction<string> _err=null, int _verstion = -1)
    {
        WWWManager._url = _urls;
        WWWManager._callBackComplate = _complate;
        WWWManager._callBackError = _err;
        WWWManager._version = _verstion;
        _parents.StartCoroutine(innerLoad());
    }

    static IEnumerator innerLoad()
    {        
        if (WWWManager._version != -1)
            //加载assetBundel
            www = WWW.LoadFromCacheOrDownload(WWWManager._url, WWWManager._version);
        else
            //加载text,texture,json,xml.http
            www = new WWW(WWWManager._url);//5
        //UnityEngine.Debug.Log(WWWManager._url);
        //等待完成
        yield return www;
        //判断是否加载完成
        if (www.error == null || www.error.Length <= 0)
        {
            WWWManager.doResult(www);
        }
        else
        {
            if (WWWManager._callBackError != null)
            {
                WWWManager._callBackError(www.text);
            }
        }
    }   
    static void doResult(WWW www)
    {      
        switch(types)
        {
            case WWWType.TEXT:
                WWWManager._callBackComplate(www.text);
                break;
            case WWWType.TEXTURE:
                WWWManager._callBackComplate(www.texture);
                break;
            case WWWType.MOVIE:
                WWWManager._callBackComplate(www.GetMovieTexture());
                break;
            case WWWType.SCENE:
                WWWManager._callBackComplate(www.bytes);
                //www.assetBundle.Unload(false);
                break;
            case WWWType.FILE:
                WWWManager._callBackComplate(www.bytes);
                break;
            case WWWType.ASSETBUNDEL:				
                //取出所有资源
                Object[] objects = www.assetBundle.LoadAllAssets();
                for (int i = 0; i < objects.Length; i++)
                {
                    Object _object = objects[i];
                    if (dict.ContainsKey(_object.name))
                    {
                        dict.Remove(_object.name);
                    }
                    UnityEngine.Debug.Log(_object.name);
                    dict.Add(_object.name, _object);
                }
                www.assetBundle.Unload(false);
                WWWManager._callBackComplate(www.assetBundle);
                break;
        }
        www = null;
    }
    


    public static T Get<T>(string name) where T : Object
    {
        if (dict.ContainsKey(name))
        {
            return (T)dict[name];
        }
        return null;
    }

    public static float Progress
    {
        get
        {
            return www.progress;
        }
    }
}