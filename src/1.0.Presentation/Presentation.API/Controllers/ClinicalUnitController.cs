using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Interfaces;
using Presentation.Utils.JsonModels.Models;
using Presentation.Utils.JsonModels.Models.ClinicalUnitController;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils;
using Domain.Exceptions;
using System;

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
        public ActionResult<string> Get([FromBody] JsonGet inputJson)
        {
            return Ok(applicationService.GetClinicalUnitById(inputJson.Id));
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] JsonPost inputJson)
        {
            try
            {
                inputJson.Validate();

                ClinicalUnitDTO ClinicalUnitDTO = inputJson.JsonPostToDTO();

                applicationService.InsertClinicalUnit(ClinicalUnitDTO);

                return Ok("Unidade clínica cadastrada com sucesso!");
            }
            catch(DomainException ex)
            {
                return BadRequest();
                //return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(InputJsonException ex)
            {
                return BadRequest();
                //return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return BadRequest();
                //return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}