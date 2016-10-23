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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new ItemsListDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
           DependencyProperty.Register("IsCheckBoxChecked", typeof(bool),
             typeof(MainWindow), new UIPropertyMetadata(false));

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void listView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(e == null) { }
        }
    }
}
