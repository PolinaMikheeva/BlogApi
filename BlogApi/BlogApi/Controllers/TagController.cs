using Azure;
using BlogApi.DataAccess;
using BlogApi.Entities;
using BlogApi.Models.Post;
using BlogApi.Models.Tag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения всех тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<TagDto>> GetTags()
        {


            return await _context.Tags.Select(p => new TagDto()
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
                    SectionName = t.Section.Name
                }).ToList()

            }).ToListAsync();
        }

        /// <summary>
        /// Метод для получения тега по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TagDto> GetTagById([FromRoute] int id)
        {
            TagDto? tag = _context.Tags.Select(p => new TagDto()
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
                   SectionName = t.Section.Name
               }).ToList()

            }).SingleOrDefault(t => t.Id == id);
            return tag;
        }

        /// <summary>
        /// Метод для создания тега
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TagCreateDto>> CreateTag(TagCreateDto tag)
        {
            var newTag = new Tag()
            {
                Name = tag.Name,
                Code = tag.Code
            };

            if (tag.Posts.Count() > 0)
                newTag.Posts = await _context.Posts.Where(t => tag.Posts.Contains(t.Id)).ToListAsync();

            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return tag;
        }

        /// <summary>
        /// Метод для обновления тега по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPut("{id}")]
        public async Task<ActionResult<TagUpdateDto>> UpdateTag([FromRoute] int id, TagUpdateDto tag)
        {
            var currentTag = _context.Tags.SingleOrDefault(t => t.Id == id) ?? throw new Exception("Tag с таким Id не найден");

            currentTag.Name = tag.Name;
            currentTag.Code = tag.Code;

            if (tag.Posts.Count() > 0)
                currentTag.Posts = await _context.Posts.Where(t => tag.Posts.Contains(t.Id)).ToListAsync();
            else if (currentTag.Posts?.Count > 0)
                currentTag.Posts.Clear();

            _context.Update(currentTag);
            await _context.SaveChangesAsync();

            return tag;
        }

        /// <summary>
        /// Метод для удаления тега по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            var tagDelete = _context.Tags.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Tag с таким Id не найден");

            _context.Tags.Remove(tagDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
