using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DirectoryBrowser.App;
using MyMessage = DirectoryBrowser.Messages;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        AppFolder appFolder;
        AppBottomPanel appBottomPanel;

        public FormDirectoryBrowser()
        {
            InitializeComponent();
            appFolder = new AppFolder();
            //appDownStatus = new AppBottomPanel();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ForOpenButton();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForOpenButton();
        }


    }
}
