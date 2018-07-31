using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace MiniFramework
{
    class HttpDownloader : MonoBehaviour
    {
        void Start()
        {
           
        }
        public bool Get(string url,string savePath)
        {
            StartCoroutine(WebDownload());
            return true;
        }
        IEnumerator WebDownload()
        {
            using (UnityWebRequest www = UnityWebRequest.Get("file:///"+Application.streamingAssetsPath+ "/Xml"))
            {
                yield return www.Send();

                if (www.isError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    // Show results as text
                    Debug.Log(www.downloadHandler.text);
                    // Or retrieve results as binary data
                    byte[] results = www.downloadHandler.data;
                }
            }
        }
    }
}
