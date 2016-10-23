using System.Windows;

namespace ScanerAdministrator.Models
{
    public class ScenEntry
    {
        public string DataNo { get; set; }
        public string SerialNumber { get; set; }
        public string PhotoPath { get; set; }

        public string DisplayName { get { return string.Format("{0}#{1}", DataNo, SerialNumber); } }
        public bool IsSelected { get; set; }
        public bool HasPhoto
        {
            get
            {
                return !string.IsNullOrEmpty(PhotoPath);
            }
        }
    }
}
