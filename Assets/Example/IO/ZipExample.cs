using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniFramework;
public class ZipExample : MonoBehaviour {
	// Use this for initialization
	void Start () {
        ZipUtil.ZipDirectory(Application.streamingAssetsPath, "C:/Users/Administrator/Desktop", "Test.zip");
        Debug.Log("正在压缩");
        if(ZipUtil.UpZipFile( "C:/Users/Administrator/Desktop/Test.zip", "C:/Users/Administrator/Desktop/Test"))
        {
            Debug.Log("解压成功");
        }
    }
}
