using MiniFramework;
using UnityEngine;
public class DebugTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Console.Instance();
        InvokeRepeating("Test", 0f, 1f);
    }	
	// Update is called once per frame
	void Test () {
        Debug.Log("xxxx");
    }
}
