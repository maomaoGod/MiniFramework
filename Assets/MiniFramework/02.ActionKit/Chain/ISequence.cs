using System;
namespace MiniFramework
{
    /// <summary>
    /// 队列接口
    /// </summary>
    public interface ISequence
    {
        void Append(float seconds=0f,Action callBack = null,Func<bool> condition =null);
        void Execute();
    }
}
