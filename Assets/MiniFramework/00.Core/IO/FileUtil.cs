using System.IO;
namespace MiniFramework
{
    public static class FileUtil
    {
        public static void CreateDirectoryIfNonExist(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
