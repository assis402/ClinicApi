using Application.DTO;
using System.Collections.Generic;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Validators.AuthenticateController;

namespace Presentation.Utils.JsonModels.Models.AuthenticateController
{
    public class JsonPost
    {
        public int ClinicalUnitId { get; set; }

        public string TaxNumber { get; set; }

        public string Password { get; set; }

        public JsonPost()
        {
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new JsonPostValidator();
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

        /*
        public UserDTO JsonPostToDTO()
        {
            UserDTO UserDTO = new UserDTO
            {
                TaxNumber = this.TaxNumber,
                Password = this.Password
            };

            return UserDTO;
        }
        */
   }
}