using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Api.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            ArgumentNullException.ThrowIfNull(categoryService);
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> PostCategory([FromBody] CategoryDTO category, CancellationToken cToken)
        {
            Category result = await _categoryService.CreateAsync(category, cToken);
            return CreatedAtAction(nameof(PostCategory), result);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(typeof(Category), 200)]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<ActionResult<Category>> GetSingleCategory(int id, CancellationToken cToken)
        {
            Category? result = await _categoryService.FindByIdAsync(id, cToken);

            if (result is null)
                return Ok("No matches");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<CategoryDTO>> PutCategory(
            int id, [FromBody] CategoryDTO category, CancellationToken cToken)
        {
            var result = await _categoryService.UpdateByIdAsync(id, category, cToken);
            // discriminated union - functional programming
            //result.AsT0;

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteCategory(int id, CancellationToken cToken)
        {
            var result = await _categoryService.DeleteByIdAsync(id, cToken);
            return NoContent();
        }
    }
}
