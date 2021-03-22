using Application.DTO;
using Presentation.Utils.JsonModels.Validators;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Exceptions;
using System.Collections.Generic;

namespace Presentation.Utils.JsonModels.Models.ClinicalUnitController
{
    public class JsonPost : JsonBase
    {
        public string CompanyName { get; set; }

        public string TaxNumber { get; set; }

        public JsonPost()
        {
        }

        public override bool Validate()
        {
            List<string> errors = new List<string>();
            var validator = new JsonPostValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                throw new InputJsonException(ExceptionMessages.EXC014(), errors);
            }

            return true;
        }

        public ClinicalUnitDTO JsonPostToDTO()
        {
            ClinicalUnitDTO ClinicalUnitDTO = new ClinicalUnitDTO
            {
                CompanyName = this.CompanyName,
                TaxNumber = this.TaxNumber
            };

            return ClinicalUnitDTO;
        }
   }
}