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
        public static void Sector(Transform target, float angle, float radius)
        {
            float eachAngle = angle / factor;
            for (int i = 0; i < factor; i++)
            {
                Vector3 start = Quaternion.Euler(0, -angle / 2 + eachAngle * i, 0f) * target.forward * radius + target.position;
                Vector3 end = Quaternion.Euler(0, -angle / 2 + eachAngle * (i+1), 0f) * target.forward * radius + target.position;
                Gizmos.DrawLine(start, end);
            }          
        }
        /// <summary>
        /// 圆形(贝塞尔实现)
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void Circle(Vector3 center, float radius)
        {
                       
        }

        /// <summary>
        /// 圆形(贝塞尔实现)
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void Circle2D(Vector2 center, float radius)
        {
            float c = (Mathf.Sqrt(radius/2f) *8f-4f)/3f;
            Vector2 p0 = new Vector2(center.x, center.y - radius);
            Vector2 p1 = new Vector2(center.x + c, center.y - radius);
            Vector2 p2 = new Vector2(center.x + radius, center.y - c);
            Vector2 p3 = new Vector2(center.x + radius, center.y);
            Vector2 p4 = new Vector2(center.x + radius, center.y + c);
            Vector2 p5 = new Vector2(center.x + c, center.y+radius);
            Vector2 p6 = new Vector2(center.x, center.y + radius);
            Vector2 p7 = new Vector2(center.x - c, center.y + radius);
            Vector2 p8 = new Vector2(center.x - radius, center.y + c);
            Vector2 p9 = new Vector2(center.x - radius, center.y);
            Vector2 p10 = new Vector2(center.x - radius, center.y - c);
            Vector2 p11 = new Vector2(center.x - c, center.y - radius);

            for (int i = 0; i < factor; i++)
            {
                Vector3 start = BezierUtil.Curve(i * (1 / factor), p0, p1, p2, p3);
                Vector3 end = BezierUtil.Curve((i + 1) * (1 / factor), p0, p1, p2, p3);
                Gizmos.DrawLine(start, end);
            }
            for (int i = 0; i < factor; i++)
            {
                Vector3 start = BezierUtil.Curve(i * (1 / factor), p3, p4, p5, p6);
                Vector3 end = BezierUtil.Curve((i + 1) * (1 / factor), p3, p4, p5, p6);
                Gizmos.DrawLine(start, end);
            }
            for (int i = 0; i < factor; i++)
            {
                Vector3 start = BezierUtil.Curve(i * (1 / factor), p6, p7, p8, p9);
                Vector3 end = BezierUtil.Curve((i + 1) * (1 / factor), p6, p7, p8, p9);
                Gizmos.DrawLine(start, end);
            }
            for (int i = 0; i < factor; i++)
            {
                Vector3 start = BezierUtil.Curve(i * (1 / factor), p9, p10, p11, p0);
                Vector3 end = BezierUtil.Curve((i + 1) * (1 / factor), p9, p10, p11, p0);
                Gizmos.DrawLine(start, end);
            }
        }
    }
}