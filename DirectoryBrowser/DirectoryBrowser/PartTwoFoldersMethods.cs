using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectoryBrowser.App;
using Mes = DirectoryBrowser.Messages;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        Dictionary<string, ulong> infoFile;
        public void OpenDirectoryAndSetSelectPath()
        {
            appFolder.OpenDirectory();
        }
        public void SetTreeView()
        {
            infoFile = new Dictionary<string, ulong>();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(SetTreeNodes(new TreeNode(), appFolder.SelectPath, 0));
            SetListView();
            appBottomPanel = new AppBottomPanel(infoFile);

        }

        public TreeNode SetTreeNodes(TreeNode node ,string path,int index)
        {
            //node.Text = path;
            node.Nodes.Add(path); //1

            List<string> firstChildren = appFolder.GetFolderData(path);// делаем лист
            for(int i =0; i<firstChildren.Count;i++)
            {
                node.Nodes[index].Nodes.Add(firstChildren[i]);
                if (!Path.HasExtension(firstChildren[i])&& Directory.Exists(firstChildren[i]))
                {
                    SetTreeNodes(node.Nodes[index].Nodes[i], firstChildren[i], index);
                }
                else
                {
                    try
                    {
                        FileInfo kek = new FileInfo(Path.Combine(path, firstChildren[i]));
                        infoFile.Add(path + "\\" + firstChildren[i],(ulong)kek.Length);
                    }
                    catch { }
                }
                
            }
            return node;

        }
        /// <summary>
        /// Запуск
        /// </summary>
        public void ForOpenButton()
        {
            OpenDirectoryAndSetSelectPath();
            SetTreeView();
            SetBottomMenu();
        }

        public void SetListView()
        {
            ClearBottomMenu();
            listView1.Items.Clear();
            ListViewItem[] lsi = new ListViewItem[infoFile.Count];
            int i1 = 0;
            foreach (string k in infoFile.Keys)
            {
                lsi[i1] = new ListViewItem();
                lsi[i1++].Text = Path.GetFileName(k);
            }
            int i2 = 0;
            foreach (int k in infoFile.Values)
                lsi[i2++].SubItems.Add(k.ToString());
            int i3 = 0;
            foreach (string k in infoFile.Keys)
                lsi[i3++].SubItems.Add(Path.GetExtension(k));

            foreach (ListViewItem k in lsi)
                listView1.Items.Add(k).Checked = true;

        }

        public void SetBottomMenu()
        {
            ClearBottomMenu();
            string text =$"Bytes: {appBottomPanel.TotalBytes} {appBottomPanel.ItemSelected,10} of {appBottomPanel.AllItems} items selected";
            statusStrip1.Items.Add(text);
        }

        public void ClearBottomMenu()
        {
            statusStrip1.Items.Clear();
        }

    }
}
