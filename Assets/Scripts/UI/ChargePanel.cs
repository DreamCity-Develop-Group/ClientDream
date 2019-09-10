
/***
  * Title:    ChargePanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 11:58:34
  *
  * Description: 资产界面
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargePanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.CHARGE_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.CHARGE_PANEL_ACTIVE:
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
    }

    Button btnClose;

    private void Start()
    {
        btnClose = transform.Find("BtnClose").GetComponent<Button>();




        btnClose.onClick.AddListener(clickClose);
        setPanelActive(false);
    }


    private void clickClose()
    {
        setPanelActive(false);
    }
}
