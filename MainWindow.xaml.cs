using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace note
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyTab tab = new MyTab();
        int count = 1;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            MyItem item = new MyItem();
            item.IsSaved = "*";
            item.Name = $"{item.IsSaved}New File {count} ";
            tab.AddItems((this.DataContext as MyTab).Items,item);
            count++;
            
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            MyItem item = new MyItem();
            if (openFileDialog.ShowDialog() == true)
            { 
                item.Text = File.ReadAllText(openFileDialog.FileName);
                item.Path = openFileDialog.FileName;
                item.Name = Path.GetFileName(item.Path);
                item.IsSaved = string.Empty;
            }
            tab.AddItems((this.DataContext as MyTab).Items, item);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MyItem item = tab.GetSelectedItem((this.DataContext as MyTab).Items, tabControl.SelectedIndex);
            tab.RemoveItem((this.DataContext as MyTab).Items, item);
            item.Name = item.Name.Replace("*", string.Empty);
            item.IsSaved = string.Empty;
            if(string.IsNullOrEmpty(item.Path))
            { 
                item.Path= $"C:/Users/40749/OneDrive/Desktop/Files/{item.Name}.txt";
            }
            
            File.WriteAllText(item.Path, item.Text);
            
            tab.AddItems((this.DataContext as MyTab).Items, item);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            MyItem item = tab.GetSelectedItem((this.DataContext as MyTab).Items, tabControl.SelectedIndex);
            tab.RemoveItem((this.DataContext as MyTab).Items, item);
            if(saveFileDialog.ShowDialog()==true)
            {
                item.Path = saveFileDialog.FileName;
                File.WriteAllText(item.Path, item.Text);
                item.IsSaved = string.Empty;
                item.Name = Path.GetFileName(item.Path);
            }
            tab.AddItems((this.DataContext as MyTab).Items, item);
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var item = tabControl.SelectedItem as MyItem;
            if(item.IsSaved=="*")
            {
                MessageBox.Show("Save file before closing the tab.");
            }
            else
            {
                tab.RemoveItem((this.DataContext as MyTab).Items, item);
            }
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            bool ok = false;
            foreach(var item in (this.DataContext as MyTab).Items)
            {
                if (item.IsSaved=="*")
                    ok = true;
            }
            if (ok)
                MessageBox.Show("Save all files before closing the tab.");
            else
                this.Close();
        }

    }
}
