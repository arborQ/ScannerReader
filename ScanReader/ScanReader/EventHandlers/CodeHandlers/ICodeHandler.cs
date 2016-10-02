using System;

namespace ScanReader.EventHandlers.CodeHandlers
{
    public interface ICodeHandler
    {
        string ParseInput(string input);
        string ParseInputAndTrigger(string input);
    }
}
