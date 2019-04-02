using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        public FormDirectoryBrowser()
        {
            InitializeComponent();
            //WriteSystemLanguageInfo();
            //Language kek = new Language();
            //kek.Test();
          //  WriteSystemLanguageInfo();

           // SetLanguage(ReadSystemLanguage());
            

        }

        
        public XmlLanguage ReadSystemLanguage()
        {
            Language Lang = new Language();
            XmlLanguage XML = Lang.DeserializeXmSystemlLanguage();

            return XML;
        }
        public void WriteSystemLanguageInfo()
        {
            XmlLanguage kek = SetXmlLanguage();
            Language Lang = new Language();
            Lang.languageXml = kek;
            Lang.Test();
        }    
        /// <summary>
        /// Из системы вывести в xml
        /// </summary>
        /// <returns></returns>
        public XmlLanguage SetXmlLanguage()// вечное изменение
        {
            XmlLanguage Xml = new XmlLanguage();
            Xml.Language = "Sysyem";
            Xml.FormDirectoryBrowser = Text;
            Xml.fileToolStripMenuItem = fileToolStripMenuItem.Text;
            Xml.openToolStripMenuItem = openToolStripMenuItem.Text;
            Xml.saveToolStripMenuItem = saveToolStripMenuItem.Text;
            Xml.exitToolStripMenuItem = exitToolStripMenuItem.Text;
            Xml.settingsToolStripMenuItem = settingsToolStripMenuItem.Text;
            Xml.fontToolStripMenuItem = fontToolStripMenuItem.Text;
            Xml.colorToolStripMenuItem = colorToolStripMenuItem.Text;
            Xml.languageToolStripMenuItem = languageToolStripMenuItem.Text;
            Xml.helpToolStripMenuItem = helpToolStripMenuItem.Text;
            return Xml;
        }
        /// <summary>
        /// Конечно изменить данные системы
        /// </summary>
        /// <param name="Xml"></param>
        public void SetLanguage(XmlLanguage Xml)// вечное изменение
        {
            Text = Xml.FormDirectoryBrowser;
            languageToolStripMenuItem.Text = Xml.languageToolStripMenuItem;
            fileToolStripMenuItem.Text = Xml.fileToolStripMenuItem;
            openToolStripMenuItem.Text = Xml.openToolStripMenuItem;
            saveToolStripMenuItem.Text = Xml.saveToolStripMenuItem;
            exitToolStripMenuItem.Text = Xml.exitToolStripMenuItem;
            settingsToolStripMenuItem.Text  = Xml.settingsToolStripMenuItem;
            fontToolStripMenuItem.Text = Xml.fontToolStripMenuItem;
            colorToolStripMenuItem.Text = Xml.colorToolStripMenuItem;
            languageToolStripMenuItem.Text = Xml.languageToolStripMenuItem;
            helpToolStripMenuItem.Text = Xml.helpToolStripMenuItem;

        }
    }
}
