using UnityEngine;
using System;
namespace MiniFramework
{
    /// <summary>
    /// 链式调用类
    /// </summary>
    public static class ActionChain
    {
        public static void Delay<T>(this T selfBehaviour,float seconds,Action callBack) where T : MonoBehaviour
        {
            Sequence sequence = ObjectPool<Sequence>.Instance.Allocate();
            sequence.Executer = selfBehaviour;
            sequence.Append(seconds);
            sequence.Append(callBack);
            sequence.Execute();
        }
        public static ISequence Sequence<T>(this T selfBehaviour) where T : MonoBehaviour
        {
            Sequence sequence = ObjectPool<Sequence>.Instance.Allocate();
            sequence.Executer = selfBehaviour;
            return sequence;
        }
        public static ISequence Delay(this ISequence sequence, float seconds)
        {
            sequence.Append(seconds);           
            return sequence;
        }
        public static ISequence Event(this ISequence sequence, Action callBack)
        {
            sequence.Append(callBack);
            return sequence;
        }
        public static ISequence Until(this ISequence sequence, Func<bool> condition)
        {
            sequence.Append(condition);
            return sequence;
        }
        public static ISequence Start(this ISequence sequence)
        {
            sequence.Execute();
            return sequence;
        }
    }
}