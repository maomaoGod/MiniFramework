using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class Draw : MonoBehaviour {
    public int Angle;
    public int Radius;
    void Start()
    {
        Debug.Log(transform.forward);
    }
    private void OnDrawGizmos()
    {
        DrawUtil.Sector(transform.position,Angle,Radius);
    }
}
