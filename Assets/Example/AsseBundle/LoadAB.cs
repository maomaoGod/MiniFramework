using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAB : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        yield return StartCoroutine(LoadCube());
        yield return StartCoroutine(LoadScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadCube()
    {
        WWW www = new WWW("file:///"+ Application.streamingAssetsPath + "/AB/StandaloneWindows/cube");
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            yield break;
        }
        AssetBundle ab = www.assetBundle;
        Instantiate(ab.LoadAsset("Cube"));
    }
    IEnumerator LoadScene()
    {
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/AB/StandaloneWindows/scene");
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            yield break;
        }
        AssetBundle ab = www.assetBundle;
        SceneManager.LoadScene("sceneasset");
    }
}
