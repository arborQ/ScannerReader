using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanerAdministrator.Models
{
    public class ItemsListDataContext
    {
        public IEnumerable<ScenEntry> Items { get; set; }

        public ItemsListDataContext()
        {
            Items = new[] { new ScenEntry {
                DataNo = "dsadad", SerialNumber = "dsads"
            } };
        }
    }
}
