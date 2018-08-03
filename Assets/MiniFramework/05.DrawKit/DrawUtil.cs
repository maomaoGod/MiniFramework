using UnityEngine;
namespace MiniFramework
{
    public class DrawUtil
    {
        private static float factor = 100;

        public static void Sector(Vector3 center, float angle,float radius)
        {
            float rad=  Mathf.Deg2Rad*angle * 0.5f;
            float x = radius * Mathf.Sin(rad);
            float z = radius * Mathf.Cos(rad);
            Vector3 p1 = new Vector3(x, 0, z);
            Vector3 p2 = new Vector3(-x, 0, z);
            Gizmos.DrawLine(center, p1);
            Gizmos.DrawLine(center, p2);
            Gizmos.DrawLine(p1, p2);
        }
        public static void Circle(Vector3 center,float radius)
        {
            Vector3 p1 = center + new Vector3(-radius, 0, 0);
            Vector3 p2 = center + new Vector3(0, 0, radius);
            Vector3 p3 = center + new Vector3(radius, 0, 0);
            for (int i = 0; i < factor; i++)
            {
                Vector3 start = BezierUtil.Curve(i * (1/factor), p1, p2, p3);
                Vector3 end = BezierUtil.Curve((i + 1) * (1/factor), p1, p2, p3);
                Gizmos.DrawLine(start, end);
            }
        }
    }
}