using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
using System;

public class XmlExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        A xml = new A();
        B b = new B() { b=222,a=new bool[] {false,true } };
        
        xml.a = 111;
        xml.b = "xxx";
        xml.c = new float[] { 0.1f, 0.2f };
        xml.blist = new List<B>();
        xml.blist.Add(b);
        if (SerializeUtil.SerializeToXml(xml, Application.streamingAssetsPath + "/A"))
        {
            Debug.Log("序列化成功");
        }
        xml = SerializeUtil.DeserializeFromXML<A>(Application.streamingAssetsPath + "/A");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[Serializable]
public class A
{
    public int a { get; set; }
    public string b { get; set; }
    public float[] c { get; set; }
    public List<B> blist;
}
[Serializable]
public class B
{
    public int b { get; set; }
    public bool[] a { get; set; }
}
