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
    }
}
