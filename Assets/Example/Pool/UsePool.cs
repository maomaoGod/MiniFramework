using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class UsePool : MonoBehaviour {
    public GameObject Prefab;
	// Use this for initialization
	void Start () {
        ObjectPool.Instance.Init(Prefab, 10);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ObjectPool.Instance.Allocate("Cube");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(ObjectPool.Instance.CurCount("Cube"));
        }
    }
}
