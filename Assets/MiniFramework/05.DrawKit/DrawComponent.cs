using MiniFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniFramework
{
    public enum PatternType
    {
        扇形,
        圆形,
        矩形,
    }
    public class DrawComponent : MonoBehaviour
    {
        public List<Pattern> Patterns;
        public Color Color = Color.black;
        // Use this for initialization
        private void Start()
        {
            for (int i = 0; i < Patterns.Count; i++)
            {
                switch (Patterns[i].Type)
                {
                    case PatternType.圆形:
                        if (Patterns[i].CreateMesh)
                        {
                            DrawUtil.Circle(transform, Patterns[i].Radius,Color);
                        }
                        break;
                    case PatternType.扇形:
                        if (Patterns[i].CreateMesh)
                        {
                            DrawUtil.Sector(transform, Patterns[i].Angle, Patterns[i].Radius,Color);
                        }
                        break;
                    case PatternType.矩形:
                        if (Patterns[i].CreateMesh)
                        {
                            DrawUtil.Rectangle(transform, Patterns[i].Length,Patterns[i].Width,Color);
                        }
                        break;
                }
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            for (int i = 0; i < Patterns.Count; i++)
            {
                switch (Patterns[i].Type)
                {
                    case PatternType.圆形:
                        DrawUtil.CircleOnGizmos(transform, Patterns[i].Radius);
                        break;
                    case PatternType.扇形:
                        DrawUtil.SectorOnGizmos(transform, Patterns[i].Angle, Patterns[i].Radius);
                        break;
                    case PatternType.矩形:
                        DrawUtil.RectangleOnGizmos(transform, Patterns[i].Length, Patterns[i].Width);
                        break;
                }
            }
        }
    }
    [Serializable]
    public class Pattern
    {
        [Header("图形")]
        public PatternType Type;
        [Range(0, 360)]
        public float Angle;
        public float Radius;
        public float Length;
        public float Width;
        public bool CreateMesh;
    }
}
