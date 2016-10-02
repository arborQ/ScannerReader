using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ScanReader.EventHandlers
{
    public interface IScanerHandler
    {
        void OnInputEnter(object sender, KeyEventArgs e);
    }

    public class ScanerHandler : IScanerHandler
    {
        public ScanerHandler()
        {
            //uiElement.OnKeyDown += (e) => { }
        }

        public void OnInputEnter(object sender, KeyEventArgs e)
        {

        }
    }
}
