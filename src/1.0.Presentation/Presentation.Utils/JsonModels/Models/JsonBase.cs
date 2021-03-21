using System.Collections.Generic;

namespace Presentation.Utils.JsonModels.Models
{
    public abstract class JsonBase
    {
        public List<string> _errors;

        public ICollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}