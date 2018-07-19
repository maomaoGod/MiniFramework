using MiniFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolExample : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Pool<Fish>.Instance.Init(50, 10);
        Debug.Log("初始化鱼：" + Pool<Fish>.Instance.CurCount);

        Pool<Bear>.Instance.Init(100, 5);      
        Debug.Log("初始化熊："+ Pool<Bear>.Instance.CurCount);

        var fish = Pool<Fish>.Instance.Allocate();
        Debug.Log("分配了一个鱼，剩余："+ Pool<Fish>.Instance.CurCount+"回收标志："+fish.IsRecycled);
        fish.name = "xx";
        Pool<Fish>.Instance.Recycle(fish);
        Debug.Log("回收了一个鱼，剩余：" + Pool<Fish>.Instance.CurCount+"回收标志："+fish.IsRecycled);

        var bear = Pool<Bear>.Instance.Allocate();
        Debug.Log("分配了一个熊，剩余：" + Pool<Bear>.Instance.CurCount);
        Pool<Bear>.Instance.Recycle(bear);
        Debug.Log("回收了一个熊，剩余：" + Pool<Bear>.Instance.CurCount);

        Debug.Log(Pool<Fish>.Instance.Allocate().name);
    }

    private void OnDestroy()
    {
        Pool<Fish>.Instance.Dispose();
    }
}

public class Fish:IPoolable
{
    public string name;

    public bool IsRecycled { get; set; }
}
public class Bear : IPoolable
{
    public bool IsRecycled { get; set; }
}
