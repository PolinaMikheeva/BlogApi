using BlogApi.DataAccess;
using BlogApi.DataAccess.Entities;
using BlogApi.Entities;
using BlogApi.Models.Post;
using BlogApi.Models.Section;
using BlogApi.Models.Tag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SectionController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения всех разделов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SectionDto>> GetSections()
        {
            return await _context.Sections.Select(p => new SectionDto()
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,

                Posts = p.Posts.Select(t => new PostDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Complexity = t.Complexity,
                    MinDescription = t.MinDescription,
                    TimeReading = t.TimeReading,
                    Views = t.Views,
                    Date = t.Date,

                    UserFullName = t.User.FullName,
                }).ToList()

            }).ToListAsync();
        }

        /// <summary>
        /// Метод для получения раздела по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SectionDto> GetSectionById([FromRoute] int id)
        {
            SectionDto? section = _context.Tags.Select(p => new SectionDto()
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,

                Posts = p.Posts.Select(t => new PostDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Complexity = t.Complexity,
                    MinDescription = t.MinDescription,
                    TimeReading = t.TimeReading,
                    Views = t.Views,
                    Date = t.Date,

                    UserFullName = t.User.FullName,
                }).ToList()

            }).SingleOrDefault(t => t.Id == id);
            return section;
        }

        /// <summary>
        /// Метод для создания раздела
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SectionCreateDto>> CreateSection(SectionCreateDto section)
        {
            var newSection = new Section()
            {
                Name = section.Name,
                Code = section.Code
            };

            if (section.Posts.Count() > 0)
                newSection.Posts = await _context.Posts.Where(s => section.Posts.Contains(s.Id)).ToListAsync();

            _context.Sections.Add(newSection);
            await _context.SaveChangesAsync();

            return section;
        }

        /// <summary>
        /// Метод для обновления раздела по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPut("{id}")]
        public async Task<ActionResult<SectionUpdateDto>> UpdateSection([FromRoute] int id, SectionUpdateDto section)
        {
            var currentSection = _context.Sections.SingleOrDefault(s => s.Id == id) ?? throw new Exception("Section с таким Id не найден");

            currentSection.Name = section.Name;
            currentSection.Code = section.Code;

            if (section.Posts.Count() > 0)
                currentSection.Posts = await _context.Posts.Where(s => section.Posts.Contains(s.Id)).ToListAsync();
            else if (currentSection.Posts?.Count > 0)
                currentSection.Posts.Clear();

            _context.Update(currentSection);
            await _context.SaveChangesAsync();

            return section;
        }

        /// <summary>
        /// Метод для удаления раздела по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection([FromRoute] int id)
        {
            var sectionDelete = _context.Sections.FirstOrDefault(s => s.Id == id) ?? throw new Exception("Section с таким Id не найден");

            _context.Sections.Remove(sectionDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
