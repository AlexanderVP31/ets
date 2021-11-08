using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _employeeApplication.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpGet("GetAsync/{employeeId}")]
        public async Task<IActionResult> GetAsync(string employeeId)
        {
            var response = await _employeeApplication.GetAsync(employeeId);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto is null)
                return BadRequest();

            var response = await _employeeApplication.InsertAsync(employeeDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto is null)
                return BadRequest();

            var response = await _employeeApplication.UpdateAsync(employeeDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("DeleteAsync/{employeeId}")]
        public async Task<IActionResult> DeleteAsync(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
                return BadRequest();

            var response = await _employeeApplication.DeleteAsync(employeeId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
