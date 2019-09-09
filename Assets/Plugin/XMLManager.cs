
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
/// <summary>
/// 多个XML加载管理器
/// 当一个场景或一个项目有多个XML要加的时候
/// 为了不一个一个的加载，可以使用一个XML加载管理器
/// 来进行XML的加载操作，加载完以后，全部保存在管理器中，
/// 用的时候，通过XML的文件名来取出指定的XML就可以了
/// </summary>
public class XMLManager
{
    //Weapon.xml,MainSene.xml
    //Assets\myFile\Weapon.xml
    private static bool isSave = true;//要不要保存加载过的XML
    //用来保存所有加载的XML
    private static Dictionary<string, XmlElement> dict = new Dictionary<string, XmlElement>();
    /// <summary>
    /// 加载所有的指定的XML，每次加载的时候，把XML的文件名取出来判断一下该XML是
    /// 否被加载过，如果加载过，就什么都不做了，如果没有加载过，就重新加载。
    /// </summary>
    /// <param name="path">路径</param>
    public static void LoadXML(string path,bool _isSavae=true)
    {
        //这里面主要是得到XML的文件名，然后进行判断是否要加载，
        //如果要加载，那么就调用下面的Load方法进行加载
        int end = path.LastIndexOf(".");
        int start = path.LastIndexOf("/");
        int len = end - start - 1;
        string name = path.Substring(start + 1, len);
        if (dict.ContainsKey(name)) return;
        isSave = _isSavae;//true,false
        //UnityEngine.Debug.Log("xmlLoad Complete: " + name);
        Load(name, path);
    }
    public static void LoadXML(string xmlStr,string name, bool _isSavae = true)
    {
        if (dict.ContainsKey(name)) return;
        isSave = _isSavae;//true,false
        LoadXMLStr(xmlStr, name);
    }
    /// <summary>
    /// 开始加载XML，加载完以后，把XML的根节点做为值，XML文件名做为键
    /// 保存在字典里
    /// </summary>
    /// <param name="name">XML文件名</param>
    /// <param name="path">要加载的路径</param>
    private static void Load(string name,string path)
    {
        XmlDocument d = new XmlDocument();
        d.Load(path);
        XmlElement root = d.DocumentElement;
        dict.Add(name, root);
        UnityEngine.Debug.Log("xml: " + name + " 加载成功");
     }
    private static void LoadXMLStr(string xmlStr,string name)
    {
        XmlDocument d = new XmlDocument();
        d.LoadXml(xmlStr);
        XmlElement root = d.DocumentElement;
        dict.Add(name, root);
        UnityEngine.Debug.Log("xml: " + name + " 加载成功");
    }
    /// <summary>
    /// 根据指定的XML文件名来取出已经被加载好的XML，
    /// 取出的是XML的根节点，开发者，只要得到根节点，就可以根据
    /// 根节点取出所有想要的任何子节点
    /// 
    /// 前提是要把所有XML先加载好
    /// </summary>
    /// <param name="filename">文件名</param>
    /// <returns>返回指定的根节点</returns>
    public static XmlElement GetXMLRoot(string filename)
    {
        if (dict.ContainsKey(filename))
        {
            //如果不保存，则只能取一次，便删除
            if (!isSave)//isSave=true
            {
                XmlElement root = dict[filename];
                dict.Remove(filename);
                return root;
            }
            return dict[filename];
        }
        return null;
    }
}

