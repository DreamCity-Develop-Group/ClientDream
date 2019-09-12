using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel: UIBase
{
    Button btnMusic;
    Button btnHelp;
    Button btnChangePW;
    Button btnChangeExPW;
    Button btnExit;
    Button btnClose;
    private void Awake()
    {
        Bind(UIEvent.SET_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SET_PANEL_ACTIVE:
                setPanelActive(true);
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        setPanelActive(false);
        btnMusic = transform.Find("BtnMusic").GetComponent<Button>();
        btnHelp  = transform.Find("BtnHelp").GetComponent<Button>();
        btnChangeExPW = transform.Find("BtnChangeExPW").GetComponent<Button>();
        btnChangePW = transform.Find("BtnChangePW").GetComponent<Button>();
        btnExit = transform.Find("BtnExit").GetComponent<Button>();
        btnClose = transform.Find("BtnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(clickClose);
        btnMusic.onClick.AddListener(clickMusic);
        btnExit.onClick.AddListener(clickExit);
        setPanelActive(false);
    }

    private void clickMusic()
    {
        PlayerPrefs.SetString("gamevoice","true");

        //Dispatch(AreaCode.NET,EventType.set,)
    }
    private void clickExit()
    {
        Dispatch(AreaCode.NET,EventType.exit,null);
        Application.Quit();
    }
    private void clickClose()
    {
        setPanelActive(false);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnClose.onClick.RemoveAllListeners();
        //btnMusic.onClick.RemoveAllListeners();
        //btnHelp.onClick.RemoveAllListeners();
        //btnChangeExPW.onClick.RemoveAllListeners();
        //btnChangePW.onClick.RemoveAllListeners();
    }







}
