using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.developerConsoleVisible = false;
        Debug.Log("Log");
        Debug.LogError("LogError");
        Debug.LogWarning("LogWarning");
        Debug.LogAssertion("LogAssertion");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
