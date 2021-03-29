using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Interfaces;
using Presentation.Utils.JsonModels.Models;
using Presentation.Utils.JsonModels.Models.ClinicalUnitController;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils.Messages;
using Presentation.Utils;
using Domain.Exceptions;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicalUnitController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IClinicalUnitApplicationService applicationService;
    
        public ClinicalUnitController(IClinicalUnitApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        [Authorize(Roles = "2")]
        public ActionResult<string> Get([FromBody] JsonGet inputJson)
        {
            try
            {
                inputJson.Validate();

                var ClinicalUnit = applicationService.GetClinicalUnitById(inputJson.Id);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),ClinicalUnit));
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(InputJsonException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public ActionResult<string> Post([FromBody] JsonPost inputJson)
        {
            try
            {
                inputJson.Validate();

                ClinicalUnitDTO ClinicalUnitDTO = inputJson.JsonPostToDTO();

                var ClinicalUnit = applicationService.InsertClinicalUnit(ClinicalUnitDTO);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),ClinicalUnit));
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(InputJsonException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        /*
        [HttpPost]
        public ActionResult<string> Post([FromBody] JsonPost inputJson)
        {
            try
            {
                inputJson.Validate();

                ClinicalUnitDTO ClinicalUnitDTO = inputJson.JsonPostToDTO();

                var ClinicalUnit = applicationService.InsertClinicalUnit(ClinicalUnitDTO);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),ClinicalUnit));
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(InputJsonException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        */
    }
}