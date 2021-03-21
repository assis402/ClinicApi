using System;
using System.Collections.Generic;

namespace Presentation.Utils.JsonModels.Exceptions
{
    public class InputJsonException : Exception{

        internal List<string> _errors;
        
        public IReadOnlyList<string> Errors => _errors;

        public InputJsonException()
        {}

        public InputJsonException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public InputJsonException(string message) : base(message)
        { }

        public InputJsonException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}