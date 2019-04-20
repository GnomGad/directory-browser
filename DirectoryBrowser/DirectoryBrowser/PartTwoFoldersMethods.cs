using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mes = DirectoryBrowser.Messages;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        public void OpenDirectoryAndSetSelectPath()
        {
            appFolder.OpenDirectory();
        }
        public void SetTreeView()
        {
            
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(SetTreeNodes(new TreeNode(), appFolder.SelectPath, 0));
        }

        public TreeNode SetTreeNodes(TreeNode node ,string path,int index)
        {
            //node.Text = path;
            node.Nodes.Add(path);//1
            List<string> firstChildren = appFolder.GetFolderData(path);// делаем лист
            for(int i =0; i<firstChildren.Count;i++)
            {
                node.Nodes[index].Nodes.Add(firstChildren[i]);
                
                if (!Path.HasExtension(firstChildren[i])&& Directory.Exists(firstChildren[i]))
                {
                    SetTreeNodes(node.Nodes[index].Nodes[i], firstChildren[i], index);
                }
                
            }
            return node;

        }

        public void ForOpenButton()
        {
            OpenDirectoryAndSetSelectPath();
            SetTreeView();
            
        }
    }
}
