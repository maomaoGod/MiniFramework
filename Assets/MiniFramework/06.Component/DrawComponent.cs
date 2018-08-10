using System;
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
        public List<PatternAttribute> Patterns;
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
                            DrawUtil.Circle(transform, Patterns[i].Radius, Patterns[i].Color);
                        }
                        break;
                    case PatternType.扇形:
                        if (Patterns[i].CreateMesh)
                        {
                            DrawUtil.Sector(transform, Patterns[i].Angle, Patterns[i].Radius, Patterns[i].Color);
                        }
                        break;
                    case PatternType.矩形:
                        if (Patterns[i].CreateMesh)
                        {
                            DrawUtil.Rectangle(transform, Patterns[i].Length,Patterns[i].Width, Patterns[i].Color);
                        }
                        break;
                }
            }
        }
        private void OnDrawGizmos()
        {
            for (int i = 0; i < Patterns.Count; i++)
            {
                switch (Patterns[i].Type)
                {
                    case PatternType.圆形:
                        DrawUtil.CircleOnGizmos(transform, Patterns[i].Radius,Patterns[i].Color);
                        break;
                    case PatternType.扇形:
                        DrawUtil.SectorOnGizmos(transform, Patterns[i].Angle, Patterns[i].Radius, Patterns[i].Color);
                        break;
                    case PatternType.矩形:
                        DrawUtil.RectangleOnGizmos(transform, Patterns[i].Length, Patterns[i].Width, Patterns[i].Color);
                        break;
                }
            }
        }
    }
    [Serializable]
    public class PatternAttribute
    {
        [Header("图形")]
        public PatternType Type;
        public Color Color = Color.black;
        [Range(0, 360)]
        public float Angle;
        public float Radius;
        public float Length;
        public float Width;
        public bool CreateMesh;
    }
}
