using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Interfaces;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicUnitController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;

        private readonly IClinicUnitApplicationService applicationService;

        public ClinicUnitController(IClinicUnitApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<string> Get(int ClinicUnitId)
        {
            return Ok(applicationService.GetClinicUnitById(ClinicUnitId));
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] ClinicUnitDTO clinicUnitDTO)
        {
            applicationService.InsertClinicUnit(clinicUnitDTO);
            return Ok("Unidade clínica cadastrada com sucesso!");
        }
    }
}