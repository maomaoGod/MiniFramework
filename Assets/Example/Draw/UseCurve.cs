using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class UseCurve : MonoBehaviour {
    public Vector3 StartPos;
    public Vector3 EndPos;
    public Vector3 ControlPos;
    public Vector3 ControlPos2;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 100; i++)
        {
            Vector3 p = BezierUtil.Curve(i * 0.01f, StartPos, EndPos, ControlPos,ControlPos2);
            Vector3 p2 = BezierUtil.Curve((i+1) * 0.01f, StartPos, EndPos, ControlPos, ControlPos2);
            Debug.DrawLine(p, p2, Color.white);
        }
    }
}
