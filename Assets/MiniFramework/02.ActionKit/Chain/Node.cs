using System;
namespace MiniFramework
{
    public enum NodeType
    {
        Delay,
        Event,
        Condition,
    }
    /// <summary>
    /// 节点类
    /// </summary>
    public class Node
    {
        public NodeType Type { get; set; }
        public float Seconds { get; set; }
        public Action CallBack { get; set; }
        public Func<bool> Condition { get; set; }
        public bool IsFinished { get; set; }
    }
}
