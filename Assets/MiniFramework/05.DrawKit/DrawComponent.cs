using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type
{
    扇形,
    圆形,
    矩形,
}
public class DrawComponent : MonoBehaviour {
    public Type Type;
    public List<Pattern> Patterns;
    public int xx;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[Serializable]
public class Pattern
{
    public Type Type;
    public Vector3 Angle;
    public Vector3 Radius;
    public Vector3 Length;
    public Vector3 Width;
}
