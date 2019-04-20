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
using DirectoryBrowser.Messages;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        AppFolder appFolder;
        AppBottomPanel appDownStatus;

        public FormDirectoryBrowser()
        {
            InitializeComponent();
            appFolder = new AppFolder();
            appDownStatus = new AppBottomPanel();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            appFolder.SelectPath = appFolder.OpenDirectory();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appFolder.SelectPath = appFolder.OpenDirectory();
        }
    }
}
