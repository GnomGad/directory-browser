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

        private void listView1_ItemCheck1(object sender, ItemCheckEventArgs e)
        {
            //минус
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                UnCheckedMethod(ulong.Parse(listView1.Items[e.Index].SubItems[1].Text));
                CountExtensions[listView1.Items[e.Index].SubItems[2].Text] = CountExtensions[listView1.Items[e.Index].SubItems[2].Text] - 1;
            }
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                CheckedMethod(ulong.Parse(listView1.Items[e.Index].SubItems[1].Text));
                CountExtensions[listView1.Items[e.Index].SubItems[2].Text] = CountExtensions[listView1.Items[e.Index].SubItems[2].Text] + 1;
            }
            SetBottomMenu();

            SetChart();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveOpen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOpen();
        }
    }
}
