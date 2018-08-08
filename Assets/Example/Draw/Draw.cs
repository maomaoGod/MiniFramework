using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class Draw : MonoBehaviour
{
    void Start()
    {
        DrawUtil.Circle(transform, 5);
        DrawUtil.Rectangle(transform, 5, 5);
        DrawUtil.Sector(transform, 60, 5);
    }
    private void OnDrawGizmos()
    {
        DrawUtil.SectorOnGizmos(transform, 60, 5);
        DrawUtil.RectangleOnGizmos(transform, 5,5);
        DrawUtil.CircleOnGizmos(transform, 5);
    }
}
