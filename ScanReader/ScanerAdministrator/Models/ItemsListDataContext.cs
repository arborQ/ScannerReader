using FileHelpers.FileLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScanerAdministrator.Models
{
    public class ItemsListDataContext : INotifyPropertyChanged
    {
        public IEnumerable<MachineFile> Items { get; set; }

        public ItemsListDataContext()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public void LoadData()
        {
            Items = FileLocatorHelper.LoadLocations().Where(a => a.IsValid);
            OnPropertyChanged("Items");
        }
    }
}
