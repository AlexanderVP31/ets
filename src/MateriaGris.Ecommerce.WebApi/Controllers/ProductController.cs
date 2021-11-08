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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _productApplication.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpGet("GetAsync/{productId}")]
        public async Task<IActionResult> GetAsync(string productId)
        {
            var response = await _productApplication.GetAsync(productId);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] ProductDto productDto)
        {
            if (productDto is null)
                return BadRequest();

            var response = await _productApplication.InsertAsync(productDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductDto productDto)
        {
            if (productDto is null)
                return BadRequest();

            var response = await _productApplication.UpdateAsync(productDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("DeleteAsync/{productId}")]
        public async Task<IActionResult> DeleteAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                return BadRequest();

            var response = await _productApplication.DeleteAsync(productId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}