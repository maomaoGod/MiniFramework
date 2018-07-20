using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class GameObjectPoolExample : MonoBehaviour {
    GameObject obj;
	// Use this for initialization
	void Start () {
        
	}

    private void OnEnable()
    {
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象："+GameObjectPool.Instance.CurCount("Cube"));
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + GameObjectPool.Instance.CurCount("Cube"));
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + GameObjectPool.Instance.CurCount("Cube"));
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + GameObjectPool.Instance.CurCount("Cube"));
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + GameObjectPool.Instance.CurCount("Cube"));
        GameObjectPool.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + GameObjectPool.Instance.CurCount("Cube"));
    }
    private void OnDisable()
    {

    }
}
