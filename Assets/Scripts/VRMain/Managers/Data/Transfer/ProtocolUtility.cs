using MessagePack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MRinVR.Data
{
    /// <summary>
    /// プロトコルに関する機能を提供します。
    /// </summary>
    public static partial class ProtocolUtility
    {
        /// <summary>
        /// プロトコルのデータからMessagePack形式のバイトデータを生成します。
        /// </summary>
        public static byte[] SerializeMessagePack<T>(T data)
        {
            return MessagePackSerializer.Serialize(data);
        }

        /// <summary>
        /// MessagePack形式のバイトデータからプロトコルのデータを生成します。
        /// </summary>
        public static T DeserializeMessagePack<T>(Stream data)
        {
            return MessagePackSerializer.Deserialize<T>(data);
        }

        /// <summary>
        /// MessagePack形式のバイトデータからプロトコルのデータを生成します。
        /// </summary>
        public static T DeserializeMessagePack<T>(byte[] data)
        {
            return MessagePackSerializer.Deserialize<T>(data);
        }

        /// <summary>
        /// プロトコルのデータからCSV形式の文字列を生成します。
        /// </summary>
        public static string SerializeCsv<T>(IEnumerable<T> datas, bool hasHeader = true)
        {
            var properties = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttributes<KeyAttribute>().Any())
                .OrderBy(x => x.GetCustomAttribute<KeyAttribute>().IntKey)
                .ToArray();
            using (var writer = new StringWriter())
            {
                if (hasHeader)
                {
                    for (var propertyIndex = 0; propertyIndex < properties.Count(); propertyIndex++)
                    {
                        if (propertyIndex > 0)
                        {
                            writer.Write(",");
                        }
                        writer.Write(properties[propertyIndex].Name);
                    }
                    writer.WriteLine();
                }

                for (var dataIndex = 0; dataIndex < datas.Count(); dataIndex++)
                {
                    if (dataIndex > 0)
                    {
                        writer.WriteLine();
                    }
                    for (var propertyIndex = 0; propertyIndex < properties.Count(); propertyIndex++)
                    {
                        if (propertyIndex > 0)
                        {
                            writer.Write(",");
                        }
                        var value = properties[propertyIndex].GetValue(datas.ElementAt(dataIndex));
                        writer.Write(value);
                    }
                }
                return writer.ToString();
            }
        }

        /// <summary>
        /// CSV形式の文字列からプロトコルのデータを生成します。
        /// </summary>
        public static IEnumerable<T> DeserializeCsv<T>(string csv, bool hasHeader = true)
        {
            var properties = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttributes<KeyAttribute>().Any())
                .OrderBy(x => x.GetCustomAttribute<KeyAttribute>().IntKey)
                .ToArray();
            using (var reader = new StringReader(csv))
            {
                var datas = new List<T>();
                if (hasHeader)
                {
                    reader.ReadLine();
                }
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length == 0) continue;

                    var data = Activator.CreateInstance<T>();
                    for (var valueIndex = 0; valueIndex < values.Length; valueIndex++)
                    {
                        if (valueIndex >= properties.Length)
                        {
                            break;
                        }
                        var value = Convert.ChangeType(values[valueIndex], properties[valueIndex].PropertyType);
                        properties[valueIndex].SetValue(data, value);
                    }
                    datas.Add(data);
                }
                return datas;
            }
        }

        /// <summary>
        /// データをJSONに変換します。
        /// </summary>
        public static string SerializeJson<T>(T data) where T : class
        {
            var json = null as string;
            try
            {
                if (data != null)
                {
                    json = JsonUtility.ToJson(data);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
            return json;
        }

        /// <summary>
        /// JSONをデータに変換します。
        /// </summary>
        public static T DeserializeJson<T>(string json) where T : class
        {
            var data = null as T;
            try
            {
                if (string.IsNullOrEmpty(json) == false)
                {
                    data = JsonUtility.FromJson<T>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
            return data;
        }
    }
}