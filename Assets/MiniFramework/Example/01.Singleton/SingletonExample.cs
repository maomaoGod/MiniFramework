using MiniFramework;
using UnityEngine;

public class SingletonExample : Singleton<SingletonExample>
{
    private SingletonExample()
    {

    }
    public override void OnSingletonInit()
    {
        Debug.Log(this.ToString() + "初始化");
    }
    public void Test()
    {

    }
}
