using System.Collections.Generic;

using DirectoryBrowser.Messages;

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

        public void PlusTotalBytes(uint plus)
        {
            TotalBytes += plus;
        }

        public void MinusTotalBytes(uint minus)
        {
            TotalBytes = TotalBytes - minus;
        }
    }
}
