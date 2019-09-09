using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LgoinPanel : UIBase
{
    Button btnLogin;
    Button btnReg;
    Button btnIdentityLog;
    Button btnForget;
    InputField inputUserName;
    InputField inputPassWord;
    InputField inputIdentity;
    Button btnGetIdentity;

    Text textIdentityLog;
    string username = "jx";
    string password = "123";
    string identity = "000";

    bool isLogIdentity = false;
    LoginInfo loginInfo;
    private void Awake()
    {
        Bind(UIEvent.LOG_ACTIVE);
    }

    public override void Execute(int eventCode,  object message)
    {
        switch (eventCode)
        {
            case UIEvent.LOG_ACTIVE:
                setPanelActive(true);
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

        btnForget = transform.Find("BtnForget").GetComponent<Button>();
        btnLogin = transform.Find("BtnLogin").GetComponent<Button>();
        btnReg = transform.Find("BtnReg").GetComponent<Button>();
        btnIdentityLog = transform.Find("BtnIdentityLog").GetComponent<Button>();
        btnGetIdentity = transform.Find("BtnGetIdentity").GetComponent<Button>();
        btnIdentityLog.onClick.AddListener(clickIdentityLog);
        btnGetIdentity.onClick.AddListener(clickGetIdentity);
        btnLogin.onClick.AddListener(clickLogin);
        btnReg.onClick.AddListener(clickReg);
        btnForget.onClick.AddListener(clickForget);

        textIdentityLog = btnIdentityLog.GetComponent<Text>();

        btnGetIdentity.gameObject.SetActive(false);
        inputIdentity.gameObject.SetActive(false);
        loginInfo = new LoginInfo();
        Dispatch(AreaCode.NET, EventCmd.init, null);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnLogin.onClick.RemoveAllListeners();
        btnGetIdentity.onClick.RemoveAllListeners();
        btnIdentityLog.onClick.RemoveAllListeners();
    }


    private void clickForget()
    {
        Dispatch(AreaCode.NET, UIEvent.Forget_ACTIVE, null);
        Debug.Log("clickGetIdentity");
    }
    private void clickGetIdentity()
    {
        Dispatch(AreaCode.NET,EventCmd.identy,null);
        Debug.Log("clickGetIdentity");
    }
    private void clickIdentityLog()
    {
        if (!isLogIdentity)
        {
            textIdentityLog.text = "密码登入";
            inputPassWord.gameObject.SetActive(false);
            inputIdentity.gameObject.SetActive(true);
            btnGetIdentity.gameObject.SetActive(true);
            isLogIdentity = !isLogIdentity;
        }
        else
        {
            textIdentityLog.text = "验证码登入";
            inputPassWord.gameObject.SetActive(true);
            inputIdentity.gameObject.SetActive(false);
            btnGetIdentity.gameObject.SetActive(false);
            isLogIdentity=!isLogIdentity;
        }
       
    }
    private void clickReg()
    {
        setPanelActive(false);
        Dispatch(AreaCode.UI,UIEvent.REG_ACTIVE,null);
    }
    private void clickLogin()
    {
      
        username = inputUserName.text;
        loginInfo.UserName = username;
        if (isLogIdentity)
        {
            identity = inputIdentity.text;
            loginInfo.Password = identity;
            Dispatch(AreaCode.NET, EventCmd.pwlogin, loginInfo);
        }
        else
        {
            password = inputPassWord.text;
            loginInfo.Password = password;
            Dispatch(AreaCode.NET, EventCmd.idlogin, loginInfo);
        }
    }
}
