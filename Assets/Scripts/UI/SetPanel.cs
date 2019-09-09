using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel: UIBase
{
    Button btnSet;
    Button btnMusic;
    Button btnHelp;
    Button btnChangePW;
    Button btnChangeExPW;
    Button btnExit;


    private void Start()
    {
        setPanelActive(false);
        btnSet = GameObject.Find("BtnSet").GetComponent<Button>();
        btnMusic = transform.Find("BtnMusic").GetComponent<Button>();
        btnHelp  = transform.Find("BtnHelp").GetComponent<Button>();
        btnChangeExPW = transform.Find("BtnChangeExPW").GetComponent<Button>();
        btnChangePW = transform.Find("BtnChangePW").GetComponent<Button>();
        btnExit = transform.Find("BtnExit").GetComponent<Button>();

        btnMusic.onClick.AddListener(clickMusic);
        btnSet.onClick.AddListener(clickSet);
        btnExit.onClick.AddListener(clickExit);
    }

    private void clickMusic()
    {
        PlayerPrefs.SetString("gamevoice","true");

        //Dispatch(AreaCode.NET,EventCmd.set,)
    }
    private void clickSet()
    {
        setPanelActive(true);
    }

    private void clickExit()
    {
        Dispatch(AreaCode.NET,EventCmd.exit,null);
        Application.Quit();
    }
    private void clickClose()
    {
        setPanelActive(false);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnSet.onClick.RemoveAllListeners();
        //btnMusic.onClick.RemoveAllListeners();
        //btnHelp.onClick.RemoveAllListeners();
        //btnSet.onClick.RemoveAllListeners();
        //btnChangeExPW.onClick.RemoveAllListeners();
        //btnChangePW.onClick.RemoveAllListeners();
    }







}
