using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/****************************************************
    文件：MenuLtemExample.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/
namespace EditorExtensions
{
    public static class MenuItemExample 
    {
        [MenuItem("EditorExtensions/01-Munu/01-HelloEditor")]
        static void HelloEditor()
        {
            Debug.Log("HelloEditor");
        }
        //打开目标网址
        [MenuItem("EditorExtensions/01-Munu/02-OpenBillbilli")]
        static void OpenBillbilli()
        {
            Application.OpenURL("https://www.bilibili.com/");
        }
        //打开目标目录
        [MenuItem("EditorExtensions/01-Munu/03-OpenLibrary")]
        static void OpenLibrary()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }
        //可以被勾选的menuitem
        private static bool munuSelected = false;
        [MenuItem("EditorExtensions/01-Munu/04-快捷键开关")]
        static void TogleShotCut()
        {
             munuSelected = !munuSelected;
             Menu.SetChecked("EditorExtensions/01-Munu/04-快捷键开关", munuSelected);
        }
        //快捷键的HelloEditor
        [MenuItem("EditorExtensions/01-Munu/05-快捷键的HelloEditor _c")]
        static void HelloEditorWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01-Munu/01-HelloEditor");
        }
        //快捷键的打开目标网址 (%是Ctrl #是Shift &是Alt)
        [MenuItem("EditorExtensions/01-Munu/06-快捷键的OpenBillbilli %e")]
        static void OpenBillbilliWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01-Munu/02-OpenBillbilli");
        }
        //打开目标目录快捷键
        [MenuItem("EditorExtensions/01-Munu/07-快捷键的OpenLibrary  %#e")]
        static void OpenLibraryWithShotCut()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }
        //快捷键的HelloEditor
        [MenuItem("EditorExtensions/01-Munu/05-快捷键的HelloEditor _c",validate = true)]
        static bool HelloEditorWithShotCutISActive()
        {
            return munuSelected;
        }
        //快捷键的打开目标网址 (%是Ctrl #是Shift &是Alt)
        [MenuItem("EditorExtensions/01-Munu/06-快捷键的OpenBillbilli %e",validate = true)]
        static bool OpenBillbilliWithShotCutISActive()
        {
            return munuSelected;
        }
        //打开目标目录快捷键
        [MenuItem("EditorExtensions/01-Munu/07-快捷键的OpenLibrary  %#e",validate=true)]
        static bool OpenLibraryWithShotCutISActive()
        {
            return munuSelected;
        }

        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01-Munu/04-快捷键开关", munuSelected);
        }
    }
}

