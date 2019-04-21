using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace DirectoryBrowser
{

    public partial class FormDirectoryBrowser: Form
    {
       
        public void SettingStyle()
        {
            FontStyle();
            ColorStyle();
        }

        public void FontStyle()
        {
            fontDialog1.ShowDialog();
            listView1.Font = fontDialog1.Font;
        }

        public void ColorStyle()
        {
            colorDialog1.ShowDialog();
            if (listView1.Items.Count == 0)
            {
                DirectoryBrowser.Messages.MessageBug.Show("Нет правого меню");
                return;
            }
            for (int i = 0; listView1.Items.Count> 0 && i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].BackColor.ToArgb() != Color.FromArgb(81, 168, 145).ToArgb()&& listView1.Items[i].BackColor.ToArgb() != Color.FromArgb(197, 204, 240).ToArgb()&& listView1.Items[i].BackColor.ToArgb() != Color.FromArgb(255, 168, 145).ToArgb() && listView1.Items[i].BackColor.ToArgb() != Color.FromArgb(255, 80, 25).ToArgb())
                    listView1.Items[i].BackColor = colorDialog1.Color;
                    
            }
            
        }
    }
}
