using System;
using System.Linq;

namespace ScanReader.EventHandlers.CodeHandlers
{
    public class CodeHandler : CodeParser, ICodeHandler
    {
        public CodeHandler(Action<string> hasInputAction) 
            : base(hasInputAction)
        {
        }

        public override string ParseInput(string input)
        {
            return Parts(input).FirstOrDefault();
        }
    }
}
