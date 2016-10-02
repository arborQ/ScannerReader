using ScanReader.EventHandlers;
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
                var file = FilesInDirectory().FirstOrDefault(f => f.EndsWith("jpg") || f.EndsWith("png"));

                return file ?? "/Images/notLoaded.png";
            }
        }

        public string MachineDescription
        {
            get
            {
                var file = FilesInDirectory().FirstOrDefault(f => f.EndsWith("txt"));
                if (string.IsNullOrEmpty(file))
                {
                    return "brak opisu";
                }
                else
                {
                    var text = File.ReadAllText(file);
                    return string.IsNullOrEmpty(text) ? "brak opisu" : text;
                }
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

        private IEnumerable<string> FilesInDirectory()
        {
            var directoryPath = $"Images\\machines\\{Code}\\{DataNo}";

            directoryPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                directoryPath);

            if (Directory.Exists(directoryPath))
            {
                return Directory.EnumerateFiles(directoryPath);
            }
            else
            {
                return new string[0];
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
