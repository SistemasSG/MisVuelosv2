using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.Runtime.CompilerServices;
using MisVuelosv2.iOS;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace MisVuelosv2.iOS
{
    public class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}