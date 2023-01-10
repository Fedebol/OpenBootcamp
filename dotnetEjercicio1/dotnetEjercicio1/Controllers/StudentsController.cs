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
    public class StudentsController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        // Service
        private readonly IStudentsService _studentsService;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(UniversityDBContext context, IStudentsService studentsService, ILoggerFactory loggerFactory, ILogger<StudentsController> logger)
        {
            _context = context;
            _studentsService = studentsService;
            _loggerFactory = loggerFactory;
            _logger = logger;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogWarning($"{nameof(StudentsController)} - {nameof(GetStudents)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsController)} - {nameof(GetStudents)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsController)} - {nameof(GetStudents)} - Critical Level Log");
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(StudentsController)} - {nameof(GetStudents)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsController)} - {nameof(GetStudents)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsController)} - {nameof(GetStudents)} - Critical Level Log");

            return student;
        }

// PUT: api/Students/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            _logger.LogWarning($"{nameof(StudentsController)} - {nameof(PutStudent)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsController)} - {nameof(PutStudent)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsController)} - {nameof(PutStudent)} - Critical Level Log");

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            _logger.LogWarning($"{nameof(StudentsController)} - {nameof(PostStudent)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsController)} - {nameof(PostStudent)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsController)} - {nameof(PostStudent)} - Critical Level Log");

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Critical Level Log");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
