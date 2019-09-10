using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIBase
{
    Button btnFriends;
    Button btnSet;
    Button btnMsg;
    Button btnCommerce;//商会
    Button btnTreasure;//资产

    private void Start()
    {
        btnTreasure = transform.Find("BtnTreasure").GetComponent<Button>();
        btnCommerce = transform.Find("BtnCommerce").GetComponent<Button>(); 
        btnSet = transform.Find("BtnSet").GetComponent<Button>();
        btnMsg = transform.Find("BtnMsg").GetComponent<Button>();
        btnFriends = transform.Find("BtnFriends").GetComponent<Button>();

        btnTreasure.onClick.AddListener(clickTreasure);
        btnSet.onClick.AddListener(clickSet);
        btnFriends.onClick.AddListener(clickFriend);
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

    private void clickAdd()
    {
        //Texture2D encoded = new Texture2D(200, 200, TextureFormat.RGBA32, false);
        //var colors = Encode("这里是二维码的内容", 200, 200);
        //encoded.SetPixels32(colors);
        //encoded.Apply();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnTreasure.onClick.RemoveAllListeners();
        btnSet.onClick.RemoveAllListeners();
    }

}
