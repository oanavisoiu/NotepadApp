using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace note
{
    public class MyTab
    {
        
        public ObservableCollection<MyItem> Items { get; set; }
        public MyTab()
        {
            Items = new ObservableCollection<MyItem>();
        }
        public void AddItems(ObservableCollection<MyItem> Items, MyItem item)
        { 
            Items.Add(item);
        }
        public void RemoveItem(ObservableCollection<MyItem> Items, MyItem item)
        {
            Items.Remove(item);
        }
        public MyItem GetSelectedItem(ObservableCollection<MyItem> Items, int index)
        {
            return Items[index];
        }
        
        
    }
}
