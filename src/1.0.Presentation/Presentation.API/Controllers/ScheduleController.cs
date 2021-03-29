using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Interfaces;
using Presentation.Utils.JsonModels.Models;
using Presentation.Utils.JsonModels.Models.ScheduleController;
using Presentation.Utils.JsonModels.Exceptions;
using Presentation.Utils.Messages;
using Presentation.Utils;
using Domain.Exceptions;
using System;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IScheduleApplicationService applicationService;

        public ScheduleController(IScheduleApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<string> Get([FromBody] JsonGet inputJson)
        {
            try
            {
                inputJson.Validate();

                var Schedule = applicationService.GetScheduleById(inputJson.Id);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),Schedule));
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
        public ActionResult<string> Post([FromBody] JsonPost inputJson)
        {
            try
            {
                inputJson.Validate();

                ScheduleDTO ScheduleDTO = inputJson.JsonPostToDTO();

                var Schedule = applicationService.InsertSchedule(ScheduleDTO);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),Schedule));
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

/*
        [HttpPost]
        public ActionResult<string> Post([FromBody] JsonPost inputJson)
        {
            try
            {
                inputJson.Validate();

                ScheduleDTO ScheduleDTO = inputJson.JsonPostToDTO();

                var Schedule = applicationService.InsertSchedule(ScheduleDTO);

                return Ok(Responses.SuccessMessage(InformationMessages.INF001(),Schedule));
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