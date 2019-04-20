using System.Windows.Forms;

namespace DirectoryBrowser.Messages
{
    class MessageBug
    {
        public virtual void Show(string text)
        {
            MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
    class MessageInfo
    {
        public virtual void Show(string text)
        {
            MessageBox.Show(text, "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}

