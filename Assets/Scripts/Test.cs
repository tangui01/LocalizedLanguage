using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Util;
/****************************************************
    文件：Test.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/
public class Test : MonoBehaviour
{
     public Dropdown dropdown;

     private void Awake()
     {
         dropdown=GetComponent<Dropdown>();
         dropdown.onValueChanged.AddListener(x =>
         {
            LanguageManager.Instance.ChangeLanguage((LanguageType)x);
         });
     }
}
