using System.Windows.Forms;

namespace DirectoryBrowser.Messages
{
    class Messages
    {

    }
    static class MessageBug
    {
        static public void Show(string text)
        {
            MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
    static class MessageInfo
    {
        public static void Show(string text)
        {
            MessageBox.Show(text, "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }

    static class MessageHelp
    {
        public static void Show(string text)
        {
            MessageBox.Show(text, "Помощь!", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
    }
}

