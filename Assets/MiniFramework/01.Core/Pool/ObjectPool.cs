using System.Collections.Generic;
using UnityEngine;

namespace MiniFramework
{
    public class ObjectPool : MonoSingleton<ObjectPool>
    {
        private Dictionary<string, Stack<GameObject>> mCacheDict = new Dictionary<string, Stack<GameObject>>();
        public int CurCount(string name)
        {
            if (mCacheDict.ContainsKey(name))
            {
                return mCacheDict[name].Count;
            }
            throw new System.Exception("对象池不存在该对象！");
        }
        /// <summary>
        /// 初始化对象池
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="count"></param>
        public void Init(GameObject obj, int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject temp = Instantiate(obj);
                temp.name = obj.name;
                Recycle(temp);
            }
        }
        /// <summary>
        /// 分配
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public GameObject Allocate(string objName)
        {
            if (mCacheDict.ContainsKey(objName))
            {
                if (mCacheDict[objName].Count > 0)
                {
                    GameObject obj = mCacheDict[objName].Pop();
                    obj.SetActive(true);
                    return obj;
                }
            }
            return null;
        }
        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Recycle(GameObject obj)
        {
            if (obj == null)
            {
                return false;
            }
            obj.SetActive(false);
            if (mCacheDict.ContainsKey(obj.name))
            {
                if (!mCacheDict[obj.name].Contains(obj))
                    mCacheDict[obj.name].Push(obj);
            }
            else
            {
                mCacheDict.Add(obj.name, new Stack<GameObject>());
                mCacheDict[obj.name].Push(obj);
            }
            return true;
        }
    }
}

