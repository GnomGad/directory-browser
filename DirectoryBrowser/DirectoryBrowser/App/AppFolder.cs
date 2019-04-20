using System;
using System.Windows.Forms;

namespace DirectoryBrowser.App
{
    /// <summary>
    /// Класс к первому заданию, 
    /// </summary>
    class AppFolder
    {
        public string SelectPath { get; set; }

        private FolderBrowserDialog openFileDialog1;
        /// <summary>
        /// Возврат пути
        /// </summary>
        /// <returns>Может вернуть null если пути не будет</returns>
        public string OpenDirectory()
        {
            openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.SelectedPath != null)
                return openFileDialog1.SelectedPath;
            return null;
        }
    }
}
