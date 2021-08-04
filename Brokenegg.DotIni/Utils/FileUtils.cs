using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Brokenegg.DotIni.Utils
{
    public class FileUtils
    {
        public static string ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new FileNotFoundException(path);
            if (!File.Exists(path)) throw new FileNotFoundException(path);

            return File.ReadAllText(path);
        }

        public static string ToCurrentLocation(string path)
        {
           return Path.Combine(Directory.GetCurrentDirectory(), path);
        }
    }
}
