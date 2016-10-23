using FileHelpers.EventHandlers;
using FileHelpers.FileLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        public IScanerHandler Scaner;
        
        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged();
                OnPropertyChanged("ImagePath");
                OnPropertyChanged("MachineDescription");
            }
        }

        private string _dataNo;
        public string DataNo
        {
            get
            {
                return _dataNo;
            }
            set
            {
                _dataNo = value;
                OnPropertyChanged();
                OnPropertyChanged("ImagePath");
                OnPropertyChanged("MachineDescription");
            }
        }

        public string ImagePath
        {
            get
            {
                var file = FileLocatorHelper.LoadLocations(Code, DataNo);

                return file != null && file.IsValid ? file.Image : "/Images/notLoaded.png";
            }
        }

        public string MachineDescription
        {
            get
            {
                var file = FileLocatorHelper.LoadLocations(Code, DataNo);
                return file != null && file.IsValid ? file.Description : "brak opisu";
            }
        }

        public MainWindow()
        {
            Scaner = new ScanerHandler(
                onCodeEntered: code =>
                {
                    Code = code;
                },
                onDataNoEntered: dataNo =>
                {
                    DataNo = dataNo;
                });
            InitializeComponent();
            DataContext = this;
        }

        private void OnWindowKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                return;
            }
            Scaner.InputTriggered(e.Key);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
