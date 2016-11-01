using ExcelHelpers;
using ScanerAdministrator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace ScanerAdministrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ItemsListDataContext ItemsContext
        {
            get
            {
                return DataContext as ItemsListDataContext;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ItemsListDataContext();
            textBox.Focus();
        }

        private void listView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(e == null) { }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ItemsContext.LoadData();
        }

        private void showDetails(object sender, MouseButtonEventArgs e)
        {
            if(e == null) { }
        }

        private void CloseEvent(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExportExcel(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.DefaultExt = ".xlsx";
            //dlg.Filter = "Excel (*.xlsx)";


            // Display OpenFileDialog by calling ShowDialog method 
            var result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                //textBox1.Text = filename;

                using (var help = new ExcelHelper(dlg.FileName))
                {
                    help.UpdateValue("Maszyny", "A1", "test 1");
                    help.UpdateValue("Maszyny", "B1", "test 2");
                    help.UpdateValue("Maszyny", "C1", "test 3");
                }
            }
        }
    }
}
