namespace MiniFramework
{
    using UnityEngine;
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T mInstance = null;
        public static T Instance()
        {
            if (mInstance == null)
            {
                mInstance = Object.FindObjectOfType<T>();
                if (mInstance == null)
                {
                    var obj = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(obj);
                    mInstance = obj.AddComponent<T>();
                    mInstance.OnSingletonInit();
                }                
            }       
            return mInstance;
        }
        public virtual void OnSingletonInit()
        {

        }
        public virtual void Dispose()
        {
            DestroyImmediate(mInstance.gameObject);
        }
    }
}