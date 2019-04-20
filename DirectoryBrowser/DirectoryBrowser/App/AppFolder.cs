using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using MessInfo = DirectoryBrowser.Messages.MessageInfo;
namespace DirectoryBrowser.App
{
    /// <summary>
    /// Класс к первому заданию, 
    /// </summary>
    class AppFolder
    {
        private List<string> fileDatas = new List<string>();
        public string SelectPath { get;private set; }

        private FolderBrowserDialog openFileDialog1;

        /// <summary>
        /// Возврат пути и заполнение путем SelectPath
        /// </summary>
        /// <returns>Может вернуть null если пути не будет</returns>
        public string OpenDirectory()
        {
            openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.SelectedPath != null || openFileDialog1.SelectedPath != "")
            {
                MessInfo.Show($"|{openFileDialog1.SelectedPath}|");//--------------------------- удалить после рефакторинга

                SelectPath = openFileDialog1.SelectedPath;
                return openFileDialog1.SelectedPath;
            }
            MessInfo.Show("Путь не был указан");
            return null;
        }
        /// <summary>
        /// Получить Данные из пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string>  GetFolderData(string path)
        {
            List<string> fileData = new List<string>();
            if (path == null || path.Trim() == "")
                return fileData;
            
            try
            {
                fileData.AddRange(Directory.GetDirectories(path));

                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                    files[i] = Path.GetFileName(files[i]);

                fileData.AddRange(files);
            }
            catch
            {

            }
            
            return fileData;
        }
        public void ClearFileData()
        {
            //fileData.Clear();
        }

    }
}
