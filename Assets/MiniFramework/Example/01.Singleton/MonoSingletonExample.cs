using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class MonoSingletonExample : MonoSingleton<MonoSingletonExample> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnSingletonInit()
    {
        Debug.Log(gameObject.name+"初始化");
    }
    public void Test()
    {

    }
}
