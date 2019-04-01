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
            //WriteSystemLanguageInfo();
            SetLanguage(ReadSystemLanguage());
            

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
        public XmlLanguage SetXmlLanguage()// вечное изменение
        {
            XmlLanguage XML = new XmlLanguage();
            XML.Language = "Sysyem";
            XML.FormDirectoryBrowser = Text;
            return XML;
        }
        public void SetLanguage(XmlLanguage Xml)// вечное изменение
        {
            languageToolStripMenuItem.Text = Xml.Language;
            Text = Xml.FormDirectoryBrowser;
        }
    }
}
