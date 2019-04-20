using System.Collections.Generic;

namespace DirectoryBrowser.App
{
    /// <summary>
    /// Класс для нижней панели
    /// </summary>
    class AppBottomPanel
    {
        public AppBottomPanel(int items,ulong totals)
        {
            ItemSelected = items;
            AllItems = items;
            TotalBytes = totals;
        }

        public AppBottomPanel(Dictionary<string,ulong> k)
        {
            ItemSelected = k.Count;
            AllItems = k.Count;

            ulong ul = 0;
            foreach (ulong s in k.Values)
                ul += s;
            TotalBytes = ul;
        }

        public AppBottomPanel(int items)
        {
            ItemSelected = 0;
            AllItems = items;
            TotalBytes = 0;
        }

        public AppBottomPanel()
        {
            ItemSelected = 0;
            AllItems = 0;
            TotalBytes = 0;
        }
        public  int ItemSelected { get;private set; }
        public ulong TotalBytes { get;private set; }
        public int AllItems { get; set; }

        public void PlusItemSelected(int plus)
        {
            ItemSelected += plus;
        }

        public void MinusItemSelected(int minus)
        {
            ItemSelected = ItemSelected - minus;
        }

        public void PlusTotalBytes(ulong plus)
        {
            TotalBytes += plus;
        }

        public void MinusTotalBytes(ulong minus)
        {
            TotalBytes = TotalBytes - minus;
        }

        public void SetAllItems(int total)
        {
            AllItems = total;
        }
    }
}
