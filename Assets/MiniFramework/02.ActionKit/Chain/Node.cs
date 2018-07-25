using System;
namespace MiniFramework
{
    /// <summary>
    /// 节点类
    /// </summary>
    public class Node
    {
        public float Seconds { get; set; }
        public Action CallBack { get; set; }
        public Func<bool> Condition { get; set; }
        public bool IsFinished { get; set; }
    }
}
