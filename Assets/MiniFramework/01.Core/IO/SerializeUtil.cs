using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace MiniFramework
{
    public static class SerializeUtil
    {
        public static bool SerializeBinary(string path, object obj)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.Exception("路径不能为空！");
            }
            if (obj == null)
            {
                throw new System.Exception("序列化对象不能为空");
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
                return true;
            }
        }
        public static object DeserializeBinary(string path)
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
                BinaryFormatter bf = new BinaryFormatter();
                object data = bf.Deserialize(fs);
                return data;
            }
        }
        public static bool SerializeXML(string path, object obj)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.Exception("路径不能为空！");
            }
            if (obj == null)
            {
                throw new System.Exception("序列化对象不能为空");
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                xml.Serialize(fs, obj);
                return true;
            }
        }
        public static object DeserializeXML<T>(string path)
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
                return data;
            }
        }
        public static string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static object DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static byte[] ToProtoBuff<T>(this T obj)where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<T>(ms, obj);
                return ms.ToArray();
            }
        }
        public static T FromProtoBuff<T>(this byte[] bytes) where T : class
        {
            if (bytes == null || bytes.Length == 0)
            {
                throw new System.ArgumentNullException("bytes");
            }
            T t = ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(bytes));
            return t;
        }
    }
}
