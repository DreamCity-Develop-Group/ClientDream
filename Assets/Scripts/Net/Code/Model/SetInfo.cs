
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 16:09:13
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

[System.Serializable]
public class SetInfo 
{

    public SetInfo()
    {

    }

    public SetInfo(string gameVoice, string bgVoice)
    {
        GameVoice = gameVoice;
        BgVoice = bgVoice;
    }

    public string GameVoice;//{ get => phone; set => phone = value; }
    public string BgVoice;// { get => password; set => password = value; }

}
