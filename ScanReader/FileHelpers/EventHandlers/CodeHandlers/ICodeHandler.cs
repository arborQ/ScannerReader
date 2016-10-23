using System;

namespace FileHelpers.EventHandlers.CodeHandlers
{
    public interface ICodeHandler
    {
        string ParseInput(string input);
        string ParseInputAndTrigger(string input);
    }
}
