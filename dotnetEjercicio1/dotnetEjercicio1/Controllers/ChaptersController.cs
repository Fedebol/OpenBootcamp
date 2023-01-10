using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace dotnetEjercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ChaptersController> _logger;

        public ChaptersController(UniversityDBContext context, ILoggerFactory loggerFactory, ILogger<ChaptersController> logger)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = logger;
        }

        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {
            _logger.LogWarning($"{nameof(ChaptersController)} - {nameof(GetChapters)} - Warning Level Log");
            _logger.LogError($"{nameof(ChaptersController)} - {nameof(GetChapters)} - Error Level Log");
            _logger.LogCritical($"{nameof(ChaptersController)} - {nameof(GetChapters)} - Critical Level Log");

            return await _context.Chapters.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return chapter;
        }

// PUT: api/Chapters/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            if (id != chapter.Id)
            {
                return BadRequest();
            }

            _logger.LogWarning($"{nameof(ChaptersController)} - {nameof(PutChapter)} - Warning Level Log");
            _logger.LogError($"{nameof(ChaptersController)} - {nameof(PutChapter)} - Error Level Log");
            _logger.LogCritical($"{nameof(ChaptersController)} - {nameof(PutChapter)} - Critical Level Log");

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();
            _logger.LogWarning($"{nameof(ChaptersController)} - {nameof(PostChapter)} - Warning Level Log");
            _logger.LogError($"{nameof(ChaptersController)} - {nameof(PostChapter)} - Error Level Log");
            _logger.LogCritical($"{nameof(ChaptersController)} - {nameof(PostChapter)} - Critical Level Log");

            return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"{nameof(ChaptersController)} - {nameof(DeleteChapter)} - Warning Level Log");
            _logger.LogError($"{nameof(ChaptersController)} - {nameof(DeleteChapter)} - Error Level Log");
            _logger.LogCritical($"{nameof(ChaptersController)} - {nameof(DeleteChapter)} - Critical Level Log");

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapters.Any(e => e.Id == id);
        }
    }
}
