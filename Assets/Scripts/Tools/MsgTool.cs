using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public static class MsgTool 
{

    /// <summary>   
    /// MD5加密   
    /// </summary>   
    /// <param name="strSource">需要加密的字符串</param>   
    /// <returns>MD5加密后的字符串</returns>   
    public static string Md5Encrypt(string strSource)
    {
        //把字符串放到byte数组中   
        byte[] bytIn = System.Text.Encoding.Default.GetBytes(strSource);
        //建立加密对象的密钥和偏移量           
        byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量   
        byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥   
                                                          //实例DES加密类   
        DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
        mobjCryptoService.Key = iv;
        mobjCryptoService.IV = key;
        ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
        //实例MemoryStream流加密密文件   
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
        cs.Write(bytIn, 0, bytIn.Length);
        cs.FlushFinalBlock();

        string strOut = System.Convert.ToBase64String(ms.ToArray());
        return strOut;
    }

    /// <summary>
    /// 用MD5加密字符串，可选择生成16位或者32位的加密字符串
    /// </summary>
    /// <param name="password">待加密的字符串</param>
    /// <param name="bit">位数，一般取值16 或 32</param>
    /// <returns>返回的加密后的字符串</returns>
    public static string MD5Encrypt(string password, int bit)
    {
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        byte[] hashedDataBytes;
        hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
        StringBuilder tmp = new StringBuilder();
        foreach (byte i in hashedDataBytes)
        {
            tmp.Append(i.ToString("x2"));
        }
        if (bit == 16)
            return tmp.ToString().Substring(8, 16);
        else
        if (bit == 32) return tmp.ToString();//默认情况
        else return string.Empty;
    }
    /// <summary>
    /// 用MD5加密字符串
    /// </summary>
    /// <param name="password">待加密的字符串</param>
    /// <returns></returns>
    public static string MD5Encrypt(string password)
    {
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        byte[] hashedDataBytes;
        hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
        StringBuilder tmp = new StringBuilder();
        foreach (byte i in hashedDataBytes)
        {
            tmp.Append(i.ToString("x2"));
        }
        return tmp.ToString();
    }
    /// <summary>
    /// 匹配手机格式
    /// </summary>
    /// <param name="mobile"></param>
    /// <returns></returns>
    public static bool CheckMobile(string mobile)
    {
        Regex regex = new Regex(@"^[1][3-8]\d{9}$");
        return regex.IsMatch(mobile);
    }
    /// <summary>
    /// 匹配密码格式
    /// </summary>
    /// <param name="pw"></param>
    /// <returns></returns>
    public static bool CheckPass(string pw)
    {
        Regex regex = new Regex(@"^[0-9a-zA-Z_]{8,16}$");
        return regex.IsMatch(pw);
    }
    /// <summary>
    /// 匹配昵称格式
    /// </summary>
    /// <param name="mobile"></param>
    /// <returns></returns>
    public static bool CheckNickName(string nick)
    {
        Regex regex = new Regex(@"^[\u4e00-\u9fa50-9a-zA-Z_]{2,10}$");
        return regex.IsMatch(nick);
    }
    /// <summary>
    /// 生成二维码
    /// </summary>
    /// <param name="textForEncoding"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width,
                Margin = 2,
                PureBarcode = true
            }
        };
        return writer.Write(textForEncoding);
    }

    //void DoPicture()//存储为png
    //{

    //    if (!File.Exists(filespath))//首先判断一下该图片文件是否存在
    //    {
    //        if (!Directory.Exists(folderpath))//再判断一下该文件夹是否存在，若不存在先创建
    //        {
    //            Directory.CreateDirectory(folderpath);//创建目录
    //        }
    //        var bys = encoded.EncodeToPNG();//转换图片资源
    //        File.WriteAllBytes(filespath, bys);//保存图片到写好的目录下
    //    }
    //}

}
