using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniFramework
{
    /// <summary>
    /// 队列：控制所有节点的执行
    /// </summary>
    public class Sequence : IPoolable, ISequence
    {
        public MonoBehaviour Executer { get; set; }
        public bool IsRecycled { get; set; }
        private List<Node> Nodes = new List<Node>();
        public Sequence() { }
        public void Append(float seconds)
        {
            Node node = new Node();
            node.Seconds = seconds;
            node.Type = NodeType.Delay;
            Nodes.Add(node);
        }
        public void Append(Action callBack)
        {
            Node node = new Node();
            node.CallBack = callBack;
            node.Type = NodeType.Event;
            Nodes.Add(node);
        }
        public void Append(Func<bool> condition)
        {
            Node node = new Node();
            node.Condition = condition;
            node.Type = NodeType.Condition;
            Nodes.Add(node);
        }
        public void Execute()
        {
            Executer.StartCoroutine(SequenceCoroutine());
        }
        private IEnumerator SequenceCoroutine()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                float cur = 0;
                switch (Nodes[i].Type)
                {
                    case NodeType.Event:
                        Nodes[i].CallBack();
                        break;
                    case NodeType.Delay:
                        while ((cur += Time.deltaTime) < Nodes[i].Seconds)
                        {
                            yield return null;
                        }
                        break;
                    case NodeType.Condition:
                        while (Nodes[i].Condition()==false)
                        {
                            yield return null;
                        }
                        break;
                }
                Nodes[i].IsFinished = true;
            }
            
            ObjectPool<Sequence>.Instance.Recycle(this);
        }
        public void OnRecycled()
        {
            Nodes.Clear();
        }
    }
}