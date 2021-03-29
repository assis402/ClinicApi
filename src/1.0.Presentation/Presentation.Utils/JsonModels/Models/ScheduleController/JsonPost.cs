using System;
using System.Collections.Generic;
using Application.DTO;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Validators.ScheduleController;

namespace Presentation.Utils.JsonModels.Models.ScheduleController
{
    public class JsonPost
    {
        public DateTime ScheduleDate { get; set; }

        public int PatientId { get; set; }

        public int ClinicalUnitId { get; set; }

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

        public ScheduleDTO JsonPostToDTO()
        {
            ScheduleDTO ScheduleDTO = new ScheduleDTO
            {
                ScheduleDate = this.ScheduleDate,
                PatientId = this.PatientId,
                ClinicalUnitId = this.ClinicalUnitId
            };

            return ScheduleDTO;
        }
   }
}