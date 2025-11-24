using AutoMapper;
using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Application.Interfaces;
using CafremaApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceController : ControllerBase
    {
        private readonly IApplianceService _applianceService;
        private readonly IMapper _mapper;

        public ApplianceController(IApplianceService applianceService, IMapper mapper)
        {
            _applianceService = applianceService;
            _mapper = _mapper;
        }

        [HttpGet]
        [Route("GetAllAppliances")] 
        public async Task<IActionResult> GetAllAppliances()
        {
            var appliances = await _applianceService.GetAllAppliances();
            return Ok(appliances);
        }

        [HttpGet]
        [Route("GetApplianceById")]
        public async  Task<IActionResult> GetApplianceById(Guid id)
        {
            var appliance = await _applianceService.GetApplianceItem(id);
            return Ok(appliance);
        }

        [HttpDelete]
        [Route("DeleteAppliance")]
        public async Task<IActionResult> DeleteAppliance(Guid id)
        {
            var deleted = await _applianceService.DeleteApplianceItem(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
        
        [HttpPost]
        [Route("CreateAppliance")]
        public async Task<IActionResult> CreateAppliance([FromBody] CreateApplianceDto appliance)
        {
            await _applianceService.CreateApplianceItem(appliance);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateAppliance")]
        public async Task<IActionResult> UpdateAppliance([FromBody] ApplianceDto appliance)
        {
            await _applianceService.UpdateApplianceItem(appliance);
            return Ok();
        }

    }
}
