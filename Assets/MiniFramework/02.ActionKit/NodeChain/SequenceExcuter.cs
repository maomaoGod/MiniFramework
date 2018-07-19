using System;
using UnityEngine;

namespace MiniFramework
{
    public static class SequenceExcuter
    {
        public static INode Sequence<T>(this T selfBehaviour) where T:MonoBehaviour
        {
            var node = new Sequence() { Executer = selfBehaviour};
            return node;
        }
        public static INode Delay(this INode node,float seconds)
        {
            return new DelayAction() { DelayTime = seconds};
        }
        public static INode Event(this INode node,Action onEvent)
        {
            return new EventAction() { ExcuteEvent = onEvent };
        }
    }
}