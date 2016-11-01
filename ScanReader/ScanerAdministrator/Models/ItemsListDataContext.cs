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
        private IEnumerable<MachineFile> _items;

        public IEnumerable<MachineFile> Items
        {
            get
            {
                return _items.Where(a => string.IsNullOrEmpty(Search) || a.ToString().ToLower().Contains(Search.ToLower())).ToList();
            }

            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                OnPropertyChanged();
                OnPropertyChanged("Items");
            }
        }


        public ItemsListDataContext()
        {
            Items = new List<MachineFile>();
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
        }
    }
}
