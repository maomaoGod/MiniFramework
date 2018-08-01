using UnityEngine;

public static class BezierUtil{
    /// <summary>
    /// 二阶曲线
    /// </summary>
    /// <param name="t">[0,1]</param>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="controlPoint"></param>
    /// <returns></returns>
    public static Vector3 Curve(float t,Vector3 startPos,Vector3 endPos,Vector3 controlPoint)
    {
        Vector3 point = Vector3.zero;
        float t1 = (1 - t) * (1 - t);
        float t2 = t * (1 - t);
        float t3 = t * t;
        point = startPos * t1 + 2 * t2 * controlPoint + t3 * endPos;
        return point;
    }
    /// <summary>
    /// 三阶曲线
    /// </summary>
    /// <param name="t">[0,1]</param>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="controlPoint"></param>
    /// <param name="controlPoint2"></param>
    /// <returns></returns>
    public static Vector3 Curve(float t,Vector3 startPos,Vector3 endPos,Vector3 controlPoint,Vector3 controlPoint2)
    {
        Vector3 point = Vector3.zero;
        float t1 = (1 - t) * (1 - t) * (1 - t);
        float t2 = (1 - t) * (1 - t) * t;
        float t3 = t * t * (1 - t);
        float t4 = t * t * t;
        point = startPos * t1 + 3 * t2 * controlPoint + 3 * t3 * controlPoint2 + endPos * t4;
        return point;
    }
}
