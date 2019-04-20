using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DirectoryBrowser.App
{
    class AppSaveInfo
    {
        private string name = "Info.txt";
        private string path = "Info.txt";
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value != null)
                    path = value;
            }
        }
        StreamWriter streamWriter = null;

        public void Write(string text)
        {
            streamWriter = new StreamWriter(File.OpenWrite(path));
            streamWriter.WriteLine(text);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public void SetPath()
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.SelectedPath != "")
                Path = openFileDialog1.SelectedPath+"\\"+name;
        }

    }
}
