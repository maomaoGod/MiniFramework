using UnityEngine;
using MiniFramework;
using System;
using ProtoBuf;

public class SerializeExample : MonoBehaviour {
    // Use this for initialization
    void Start() {
        SerializeClass bc = new SerializeClass() { age = 18, name = "ss", isBoy = true };
        SerializeUtil.SerializeBinary(Application.streamingAssetsPath + "/Binary", bc);
        SerializeClass bc2 = (SerializeClass)SerializeUtil.DeserializeBinary(Application.streamingAssetsPath + "/Binary");
        Debug.Log(bc2.age + ":" + bc2.name + ":" + bc2.isBoy);
        SerializeUtil.SerializeXML(Application.streamingAssetsPath + "/XML", bc);
        bc2 = (SerializeClass)SerializeUtil.DeserializeXML<SerializeClass>(Application.streamingAssetsPath + "/XML");
        Debug.Log(bc2.age + ":" + bc2.name + ":" + bc2.isBoy);

        JsonClass jc = new JsonClass() { age = 20, name = "xx", isBoy = false };
        string res  = SerializeUtil.SerializeJson(jc);
        Debug.Log(res);
        jc = (JsonClass)SerializeUtil.DeserializeJson<JsonClass>(res);
        Debug.Log(jc.age + ":" + jc.name + ":" + jc.isBoy);

        ProtoBuffClass pb = new ProtoBuffClass() { age = 19, name = "xxxx", isBoy = false };
        byte[] bytes = pb.ToProtoBuff<ProtoBuffClass>();
        pb = bytes.FromProtoBuff<ProtoBuffClass>();
        Debug.Log(pb.age + ":" + pb.name + ":" + pb.isBoy);
    }	
}
[Serializable]
public class SerializeClass
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}


public class JsonClass
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}
[ProtoContract]
public class ProtoBuffClass
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}
