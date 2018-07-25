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
        public void Append(float seconds = 0f, Action callBack = null, Func<bool> condition = null)
        {
            Node node = new Node();
            node.Seconds = seconds;
            node.CallBack = callBack;
            node.Condition = condition;
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
                while ((cur += Time.deltaTime) < Nodes[i].Seconds)
                {
                    yield return null;
                }
                if (Nodes[i].Condition != null)
                {
                    while (Nodes[i].Condition() == false)
                    {
                        yield return null;
                    }
                }
                if (Nodes[i].CallBack != null)
                {
                    Nodes[i].CallBack();
                }
                Nodes[i].IsFinished = true;
            }
            Pool<Sequence>.Instance.Recycle(this);
        }
        public void OnRecycled()
        {
            Nodes.Clear();
        }
    }
}