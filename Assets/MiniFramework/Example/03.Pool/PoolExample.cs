using System;
using MiniFramework;
using UnityEngine;
public class PoolExample : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        ObjectPool<Fish>.Instance.Init(50, 10);
        Debug.Log("初始化鱼：" + ObjectPool<Fish>.Instance.CurCount);

        ObjectPool<Bear>.Instance.Init(100, 5);
        Debug.Log("初始化熊：" + ObjectPool<Bear>.Instance.CurCount);

        var fish = ObjectPool<Fish>.Instance.Allocate();
        Debug.Log("分配了一个鱼，剩余：" + ObjectPool<Fish>.Instance.CurCount + "回收标志：" + fish.IsRecycled);
        fish.name = "xx";
        ObjectPool<Fish>.Instance.Recycle(fish);
        Debug.Log("回收了一个鱼，剩余：" + ObjectPool<Fish>.Instance.CurCount + "回收标志：" + fish.IsRecycled);

        var bear = ObjectPool<Bear>.Instance.Allocate();
        Debug.Log("分配了一个熊，剩余：" + ObjectPool<Bear>.Instance.CurCount);
        ObjectPool<Bear>.Instance.Recycle(bear);
        Debug.Log("回收了一个熊，剩余：" + ObjectPool<Bear>.Instance.CurCount);

        Debug.Log(ObjectPool<Fish>.Instance.Allocate().name);
    }

    private void OnDestroy()
    {
        ObjectPool<Fish>.Instance.Dispose();
    }
}

public class Fish : IPoolable
{
    public string name;

    public bool IsRecycled { get; set; }

    public void OnRecycled() { }
}
public class Bear : IPoolable
{
    public bool IsRecycled { get; set; }

    public void OnRecycled() { }
}