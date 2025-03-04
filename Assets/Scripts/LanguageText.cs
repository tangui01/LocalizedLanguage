using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/****************************************************
    文件：LanguageText.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/
public class LanguageText : MonoBehaviour
{
    public string key = " ";
    private Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        EventManger.Instance.AddListener(EventType.OnLanguageChanged,
            args => { text.text = LanguageManager.Instance.GetString(key); });
    }
}