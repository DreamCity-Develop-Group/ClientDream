
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 16:50:31
  *
  * Description: 好友界面
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendPanel : UIBase 
{

    private void Awake()
    {
        Bind(UIEvent.FRIEND_PANEL_ACTIVE);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.FRIEND_PANEL_ACTIVE:
                setPanelActive(true);
                break;
            default:
                break;
        }
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    Button btnFriend;
    Button btnGround;
    Button btnSearch;
    Button btnApply;
    Button btnClose;
    InputField inputSearch;

    string nickName;
    Text textTitle;
    private void Start()
    {
        inputSearch = transform.Find("InputSearch").GetComponent<InputField>();
        btnFriend = transform.Find("BtnFriend").GetComponent<Button>();
        btnApply = transform.Find("BtnApply").GetComponent<Button>();
        btnGround = transform.Find("BtnGround").GetComponent<Button>(); 
        btnSearch = transform.Find("BtnSearch").GetComponent<Button>();
        btnClose = transform.Find("BtnClose").GetComponent<Button>();
        textTitle = transform.Find("TextTitle").GetComponent<Text>();

        btnFriend.onClick.AddListener(clickFriend);
        btnSearch.onClick.AddListener(clickSearch);
        btnApply.onClick.AddListener(clickApply);
        btnGround.onClick.AddListener(clickGround);
        btnClose.onClick.AddListener(clickClose);
        setPanelActive(false);
    }
    private void clickClose()
    {
        setPanelActive(false);
    }
    private void clickGround()
    {
        textTitle.text = "广场";
    }
    private void clickFriend()
    {
        textTitle.text = "好友";
    }
    private void clickApply()
    {
        textTitle.text = "申请";
    }
    private void clickSearch()
    {
        nickName = inputSearch.text;
        Dispatch(AreaCode.NET,EventType.searchfriend,nickName);
    }
}
