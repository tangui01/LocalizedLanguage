using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

/****************************************************
    文件：LanguageManager.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：本地化语言管理器
*****************************************************/
public enum LanguageType
{
    Chinese,
    English
}
[System.Serializable]
public class LocalizedlanguageList
{
    public List<Localizedlanguage> languages = new List<Localizedlanguage>();
}

[System.Serializable]
public class Localizedlanguage
{
    public string Key;
    public string Chinese;
    public string English;
}
public class LanguageManager : Singleton<LanguageManager>
{
    //选择自已需要的本地语言  
    [SerializeField]private LanguageType mLanguage ;
     private readonly Dictionary<string, Localizedlanguage> _mLanguagesDic = new Dictionary<string, Localizedlanguage>();

     private void LanguageInit()
     {
         LocalizedlanguageList list=  SerializationUtil.BinaryToData<LocalizedlanguageList>(PathUtil.ExcelToBinary+PathUtil.LocalizedlanguageName);
         foreach (var item in list.languages)
         {
             _mLanguagesDic.Add(item.Key, item);
         }
     }

     public string GetString(string key)
     {
         if (!_mLanguagesDic.ContainsKey(key))
         {
             Debug.LogError(string.Format("Language {0} is missing", key));
             return string.Empty;
         }
         else
         {
             if (mLanguage == LanguageType.Chinese)
             {
                 return _mLanguagesDic[key].Chinese;
             }
             else
             {
                 return _mLanguagesDic[key].English;
             }
         }
     }
// 切换语言
     public void ChangeLanguage(LanguageType lang)
     {
         mLanguage = lang;
         // 更新所有；Text
         EventManger.Instance.TriggerEvent(EventType.OnLanguageChanged, mLanguage);
     }
    
     private void Awake()
     {
         LanguageInit();
     }

     private void Start()
     {
         ChangeLanguage(LanguageType.Chinese);
     }
}
