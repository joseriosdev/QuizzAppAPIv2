using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
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
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryHandler;

        public CategoryController(ICategoryRepository category)
        {
            ArgumentNullException.ThrowIfNull(category);
            _categoryHandler = category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(
            [FromBody] Category category)
        {
            var result = await _categoryHandler
                .CreateCategoryAsync(category);

            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(CategoryDTO))]
        public async Task<ActionResult<CategoryDTO>> GetCategory(
        int id, CancellationToken cancellationToken)
        {
            var result = await _categoryHandler
                .RetrieveCategory(id, cancellationToken);

            if (result.IsT0)
            {
                return Ok(result.AsT0);
            }

            return result.HandleError(this);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryForUpsert), 201)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<CategoryForUpsert>> PostCategory(
            [FromBody] CategoryForUpsert category, CancellationToken cancellationToken)
        {
            var result = await _categoryHandler
                .CreateCategory(category, cancellationToken);
            if (result.IsT0)
            {
                var resourceUrl = Url.Action(
                    "GetCategory",
                    "Categories",
                    new { result.AsT0.Id, cancellationToken }, Request.Scheme);
                var responseCategory = result.AsT0.Adapt<CategoryForUpsert>();
                return Created(resourceUrl!, responseCategory);
            }

            return result.HandleError(this);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryForDisplay), 200)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<CategoryForDisplay>> PutCategory(
            int id, [FromBody] CategoryForUpsert category, CancellationToken cancellationToken)
        {
            var result = await _categoryHandler
                .UpdateCategory(id, category, cancellationToken);
            if (result.IsT0)
            {
                return Ok(result.AsT0);
            }

            return result.HandleError(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteCategory(
            int id, CancellationToken cancellationToken)
        {
            var result = await _categoryHandler
                .DeleteCategory(id, cancellationToken);
            if (result.IsT0)
            {
                return NoContent();
            }

            return result.HandleError(this);
        }
    }
}
