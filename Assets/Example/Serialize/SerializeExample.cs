using UnityEngine;
using MiniFramework;
using System;
using ProtoBuf;

public class SerializeExample : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        BinaryClass bc = new BinaryClass() { age = 18, name = "ss", isBoy = true };
        bc.Serialize(Application.streamingAssetsPath + "/Binary");
        string path = Application.streamingAssetsPath + "/Binary";
        bc = path.DeserializeFromBinary<BinaryClass>();

        XMLClass xc = new XMLClass() { age = 18, name = "ss", isBoy = true };
        xc.Serialize(Application.streamingAssetsPath + "/XML");
        string path2 = Application.streamingAssetsPath + "/XML";
        xc = path2.DeserializeFromXML<XMLClass>();

        JsonClass jc = new JsonClass() { age = 20, name = "xx", isBoy = false };
        string json = jc.Serialize();
        jc = json.DeserializeFromJson<JsonClass>();

        ProtoBuffClass pb = new ProtoBuffClass() { age = 19, name = "xxxx", isBoy = false };
        byte[] bytes = pb.Serialize();
        pb = bytes.DeserializeFromProtoBuff<ProtoBuffClass>();
    }
}
[Serializable]
public class BinaryClass : Binary
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}
[Serializable]
public class XMLClass : XML
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}

public class JsonClass:Json
{
    public int age { get; set; }
    public string name { get; set; }
    public bool isBoy { get; set; }
}

[ProtoContract]
public class ProtoBuffClass:ProtoBuff
{
    [ProtoMember(1)]
    public int age { get; set; }
    [ProtoMember(2)]
    public string name { get; set; }
    [ProtoMember(3)]
    public bool isBoy { get; set; }
}
