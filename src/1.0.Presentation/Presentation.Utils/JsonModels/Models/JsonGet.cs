using System.Collections.Generic;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Validators;

namespace Presentation.Utils.JsonModels.Models
{
    public class JsonGet
    {
        public int Id { get; set; }
        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new JsonGetValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    Errors.Add(error.ErrorMessage);
                }

                throw new InputJsonException(ExceptionMessages.EXC014(), Errors);
            }

            return true;
        }
    }
}