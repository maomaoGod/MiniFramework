using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
namespace MiniFramework
{
    public class HttpDownloader
    {
        private string Url;
        private string TempSavePath;
        private string SavePath;
        private long CurLength;
        private long FileLength;
        //private bool IsStartDownload;
        private Action CallBack;

        public float GetProcess()
        {
            if (FileLength > 0)
            {
                return Mathf.Clamp((float)CurLength / FileLength, 0, 1);
            }
            return 0;
        }

        public void DownLoad(MonoBehaviour mono, string url, string savePath, Action callBack = null)
        {
            Url = url;
            TempSavePath = savePath + ".temp";
            SavePath = savePath;
            CallBack = callBack;
            mono.StartCoroutine(DownloadTask());
        }

        IEnumerator DownloadTask()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Method = "GET";
            FileStream fileStream;
            if (File.Exists(TempSavePath))
            {
                fileStream = File.OpenWrite(TempSavePath);
                CurLength = fileStream.Length;
                fileStream.Seek(CurLength, SeekOrigin.Current);
                request.AddRange((int)CurLength);
            }
            else
            {
                fileStream = new FileStream(TempSavePath, FileMode.Create, FileAccess.Write);
                CurLength = 0;
            }
            request.KeepAlive = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            FileLength = response.ContentLength + CurLength;
            //IsStartDownload = true;
            int lengthOnce;
            int bufferMaxLength = 1024 * 20;
            while (CurLength < FileLength)
            {
                byte[] buffer = new byte[bufferMaxLength];
                if (stream.CanRead)
                {
                    lengthOnce = stream.Read(buffer, 0, buffer.Length);
                    CurLength += lengthOnce;
                    fileStream.Write(buffer, 0, lengthOnce);
                }
                else
                {
                    break;
                }
            }
            //IsStartDownload = false;
            response.Close();
            stream.Close();
            fileStream.Close();
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }
            File.Move(TempSavePath, SavePath);
            if (CallBack != null)
            {
                CallBack();
            }
            yield return null;
        }
    }
}
