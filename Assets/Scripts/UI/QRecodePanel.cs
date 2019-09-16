
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 11:01:10
  *
  * Description: QRcode
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class QRecodePanel : UIBase
{
   
    Button btnSave;
    Button btnClose;
    RawImage imageQRecode;
    Texture2D image;

    private void Awake()
    {
        Bind(UIEvent.QRECODE_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.QRECODE_PANEL_ACTIVE:
                image = message as Texture2D;
                imageQRecode.texture = image;
                setPanelActive(true);
                break;
            default:
                break;
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        btnClose.onClick.RemoveAllListeners();
        btnSave.onClick.RemoveAllListeners();
    }
    void Start()
    {
      
        btnSave = transform.Find("BtnSave").GetComponent<Button>();
        btnClose = transform.Find("BtnClose").GetComponent<Button>();
        imageQRecode = transform.Find("ImageQRecode").GetComponent<RawImage>();

        btnClose.onClick.AddListener(clickClose);
        btnSave.onClick.AddListener(clickSave);
        setPanelActive(false);
       //
    }

    private void clickClose()
    {
        setPanelActive(false);
    }
    private void clickSave()
    {
        StartCoroutine(SaveImages(image));
    }
    byte[] byteImage;
    //    /// <summary>
    //    /// 保存Png图片
    //    /// </summary>
    //    /// <param name="texture"></param>
    //    /// <returns></returns>
    IEnumerator SaveImages(Texture2D texture)
    {
        string path = Application.persistentDataPath;
        //#if UNITY_ANDROID
        //        path = "/storage/emulated/0/DCIM/DreamCity"; //设置图片保存到设备的目.
        //#endif
        //        if (!Directory.Exists(path)) 
        //            Directory.CreateDirectory(path);


        byteImage = texture.EncodeToPNG();
        string savePath = string.Format("{0}/{1}.png", path, "dreamCode");
        File.WriteAllBytes(savePath, byteImage);
        savePngAndUpdate(path);
        yield return new WaitForEndOfFrame();
    }
    public void savePngAndUpdate(string path)
    {
#if UNITY_IOS

#elif UNITY_ANDROID
        //GetAndroidJavaObject().Call("saveImage", fileName, byteImage);
        GetAndroidJavaObject().Call("testCallAndroid");
        GetAndroidJavaObject().Call("requestExternalStorage");
        GetAndroidJavaObject().Call("saveImageToGallery", path, "保存成功");
       
        Debug.Log(path);
#endif
    }
#if UNITY_ANDROID
    public AndroidJavaObject GetAndroidJavaObject()
    {
        return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    }
#endif

    /// <summary>
    /// 生成二维码
    /// </summary>
    /// <param name="textForEncoding"></param>
    /// <param name="logo"></param>
    /// <returns></returns>

    ///// <summary>
    ///// 二维码图片
    ///// </summary>
    ///// <param name="textForEncoding"></param>
    ///// <returns></returns>
    //public Sprite GetSprite(string textForEncoding)
    //{
    //    Texture2D logo = Resources.Load("") as Texture2D;
    //    Texture2D image = CreatQRcode(textForEncoding,logo);
    //    if(image = null)
    //    {
    //        return null;
    //    }
    //    Sprite  tempSprite = Sprite.Create(image,new Rect(0,0,image.width,image.height),new Vector2(0,0));
    //    Resources.UnloadAsset(logo);
    //    //Destroy(image);
    //    //image =null;
    //    return tempSprite;
    //}
}
