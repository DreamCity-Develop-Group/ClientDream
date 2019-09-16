
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 11:08:28
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

public class VoicePanel : UIBase
{
    Button btnGameMusic;
    Button btnBgMusic;

    bool isGameMusic;
    bool isBgMusic;
    private void Awake()
    {
        Bind(UIEvent.VOICE_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.VOICE_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        btnBgMusic = transform.Find("BtnBgMusic").GetComponent<Button>();
        btnGameMusic = transform.Find("BtnGameMusic").GetComponent<Button>();

        btnGameMusic.onClick.AddListener(clickGameMusic);
        btnBgMusic.onClick.AddListener(clickBgMusic);
    }

    private void clickBgMusic()
    {
        
        if (!PlayerPrefs.HasKey("BGMUSIC")|| PlayerPrefs.GetString("BGMUSIC")=="TRUE")
        {
            PlayerPrefs.SetString("BGMUSIC", "FALSE");
            //TODO
        }
        else
        {
            PlayerPrefs.SetString("BGMUSIC", "TRUE");
            //TODO
        }
    }

    private void clickGameMusic()
    {
        if (!PlayerPrefs.HasKey("GAMEMUSIC") || PlayerPrefs.GetString("GAMEMUSIC") == "TRUE")
        {
            PlayerPrefs.SetString("GAMEMUSIC", "FALSE");
            //TODO
        }
        else
        {
            PlayerPrefs.SetString("GAMEMUSIC", "TRUE");
            //TODO
        }
    }
}
