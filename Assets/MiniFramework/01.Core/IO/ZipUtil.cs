using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace MiniFramework
{
    /// <summary>
    /// 注:中文命名文件会出错！
    /// </summary>
    public class ZipUtil
    {
        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="folderPath">需要压缩的文件夹路径</param>
        /// <param name="zipedPath">压缩包存放路径</param>
        /// <param name="zipedFileName">压缩包名</param>
        /// <param name="isEncrypt">是否加密</param>
        public static void ZipDirectory(string DirectoryPath, string zipedPath, string zipedFileName)
        {
            if (!Directory.Exists(DirectoryPath))
            {
                throw new FileNotFoundException("指定目录：" + DirectoryPath + "不存在！");
            }
            using (FileStream fileStream = File.Create(zipedPath + "/" + zipedFileName))
            {
                using (ZipOutputStream outStream = new ZipOutputStream(fileStream))
                {
                    ZipStep(DirectoryPath, outStream, "");
                }
            }
        }
        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="zipFilePath">压缩包路径</param>
        /// <param name="unZipDir">解压文件存放路径</param>
        /// <returns></returns>
        public static bool UpZipFile(string zipFilePath, string unZipDir)
        {         
            if (unZipDir == string.Empty)
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!Directory.Exists(unZipDir))
                Directory.CreateDirectory(unZipDir);
            if (!unZipDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                unZipDir += Path.DirectorySeparatorChar;
            using (ZipInputStream inputStream = new ZipInputStream(File.OpenRead(zipFilePath)))
            {
                ZipEntry theEntry;
                while ((theEntry = inputStream.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(unZipDir + directoryName);
                    }
                    if (!directoryName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                        directoryName += Path.DirectorySeparatorChar.ToString();
                    if (fileName != string.Empty)
                    {
                        using (FileStream writer = File.Create(unZipDir + theEntry.Name))
                        {
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = inputStream.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    writer.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 递归目录
        /// </summary>
        /// <param name="path"></param>
        private static void ZipStep(string targetDirectory, ZipOutputStream stream, string parentPath)
        {
            if (targetDirectory[targetDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                targetDirectory += Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();
            string[] fileNames = Directory.GetFileSystemEntries(targetDirectory);
            foreach (var file in fileNames)
            {
                if (Directory.Exists(file))
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf(Path.DirectorySeparatorChar.ToString()) + 1);
                    pPath += Path.DirectorySeparatorChar.ToString();
                    ZipStep(file, stream, pPath);
                }
                else
                {
                    using (FileStream fs = File.OpenRead(file))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        string fileName = parentPath + file.Substring(file.LastIndexOf(Path.DirectorySeparatorChar.ToString()) + 1);
                        ZipEntry entry = new ZipEntry(fileName);
                        entry.DateTime = DateTime.Now;
                        entry.Size = fs.Length;
                        fs.Close();
                        crc.Reset();
                        crc.Update(buffer);
                        entry.Crc = crc.Value;
                        stream.PutNextEntry(entry);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
