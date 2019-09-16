
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 11:22:14
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgPanel : UIBase
{
    Button btnClose;
    private void Awake()
    {
        Bind(UIEvent.MSG_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.MSG_PANEL_ACTIVE:
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
    // Start is called before the first frame update
    void Start()
    {
        btnClose = transform.Find("BtnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(clickClose);
        setPanelActive(false);
    }
    private void clickClose()
    {
        setPanelActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
