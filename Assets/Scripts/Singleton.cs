using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/****************************************************
    文件：Singleton.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：单例基类
*****************************************************/
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
       private static T instance;

       public static T Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = FindObjectOfType<T>();
                   if (instance == null)
                   {
                       GameObject obj = new GameObject(typeof(T).Name);
                       instance = obj.AddComponent<T>();
                   } 
               }

               return instance;
           }
       }
}
