using UnityEngine;

namespace MiniFramework
{
    /// <summary>
    /// 帧率计算器
    /// </summary>
    public class FPSCounter:MonoBehaviour
    {
        private const float calcRate = 0.5f;
        private int frameCount = 0;
        private float rateDuration = 0f;
        private int fps = 0;
        private void Start()
        {
            frameCount = 0;
            rateDuration = 0f;
            fps = 0;
        }
        private void Update()
        {
            frameCount++;
            rateDuration += Time.deltaTime;
            if (rateDuration > calcRate)
            {
                fps = (int)(frameCount / rateDuration);
                frameCount = 0;
                rateDuration = 0f;
            }
        }
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUILayout.Label("FPS:"+fps);
        }
    }
}
