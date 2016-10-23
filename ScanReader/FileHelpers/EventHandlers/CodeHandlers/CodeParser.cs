using System;
using System.Collections.Generic;
using System.Linq;

namespace FileHelpers.EventHandlers.CodeHandlers
{
    public abstract class CodeParser
    {
        protected Action<string> HasInputAction;
        public CodeParser(Action<string> hasInputAction)
        {
            HasInputAction = hasInputAction;
        }

        public string ParseInputAndTrigger(string input)
        {
            var code = ParseInput(input);
            TriggerAction(code);
            return code;
        }

        public abstract string ParseInput(string input);

        protected void TriggerAction(string input)
        {
            if(HasInputAction != null && input != null)
            {
                HasInputAction(input);
            }
        }

        protected IReadOnlyCollection<string> Parts(string input)
        {
            return (input ?? string.Empty)
                .Split('#')
                .Select(a => a.Trim())
                .ToArray();
        }
    }
}
