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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace dotnetEjercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ICoursesService _coursesService;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(UniversityDBContext context, ICoursesService coursesService, ILoggerFactory loggerFactory, ILogger<CoursesController> logger)
        {
            _context = context;
            _coursesService = coursesService;
            _loggerFactory = loggerFactory;
            _logger = logger;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCursos()
        {
            _logger.LogWarning($"{nameof(CoursesController)} - {nameof(GetCursos)} - Warning Level Log");
            _logger.LogError($"{nameof(CoursesController)} - {nameof(GetCursos)} - Error Level Log");
            _logger.LogCritical($"{nameof(CoursesController)} - {nameof(GetCursos)} - Critical Level Log");
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Cursos.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(CoursesController)} - {nameof(GetCursos)} - Warning Level Log");
            _logger.LogError($"{nameof(CoursesController)} - {nameof(GetCursos)} - Error Level Log");
            _logger.LogCritical($"{nameof(CoursesController)} - {nameof(GetCursos)} - Critical Level Log");

            return course;
        }

// PUT: api/Courses/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            _logger.LogWarning($"{nameof(CoursesController)} - {nameof(PutCourse)} - Warning Level Log");
            _logger.LogError($"{nameof(CoursesController)} - {nameof(PutCourse)} - Error Level Log");
            _logger.LogCritical($"{nameof(CoursesController)} - {nameof(PutCourse)} - Critical Level Log");

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Cursos.Add(course);
            await _context.SaveChangesAsync();
            _logger.LogWarning($"{nameof(CoursesController)} - {nameof(PostCourse)} - Warning Level Log");
            _logger.LogError($"{nameof(CoursesController)} - {nameof(PostCourse)} - Error Level Log");
            _logger.LogCritical($"{nameof(CoursesController)} - {nameof(PostCourse)} - Critical Level Log");

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Cursos.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(CoursesController)} - {nameof(DeleteCourse)} - Warning Level Log");
            _logger.LogError($"{nameof(CoursesController)} - {nameof(DeleteCourse)} - Error Level Log");
            _logger.LogCritical($"{nameof(CoursesController)} - {nameof(DeleteCourse)} - Critical Level Log");

            _context.Cursos.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
