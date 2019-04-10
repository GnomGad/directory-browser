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

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        AppFirst appFirst;
        AppDownStatus appDownStatus;

        public FormDirectoryBrowser()
        {
            InitializeComponent();
            appFirst = new AppFirst();
            appDownStatus = new AppDownStatus();

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            appFirst.SelectPath = appFirst.OpenDirectory();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appFirst.SelectPath = appFirst.OpenDirectory();
        }
    }
}
