using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using UnityEngine;

/****************************************************
    文件：SerializationUtil.cs
    作者：tg
    邮箱: 18178367954@139.com
    日期：#CreateTime#
    功能：序列化工具
*****************************************************/
namespace Util
{
    public static class SerializationUtil
    {
        /// <summary>
        /// 将Excel数据转换为二进制文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void ConvertExcelToBinary<T>(string filePath, T t)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string outputPath = Path.Combine(PathUtil.ExcelToBinary, $"{fileName}.bytes");


            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, t);
            }
        }

        /// <summary>
        /// 将二进制文件转换为相应的类型数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T BinaryToData<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(fs);
            }
        }
    }
}