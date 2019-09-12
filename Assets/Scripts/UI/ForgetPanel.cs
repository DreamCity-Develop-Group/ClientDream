using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgetPanel : UIBase
{
    Button btnCommit;
    Button btnReg;
    Button btnForget;
    Button btnGetIdentity;

    InputField inputUserName;
    InputField inputPassWord;
    InputField inputIdentity;

    Text textIdentityLog;
    string username = "jx";
    string password = "123";
    string identity = "000";

    LoginInfo loginInfo;
    private void Awake()
    {
        Bind(UIEvent.Forget_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.Forget_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        inputUserName = transform.Find("InputUserName").GetComponent<InputField>();
        inputPassWord = transform.Find("InputPassWord").GetComponent<InputField>();
        inputIdentity = transform.Find("InputIdentity").GetComponent<InputField>();

        btnCommit = transform.Find("BtnCommit").GetComponent<Button>();
        btnReg = transform.Find("BtnReg").GetComponent<Button>();
        btnGetIdentity = transform.Find("BtnGetIdentity").GetComponent<Button>();
        btnGetIdentity.onClick.AddListener(clickGetIdentity);
        btnCommit.onClick.AddListener(clickCommit);
        btnReg.onClick.AddListener(clickReg);


        btnGetIdentity.gameObject.SetActive(false);
        inputIdentity.gameObject.SetActive(false);
        
        loginInfo = new LoginInfo();
        setPanelActive(false);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnCommit.onClick.RemoveAllListeners();
        btnGetIdentity.onClick.RemoveAllListeners();
    }


    private void clickForget()
    {

    }
    private void clickGetIdentity()
    {
        Dispatch(AreaCode.NET, EventType.identy, null);
        Debug.Log("clickGetIdentity");
    }
    private void clickReg()
    {
        setPanelActive(false);
        Dispatch(AreaCode.UI, UIEvent.REG_ACTIVE, null);
    }
    private void clickCommit()
    {

        username = inputUserName.text;
        password = inputPassWord.text;
        identity = inputIdentity.text;

        loginInfo.UserName = username;
        loginInfo.Password = password;
        loginInfo.Identity = identity;

        Dispatch(AreaCode.NET, EventType.pwforget, loginInfo);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
