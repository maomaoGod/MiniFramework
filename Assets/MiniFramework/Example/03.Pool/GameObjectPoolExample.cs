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
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象："+PoolManager.Instance.CurCount("Cube"));
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + PoolManager.Instance.CurCount("Cube"));
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + PoolManager.Instance.CurCount("Cube"));
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + PoolManager.Instance.CurCount("Cube"));
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + PoolManager.Instance.CurCount("Cube"));
        PoolManager.Instance.Allocate("Cube");
        Debug.Log("剩余对象：" + PoolManager.Instance.CurCount("Cube"));
    }
    private void OnDisable()
    {

    }
}
