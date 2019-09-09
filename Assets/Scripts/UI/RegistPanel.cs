﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistPanel : UIBase
{
    Button btnRegist;
    Button btnIdentify;
    Button btnReturn;
    InputField inputIdentify;
    InputField inputUserName;
    InputField inputPassWord;
    InputField inputNickName;
    InputField inputInviteCode;

    string phone;
    string identify;
    string passWord;
    string nickName;
    string inviteCode;
    //InputField inputRePassWord;
    private void Awake()
    {
        Bind(UIEvent.REG_ACTIVE);
        setPanelActive(false);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.REG_ACTIVE:
                 setPanelActive(true);
                break;
            default:
                break;
        }
    }

    void Start()
    {
        btnIdentify = transform.Find("BtnIdentify").GetComponent<Button>();
        btnRegist = transform.Find("BtnRegist").GetComponent<Button>();
        btnReturn = transform.Find("BtnReturn").GetComponent<Button>();
        inputUserName = transform.Find("InputUserName").GetComponent<InputField>();
        inputIdentify = transform.Find("InputIdentify").GetComponent<InputField>(); 
        inputPassWord = transform.Find("InputPassWord").GetComponent<InputField>();
        inputNickName = transform.Find("InputNickName").GetComponent<InputField>();
        inputIdentify = transform.Find("InputIdentify").GetComponent<InputField>();

        btnIdentify.onClick.AddListener(clickIdentify);
        btnRegist.onClick.AddListener(clickRegist);
        btnReturn.onClick.AddListener(clickReturn);
    }
    private void clickIdentify()
    {
        Debug.Log("clickIdentify");
    }
    private void clickReturn()
    {
        setPanelActive(false);
        Dispatch(AreaCode.UI,UIEvent.LOG_ACTIVE,null);
    }
    private void clickRegist()
    {
        phone=inputUserName.text;
        passWord = inputPassWord.text;
        inviteCode = inputPassWord.text;
        nickName = inputNickName.text;
        identify = inputIdentify.text;
        UserInfo userinfo = new UserInfo(phone,passWord,identify,inviteCode,nickName);
        Dispatch(AreaCode.NET,EventCmd.regist, userinfo);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnIdentify.onClick.RemoveAllListeners();
        btnRegist.onClick.RemoveAllListeners();
        btnReturn.onClick.RemoveAllListeners();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}