﻿using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace MiniFramework
{
    public class SerializeUtil
    {
        public static bool SerializeToBinary(object obj, string path)
        {
            if (obj == null)
            {
                throw new System.Exception("obj不能为空！");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new System.Exception("路径不能为空！");
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
                return true;
            }
        }
        public static T DeserializeFromBinary<T>(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                throw new System.Exception("路径不存在！");
            }
            using (FileStream fs = fileInfo.OpenRead())
            {
                BinaryFormatter bf = new BinaryFormatter();
                object data = bf.Deserialize(fs);
                return (T)data;
            }
        }

        public static bool SerializeToXml(object obj,string path)
        {
            if (obj == null)
            {
                throw new System.Exception("obj不能为空！");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new System.Exception("路径不能为空！");
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                xml.Serialize(fs, obj);
                return true;
            }
        }
        public static T DeserializeFromXML<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.Exception("路径不能为空！");
            }
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                throw new System.Exception("路径不存在！");
            }
            using (FileStream fs = fileInfo.OpenRead())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                object data = xml.Deserialize(fs);
                return (T)data;
            }
        }
        public static string SerializeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T DeserializeFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static byte[] SerializeToProtoBuff(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static T DeserializeFromProtoBuff<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                throw new System.ArgumentNullException("bytes");
            }
            return ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(bytes));
        }
    }
}
