using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;
using dotnetEjercicio1.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace dotnetEjercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ICategoriesServices _categoriesServices;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(UniversityDBContext context, ICategoriesServices categoriesServices, ILoggerFactory loggerFactory, ILogger<CategoriesController> logger)
        {
            _context = context;
            _categoriesServices = categoriesServices;
            _loggerFactory = loggerFactory;
            _logger = logger;   
        }

        // GET: api/Categories
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {

            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            _logger.LogWarning($"{nameof(CategoriesController)} - {nameof(GetCategory)} - Warning Level Log");
            _logger.LogError($"{nameof(CategoriesController)} - {nameof(GetCategory)} - Error Level Log");
            _logger.LogCritical($"{nameof(CategoriesController)} - {nameof(GetCategory)} - Critical Level Log");

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _logger.LogWarning($"{nameof(CategoriesController)} - {nameof(PutCategory)} - Warning Level Log");
            _logger.LogError($"{nameof(CategoriesController)} - {nameof(PutCategory)} - Error Level Log");
            _logger.LogCritical($"{nameof(CategoriesController)} - {nameof(PutCategory)} - Critical Level Log");

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            _logger.LogWarning($"{nameof(CategoriesController)} - {nameof(PostCategory)} - Warning Level Log");
            _logger.LogError($"{nameof(CategoriesController)} - {nameof(PostCategory)} - Error Level Log");
            _logger.LogCritical($"{nameof(CategoriesController)} - {nameof(PostCategory)} - Critical Level Log");

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(CategoriesController)} - {nameof(DeleteCategory)} - Warning Level Log");
            _logger.LogError($"{nameof(CategoriesController)} - {nameof(DeleteCategory)} - Error Level Log");
            _logger.LogCritical($"{nameof(CategoriesController)} - {nameof(DeleteCategory)} - Critical Level Log");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
