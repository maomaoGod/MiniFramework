using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniFramework
{
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        public List<ChildPool> Pools = new List<ChildPool>();
        private Dictionary<string, Stack<GameObject>> cacheDict = new Dictionary<string, Stack<GameObject>>();
        //当前对象池中对象个数
        public int CurCount(string name)
        {
            if (cacheDict.ContainsKey(name))
            {
                return cacheDict[name].Count;
            }
            throw new Exception("对象池不存在这个对象:" + name);
        }
        /// <summary>
        /// 初始化对象池
        /// </summary>
        private void Start()
        {
            for (int i = 0; i < Pools.Count; i++)
            {
                for (int j = 0; j < Pools[i].MaxCount; j++)
                {
                    GameObject obj = Instantiate(Pools[i].Prefab);
                    obj.name = Pools[i].Prefab.name;
                    if (Pools[i].DontDestoryOnLoaded)
                    {
                        DontDestroyOnLoad(obj);
                    }
                    obj.SetActive(false);
                    if (!cacheDict.ContainsKey(Pools[i].Prefab.name))
                    {
                        cacheDict[Pools[i].Prefab.name] = new Stack<GameObject>();
                    }
                    cacheDict[Pools[i].Prefab.name].Push(obj);
                }
            }
        }
        /// <summary>
        /// 分配
        /// </summary>
        /// <returns></returns>
        public GameObject Allocate(string name)
        {
            if (CurCount(name) > 0)
            {
                GameObject obj = cacheDict[name].Pop();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                for (int i = 0; i < Pools.Count; i++)
                {
                    if (Pools[i].Prefab.name == name)
                    {
                        GameObject temp = Instantiate(Pools[i].Prefab);
                        if (Pools[i].DontDestoryOnLoaded)
                        {
                            DontDestroyOnLoad(temp);
                        }
                        temp.name = Pools[i].Prefab.name;
                        return temp;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Recycle(GameObject obj)
        {
            if (obj == null)
            {
                return false;
            }
            for (int i = 0; i < Pools.Count; i++)
            {
                if (CurCount(obj.name) >= Pools[i].MaxCount)
                {
                    return false;
                }
            }
            obj.SetActive(false);
            cacheDict[obj.name].Push(obj);
            return true;
        }
    }
    [Serializable]
    public class ChildPool
    {
        public int MaxCount;
        public bool DontDestoryOnLoaded;
        public GameObject Prefab;
    }
}
