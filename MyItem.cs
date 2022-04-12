using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace note
{
    public class MyItem
    {
        public string Name { get; set; }
        public string Path{ get; set; }
        public string Text { get; set; }
        public string IsSaved { get; set; }
        public MyItem()
        {
            Name = string.Empty;
            Path = string.Empty;
            Text = string.Empty;
            IsSaved = string.Empty;
        }
        
    }
}
