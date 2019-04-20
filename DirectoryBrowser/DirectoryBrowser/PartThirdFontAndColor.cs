using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            listView1.BackColor = colorDialog1.Color;
        }
    }
}
