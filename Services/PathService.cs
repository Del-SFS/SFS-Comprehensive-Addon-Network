using System.IO;

namespace SCAN.Services
{
    public static class PathService
    {
        private static readonly string CacheFolder =
            "cache";

        private static readonly string PathFile =
            "cache/sfsdir.txt";

        // CREATE CACHE

        public static void Initialize()
        {
            if (!Directory.Exists(CacheFolder))
            {
                Directory.CreateDirectory(
                    CacheFolder);
            }

            if (!File.Exists(PathFile))
            {
                File.WriteAllText(
                    PathFile,
                    "");
            }
        }

        // SAVE PATH

        public static void SaveGamePath(
            string path)
        {
            File.WriteAllText(
                PathFile,
                path);
        }

        // LOAD PATH

        public static string LoadGamePath()
        {
            if (!File.Exists(PathFile))
            {
                return "";
            }

            return File.ReadAllText(
                PathFile);
        }
    }
}