using MiniFramework;
using UnityEngine;
using UnityEngine.UI;

public class DownExample : MonoBehaviour {
    // Use this for initialization
    public Slider Slider;
    HttpDownloader http;
	void Start () {
        http = new HttpDownloader();
        string url = "http://sinacloud.net/zackzhang/blogsfile/SetupFactory9.0.3.0Trial.zip";
        http.DownLoad(this,url,Application.streamingAssetsPath+"/1.zip");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(http.GetProcess());
        Slider.value = http.GetProcess();
	}
}