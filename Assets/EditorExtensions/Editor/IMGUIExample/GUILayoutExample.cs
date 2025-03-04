using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GUILayout = UnityEngine.GUILayout;

/****************************************************
    文件：GUILayoutExample.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/
public class GUILayoutExample : EditorWindow
{
    [MenuItem("EditorExtensions/02-IMGUI/01-GUILayoutExample")]
    static void OpenGUILayoutExample()
    {
        GetWindow<GUILayoutExample>().Show();
    }

    public enum MyEnum
    {
        Base,
        Enabled,
        Other,
        SelectColor,
    }
    private MyEnum enumValue;
    private bool IsEnabled;
    private bool IsselectColor;
    private void OnGUI()
    {
        enumValue = (MyEnum)GUILayout.Toolbar((int)enumValue, new string[]{ "Base", "Enabled","Other","SelectColor" });
        switch (enumValue)
        {
            case MyEnum.Base:
                Base();
                break;
            case MyEnum.Other:
                break;
            case MyEnum.Enabled:
                SetEnabled();
                Base();
                break;
            case MyEnum.SelectColor:
                IsselectColor= GUILayout.Toggle(IsselectColor,"SelectColor");
                if (IsselectColor)
                {
                    GUI.color = Color.cyan; 
                }
                else
                {
                    GUI.color = Color.white;
                }
                Base();
                break;
        }
    }

    private void SetEnabled()
    {
        IsEnabled= GUILayout.Toggle(IsEnabled,"是否可以交互");
        GUI.enabled = IsEnabled;
    }

    private void SetColor()
    {
        
    }

    #region Base
    private string MTextFileldText ="" ;
    private string MTextAreaText ="" ;
    private string MPasswordText ="" ;
    
    private Vector2 MScrollPosition ;


    private float HorizontalSliderValue;
    private float VerticalSliderValue;
    
    private int ToolbarSelected = 0;
    private bool ToggleSelected ;

    private int id;
    private int SelectionGrid;
    public void Base()
    {
         GUILayout.Label("文本 :hello IMGUI");
        MScrollPosition = GUILayout.BeginScrollView(MScrollPosition);
        {
            GUILayout.BeginVertical("UI", style: "box");
            {
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("文本输入框 : TextField");
                    MTextFileldText = GUILayout.TextField(MTextFileldText);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("文本区域 : TextArea");
                    MTextAreaText = GUILayout.TextArea(MTextAreaText);
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("密码输入框 : PasswordField");
                    MPasswordText = GUILayout.PasswordField(MPasswordText, '*');
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("按钮 : Button");
                    if (GUILayout.Button("打开bilibili"))
                    {
                        EditorApplication.ExecuteMenuItem("EditorExtensions/01-Munu/02-OpenBillbilli");
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("按钮 : RepeatButton");
                    if (GUILayout.RepeatButton("输出时间"))
                    {
                        Debug.Log(System.DateTime.Now.ToString());
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Label("Box");
            GUILayout.Box("Autolayout Box");
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("HorizontalSliderValue");
                GUILayout.Space(200);
                HorizontalSliderValue=GUILayout.HorizontalSlider(HorizontalSliderValue,0,1);
                GUILayout.Label(HorizontalSliderValue.ToString("F2"));
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("VerticalSliderValue");
                VerticalSliderValue=GUILayout.VerticalSlider(VerticalSliderValue,0,100);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.Label("Toolbar");
            ToolbarSelected=GUILayout.Toolbar(ToolbarSelected,new string[]
            {
                "1",
                "2",
                "3"
            });


            ToggleSelected= GUILayout.Toggle(ToggleSelected,"Mute");
            
            
            GUILayout.BeginArea(new Rect(0,0,400,400));
            {
                GUILayout.Label("dsadsasdsadsadsd撒旦撒撒大苏打实打实");
            }
            GUILayout.EndArea();

            GUILayout.Window(id,new Rect(new Vector2(0,1000),new Vector2(100,100)),(id)=>{
                    Debug.Log(id);
                }, "4"
                );


            SelectionGrid=  GUILayout.SelectionGrid(SelectionGrid,new string[]
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
            },2);


        }
        GUILayout.EndScrollView();
    }


    #endregion
}
