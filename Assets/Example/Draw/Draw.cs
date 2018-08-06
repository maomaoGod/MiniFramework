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
         Gizmos.color = Color.red;
         DrawUtil.Sector(transform, Angle, Radius);
        // DrawUtil.Circle2D(transform.position,Radius);
    }
}
