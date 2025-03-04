using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/****************************************************
    文件：EventManger.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：事件处理中心
*****************************************************/

/// <summary>
/// 事件类型枚举示例
/// </summary>
public enum EventType
{
    OnLanguageChanged,
    OnPlayerDeath,
    OnScoreUpdate,
    OnSceneLoaded
}



public class EventManger : Singleton<EventManger>
{
    // 使用字典存储事件类型和对应的委托列表
    private Dictionary<EventType, Action<object[]>> eventDictionary = new Dictionary<EventType, Action<object[]>>();

    // 添加事件监听
    public void AddListener(EventType eventType, Action<object[]> listener)
    {
        if (eventDictionary.TryGetValue(eventType, out Action<object[]> thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventType] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventType, thisEvent);
        }
    }
    // 移除事件监听
    public void RemoveListener(EventType eventType, Action<object[]> listener)
    {
        if (eventDictionary.TryGetValue(eventType, out Action<object[]> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventType] = thisEvent;
        }
    }
    // 触发事件
    public void TriggerEvent(EventType eventType, params object[] args)
    {
        if (eventDictionary.TryGetValue(eventType, out Action<object[]> thisEvent))
        {
            thisEvent?.Invoke(args);
        }
    }

    // 清空所有事件监听
    public void ClearAllEvents()
    {
        eventDictionary.Clear();
    }

    // 清空指定类型事件
    public void ClearEvent(EventType eventType)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary.Remove(eventType);
        }
    }

    private void OnDestroy()
    {
        ClearAllEvents();
    }
}
