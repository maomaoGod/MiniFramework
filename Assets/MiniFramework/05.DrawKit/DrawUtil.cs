﻿using System.Collections.Generic;
using UnityEngine;
namespace MiniFramework
{
    public class DrawUtil
    {
        private static float factor = 100;
        /// <summary>
        /// 扇形
        /// </summary>
        /// <param name="target"></param>
        /// <param name="angle"></param>
        /// <param name="radius"></param>
        public static void SectorOnGizmos(Transform target, float angle, float radius,Color color)
        {
            Gizmos.color = color;
            float eachAngle = angle / factor;
            List<Vector3> points = new List<Vector3>();
            for (int i = 0; i <= factor; i++)
            {
                Vector3 point = Quaternion.AngleAxis(-angle / 2 + eachAngle * i, target.up) * target.forward * radius + target.position;
                points.Add(point);
            }
            for (int i = 0; i < points.Count-1; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
            Gizmos.DrawLine(target.position, points[0]);
            Gizmos.DrawLine(target.position, points[points.Count - 1]);          
        }
        public static void Sector(Transform target,float angle,float radius,Color color)
        {
            float eachAngle = angle / factor;
            List<Vector3> points = new List<Vector3>();
            points.Add(new Vector3(0,0,0));
            for (int i = 0; i <= factor; i++)
            {
                Vector3 point = Quaternion.AngleAxis(-angle / 2 + eachAngle * i, target.up) * target.forward * radius;
                points.Add(point);
            }
            CreateMesh(target, points,color);
        }
        /// <summary>
        /// 圆形
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void CircleOnGizmos(Transform target, float radius,Color color)
        {
            Gizmos.color = color;
            float eachAngle = 360f / factor;
            List<Vector3> points = new List<Vector3>();
            for (int i = 0; i <= factor; i++)
            {
                Vector3 point = Quaternion.AngleAxis(-180f + eachAngle * i, target.up) * target.forward * radius + target.position;
                points.Add(point);
            }
            for (int i = 0; i < points.Count - 1; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }
        public static void Circle(Transform target,float radius,Color color)
        {
            Sector(target, 360, radius,color);
        }
        /// <summary>
        /// 矩形
        /// </summary>
        /// <param name="target"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        public static void RectangleOnGizmos(Transform target, float length, float width,Color color)
        {
            Gizmos.color = color;
            Vector3 p0 = target.position - target.right * (width / 2);
            Vector3 p1 = target.position - target.right * (width / 2) + target.forward * length;
            Vector3 p2 = target.position + target.right * (width / 2) + target.forward * length;
            Vector3 p3 = target.position + target.right * (width / 2);
            Gizmos.DrawLine(p0, p1);
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawLine(p2, p3);
            Gizmos.DrawLine(p3, p0);          
        }
        public static void Rectangle(Transform target, float length, float width,Color color)
        {
            Vector3 p0 = -target.right * (width / 2);
            Vector3 p1 = -target.right * (width / 2) + target.forward * length;
            Vector3 p2 = target.right * (width / 2) + target.forward * length;
            Vector3 p3 = target.right * (width / 2);
            List<Vector3> vertices = new List<Vector3>();
            vertices.Add(p0);
            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
            CreateMesh(target, vertices,color);
        }
        static void CreateMesh(Transform parent, List<Vector3> vertices,Color color)
        {
            Mesh mesh = new Mesh();
            int triangleAmount = vertices.Count - 2;//三角形个数
            int[] triangles = new int[triangleAmount * 3];//三角形顶点顺序

            for (int i = 0; i < triangleAmount; i++)
            {
                triangles[3 * i] = 0;
                triangles[3 * i + 1] = i + 1;
                triangles[3 * i + 2] = i + 2;
            }
            GameObject obj = new GameObject("Mesh");
            obj.transform.SetParent(parent);
            obj.transform.localPosition = Vector3.zero;
            MeshFilter mf = obj.AddComponent<MeshFilter>();
            MeshRenderer mr = obj.AddComponent<MeshRenderer>();
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles;
            mf.mesh = mesh;
            mr.material.shader = Shader.Find("Unlit/Color");
            mr.material.color = color;
        }
    }
}