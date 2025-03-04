using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using UnityEditor;
using UnityEngine;
using Util;
namespace Editor
{
    /****************************************************
    文件：SeleExcel.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：将Excel表格转换为二进制文件
*****************************************************/


    public static class ExcelToBinary
    {
        [MenuItem("Tools/将Excel表格转换为二进制文件")]
        public static void ExcuteExcelToBinary()
        {
            // 确保输出目录存在
            if (!Directory.Exists(PathUtil.ExcelToBinary))
            {
                Directory.CreateDirectory(PathUtil.ExcelToBinary);
            }

            //获取所有Excel文件的路径
            string[] excelFilePaths = Directory.GetFiles(PathUtil.ExcelPath, "*.xlsx");
            // 创建一个新的Excel包
            foreach (string filePath in excelFilePaths)
            {
                // 跳过临时文件
                if (filePath.StartsWith("~$")) continue;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    ExcelPackage package = new ExcelPackage(file);
                    if (package.Workbook.Worksheets.Count <= 0)
                    {
                        Debug.LogError("Excel文件中没有工作表！");
                    }
                    else
                    {
                        LocalizedlanguageList localizedlanguageList = new LocalizedlanguageList();
                        // 获取第一个工作表
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                        for (int i = 2; i <= worksheet.Dimension.Rows; i++)
                        {
                            Localizedlanguage localizedlanguage = new Localizedlanguage
                            {
                                Key = worksheet.Cells[i, 1].Value.ToString(),
                                Chinese = worksheet.Cells[i, 2].Value.ToString(),
                                English = worksheet.Cells[i, 3].Value.ToString()
                            };
                           
                            localizedlanguageList.languages.Add(localizedlanguage);
                        }
                        SerializationUtil.ConvertExcelToBinary(filePath, localizedlanguageList);
                    }
                    
                }
            }

            AssetDatabase.Refresh();
            Debug.Log($"转换完成，共处理{excelFilePaths.Length}个文件");
        }

        
    }
    
}
