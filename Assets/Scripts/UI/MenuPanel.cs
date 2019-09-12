using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIBase
{
    Button btnFriends;
    Button btnSet;
    Button btnMsg;
    Button btnCommerce;//商会
    Button btnTreasure;//资产
    Button btnAdd;

    string textForEncoding;

    
    private void Start()
    {
        btnTreasure = transform.Find("BtnTreasure").GetComponent<Button>();
        btnCommerce = transform.Find("BtnCommerce").GetComponent<Button>(); 
        btnSet = transform.Find("BtnSet").GetComponent<Button>();
        btnMsg = transform.Find("BtnMsg").GetComponent<Button>();
        btnFriends = transform.Find("BtnFriends").GetComponent<Button>();
        
        btnAdd = transform.Find("BtnAdd").GetComponent<Button>();

        btnAdd.onClick.AddListener(clickAdd);
        btnTreasure.onClick.AddListener(clickTreasure);
        btnSet.onClick.AddListener(clickSet);
        btnFriends.onClick.AddListener(clickFriend);
        
    }
    private void clickAdd()
    {
        //测试
        //获取二维码字符串
        textForEncoding = "0x8dbd8843d9e9de809c19ed53e0403475c987ab15";
        //CreatQRcode(textForEncoding,)
        //Sprite spriteQRcode=GetSprite(textForEncoding);
        // Dispatch(AreaCode.Net,EventType);
        
        Dispatch(AreaCode.UI,UIEvent.QRECODE_PANEL_ACTIVE,CreatQRcode(textForEncoding));

    }
    private Texture2D CreatQRcode(string textForEncoding, Texture2D logo = null)
    {
        if (string.IsNullOrEmpty(textForEncoding))
        {
            return null;
        }
        Texture2D encode = new Texture2D(100, 100, TextureFormat.RGBA32, false);
        var colors = MsgTool.Encode(textForEncoding, encode.width, encode.height);
        encode.SetPixels32(colors);
        //if (logo != null)
        //{
        //    int x = (encode.width-logo.width) / 2;
        //    int y = (encode.height-logo.height) / 2;
        //    Color32[] colorlogo = logo.GetPixels32();
        //    encode.SetPixels32(x,y,logo.width,logo.height,colorlogo);
        //}
        encode.Apply();
        return encode;
    }
    private void clickFriend()
    {
        Dispatch(AreaCode.UI, UIEvent.FRIEND_PANEL_ACTIVE, null);
    }
    private void clickTreasure()
    {
        Dispatch(AreaCode.UI,UIEvent.CHARGE_PANEL_ACTIVE,null);
    }

    private void clickSet()
    {
        Dispatch(AreaCode.UI,UIEvent.SET_PANEL_ACTIVE,null);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        btnTreasure.onClick.RemoveAllListeners();
        btnSet.onClick.RemoveAllListeners();
    }

}
