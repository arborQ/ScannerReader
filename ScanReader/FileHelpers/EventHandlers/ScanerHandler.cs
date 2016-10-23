using FileHelpers.EventHandlers.CodeHandlers;
using FileHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileHelpers.EventHandlers
{
    public interface IScanerHandler
    {
        void InputTriggered(Key key);
    }

    public class ScanerHandler : IScanerHandler
    {
        private string InputText { get; set; }

        private ICodeHandler[] _codeHandlers;

        public ScanerHandler(Action<string> onCodeEntered = null, Action<string> onDataNoEntered = null)
        {
            _codeHandlers = new[] {
                new CodeHandler(onCodeEntered) as ICodeHandler,
                new DateNoHandler(onDataNoEntered) as ICodeHandler
            };
        }

        public void InputTriggered(Key key)
        {
            if (key == Key.Enter)
            {
                HandleNewCode(InputText);
                InputText = string.Empty;
            }
            else
            {
                InputText += InputHelper.ToChar(key);
            }

             HandleNewCode("20160808-00520#53A02RH0H");
        }

        private void HandleNewCode(string code)
        {
            foreach(var handler in _codeHandlers)
            {
                handler.ParseInputAndTrigger(code);
            }
        }
    }
}
