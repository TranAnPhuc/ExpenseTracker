using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.DTOs;
using ExpenseManager.API.DTOs.Category;
using ExpenseManager.API.Models;
using ExpenseManager.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _service.GetAllAsync();
            return Ok(ApiResponse<List<Category>>.Ok(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category= await _service.GetByIdAsync(id);

            return Ok(ApiResponse<Category>.Ok(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            var created = await _service.CreateAsync(category);
            return Created($"/api/categories/{category.Id}",ApiResponse<Category>.Ok(created,"Tạo danh mục thành công"));
        }
    }
}