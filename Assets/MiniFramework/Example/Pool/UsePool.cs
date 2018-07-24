using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class UsePool : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PoolManager.Instance.Allocate("Cube");
        }
	}
}
