using ScanReader.EventHandlers;
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

namespace ScanReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ScanerHandler Scaner;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                OnPropertyChanged();
                _code = value;
            }
        }

        public MainWindow()
        {
            Scaner = new ScanerHandler();
            InitializeComponent();
            this.DataContext = this;
            this.Code = "test";
        }

        private void OnWindowKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                return;
            }
            Scaner.OnInputEnter(sender, e);
        }

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
