using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/***
  * Title:     
  *
  * Created:	#AuthorName#
  *
  * CreatTime:  #CreateTime#
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
public class Copyright : UnityEditor.AssetModificationProcessor
{
    private const string AuthorName = "zp";

    private const string DateFormat = "yyyy/MM/dd HH:mm:ss";
    private static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs"))
        {
            string allText = File.ReadAllText(path);
            allText = allText.Replace("#AuthorName#", AuthorName);
            allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(DateFormat));
            File.WriteAllText(path, allText);
            UnityEditor.AssetDatabase.Refresh();
        }

    }
}