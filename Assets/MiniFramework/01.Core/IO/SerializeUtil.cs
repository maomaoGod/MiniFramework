using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace MiniFramework
{
    public interface Binary { }
    public interface XML { }
    public interface Json { }
    public interface ProtoBuff { }
    public static class SerializeUtil
    {
        public static bool Serialize(this Binary obj, string path)
        {
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
        public static T DeserializeFromBinary<T>(this string path)where T:Binary
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                throw new System.Exception("路径不存在！");
            }
            using (FileStream fs = fileInfo.OpenRead())
            {
                BinaryFormatter bf = new BinaryFormatter();
                object data =bf.Deserialize(fs);
                return (T)data;
            }
        }

        public static bool Serialize(this XML obj,string path)
        {
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
        public static T DeserializeFromXML<T>(this string path)where T:XML
        {
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
        public static string Serialize(this Json obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T DeserializeFromJson<T>(this string json)where T :Json
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static byte[] Serialize(this ProtoBuff obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static T DeserializeFromProtoBuff<T>(this byte[] bytes)where T:ProtoBuff
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
