using System;
using System.Linq;

namespace FileHelpers.EventHandlers.CodeHandlers
{
    public class DateNoHandler : CodeParser, ICodeHandler
    {

        public DateNoHandler(Action<string> hasInputAction) 
            : base(hasInputAction)
        {
        }

        public override string ParseInput(string input)
        {
            var parts = Parts(input);
            if(parts.Count == 2)
            {
                return Parts(input).Last().Replace(" ", string.Empty);
            }
            return null;
        }
              
    }
}
