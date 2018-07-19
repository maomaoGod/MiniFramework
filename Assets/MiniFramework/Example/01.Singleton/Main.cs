using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        MonoSingletonExample.Instance.Test();
        MonoSingletonExample.Instance.Dispose();
        MonoSingletonExample.Instance.Test();

        SingletonExample.Instance.Test();
        SingletonExample.Instance.Dispose();
        SingletonExample.Instance.Test();
    }
}