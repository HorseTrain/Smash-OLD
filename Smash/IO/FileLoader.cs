using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.IO
{
    public class FileLoader
    {
        public static string RootPath = @"D:\Programming\SmashAssets\";

        public static string GetPath(string path)
        {
            string pcheck;

            if (path.Contains(":"))
            {
                pcheck = path;
            }
            else
            {
                pcheck = RootPath + path;
            }

            if (File.Exists(pcheck + ".shtc"))
            {
                pcheck = GetPath(File.ReadAllText(pcheck + ".shtc"));
            }

            return pcheck.Replace("\r\n","");
        }

        public static byte[] ReadFileBytes(string path)
        {
            return File.ReadAllBytes(GetPath(path));
        }

        public static string[] GetFiles(string path)
        {
            string[] Out = Directory.GetFiles(GetPath(path));

            for (int i = 0; i < Out.Length; i++)
            {
                Out[i] = Out[i].Replace(".shtc", "");
            }

            return Out;
        }

        public static string[] GetDirs(string path)
        {
            return Directory.GetDirectories(GetPath(path)); 
        }

        public static bool FileExists(string path )
        {
            return File.Exists(GetPath(path));
        }
    }
}
