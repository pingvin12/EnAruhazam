using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace EnAruhazam.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @".\Release.zip";
            string extractPath = @".\EnAruhazam";

            WebClient wc = new WebClient();
            Console.WriteLine("Frissítés letöltése.....");
            wc.DownloadFile("https://1drv.ms/u/s!AnR_mxbxU3sugc9p5ielLsfCYj7qZw?e=Lb6dhZ", "Release.zip");
            //GET kéréssel működnek a felhős oldalak nagy része, így a fenti megoldás nem fog letölteni semmit. -> korrupt zip

            Console.WriteLine("Frissítés letöltése befejeződött.");
            Console.WriteLine("Kicsomagolás...");
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            Console.WriteLine("Kicsomagolva.");
            Console.WriteLine("Az alkalmazás indításra készen van.");
            Console.ReadLine();
        }
    }
}
