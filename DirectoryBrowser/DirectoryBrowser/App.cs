using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectoryBrowser.Messages;
namespace DirectoryBrowser
{   
    /// <summary>
    /// Класс к первому заданию
    /// </summary>
    class AppFirst
    {
        /// <summary>
        /// в это засунуть путь
        /// </summary>
        public string SelectPath { get; set; }
       

        private FolderBrowserDialog openFileDialog1;
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Может вернуть null если пути не будет</returns>
        public string OpenDirectory()
        {
            openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.ShowDialog();
            if(openFileDialog1.SelectedPath!=null)
                return openFileDialog1.SelectedPath;
            return null;

        }

        


    }

    class AppDownStatus
    {
        MessageBug messageBug = new MessageBug();
        public ulong Bytes { get; private set; }

        public uint TotalFiles { get; set; }
        public uint SelectedFiles { get; set; }

        public AppDownStatus()
        {
            Bytes = 0;
            TotalFiles = 0;
            SelectedFiles = 0;
        }
        
        public void PlusBytes(ulong a)
        {
            Bytes += a;
            
        }
        public void MinusBytes(ulong a)
        {
            try
            {
                if(Bytes-a <0)
                    throw new Exception("Не может быть количество байт меньше чем 0\r\n действие не сохранено");
                else
                    Bytes -= a;
            }
            catch(Exception e)
            {
                messageBug.Show(e.Message);
            }
        }

        public string ReturnStatus()
        {
            string txt = SelectedFiles.ToString() + " of " + TotalFiles.ToString() + " selected files";
            return txt;
        }
    }

    
}

namespace DirectoryBrowser.Messages
{
    class MessageBug
    {
        public virtual void Show(string text)
        {
            MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
