using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

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

}
