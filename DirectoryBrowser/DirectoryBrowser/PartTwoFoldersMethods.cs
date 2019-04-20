using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectoryBrowser.App;
using System.Drawing;
using Mes = DirectoryBrowser.Messages;

namespace DirectoryBrowser
{
    public partial class FormDirectoryBrowser : Form
    {
        Dictionary<string, ulong> infoFile;
        Dictionary<string, int> CountExtensions;
        
        public void OpenDirectoryAndSetSelectPath()
        {
            appFolder.OpenDirectory();
        }
        public void SetTreeView()
        {
            infoFile = new Dictionary<string, ulong>();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(SetTreeNodes(new TreeNode(), appFolder.SelectPath, 0));
            appBottomPanel = new AppBottomPanel();
            SetListView();
            

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
            SetChart();
        }

        public void SetListView()
        {
            CountExtensions = new Dictionary<string, int>();
            ClearBottomMenu();
            listView1.Items.Clear();
            ListViewItem[] lsi = new ListViewItem[infoFile.Count];
            int i1 = 0;
            foreach (string k in infoFile.Keys)
            {
                lsi[i1] = new ListViewItem();
                lsi[i1++].Text = Path.GetFileName(k);
            }
            appBottomPanel.SetAllItems(i1);
            int i2 = 0;
            foreach (int k in infoFile.Values)
            {
                lsi[i2++].SubItems.Add(k.ToString());
                CheckedMethod((ulong)k);
            }
            int i3 = 0;
            foreach (string k in infoFile.Keys)
            {
                
                lsi[i3++].SubItems.Add(Path.GetExtension(k));

                if (CountExtensions.ContainsKey(Path.GetExtension(k)))
                    CountExtensions[Path.GetExtension(k)]++;
                else
                    CountExtensions[Path.GetExtension(k)] = 1;
            }

            foreach (ListViewItem k in lsi)
            {
                if (k.SubItems[2].Text == ".png" || k.SubItems[2].Text == ".jpg" || k.SubItems[2].Text == ".bmp" || k.SubItems[2].Text == ".gif")
                    k.BackColor = Color.FromArgb(81, 168, 145);
                else if (k.SubItems[2].Text == ".docx" || k.SubItems[2].Text == ".xlsx" || k.SubItems[2].Text == ".pdf" || k.SubItems[2].Text == ".txt")
                    k.BackColor = Color.FromArgb(197, 204, 240);
                else if (k.SubItems[2].Text == ".exe" || k.SubItems[2].Text == ".dll")
                    k.BackColor = Color.FromArgb(255, 168, 145);
                else if (k.SubItems[2].Text == ".zip" || k.SubItems[2].Text == ".rar" || k.SubItems[2].Text == ".7z")
                    k.BackColor = Color.FromArgb(255,80,25);
                    listView1.Items.Add(k).Checked = true;
            }

            listView1.ItemCheck += listView1_ItemCheck1;
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

        public void SetChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Extension");
            string[] ext =CountExtensions.Keys.ToArray();
            int[] val = CountExtensions.Values.ToArray();
            for (int i = 0; i < val.Length;i++)
                chart1.Series[0].Points.AddXY(ext[i], val[i]);
        }

        /// <summary>
        /// Снятие элемнта
        /// </summary>
        public void UnCheckedMethod(ulong bytes)
        {
            appBottomPanel.MinusTotalBytes(bytes);
            appBottomPanel.MinusItemSelected(1);
        }

        /// <summary>
        /// Добавление элемнта
        /// </summary>
        public void CheckedMethod(ulong bytes)
        {
            appBottomPanel.PlusTotalBytes(bytes);
            appBottomPanel.PlusItemSelected(1);
        }

        public void SaveOpen()
        {
            AppSaveInfo saveInfo = new AppSaveInfo();
            saveInfo.SetPath();
            StringBuilder kek = new StringBuilder();
            for (int i = 0; i<listView1.Items.Count;i++)
                kek.AppendLine(listView1.Items[i].SubItems[0].Text+"  "+ listView1.Items[i].SubItems[1].Text+" Bytes");
           saveInfo.Write(kek.ToString());
        }

    }
}
