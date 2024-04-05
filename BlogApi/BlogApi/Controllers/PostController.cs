using BlogApi.DataAccess;
using BlogApi.Entities;
using BlogApi.Models.Post;
using BlogApi.Models.Section;
using BlogApi.Models.Tag;
using BlogApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения всех постов
        /// </summary>
        /// <returns>Возвращает список всех постов</returns>
        [HttpGet]
        public async Task<List<PostDto>> GetPosts()
        {
            return await _context.Posts.Include(p => p.User).Select(p => new PostDto()
            {
                Id = p.Id,
                Title = p.Title,
                UserFullName = p.User.FullName,
                Description = p.Description,
                Complexity = p.Complexity,
                MinDescription = p.MinDescription,
                TimeReading = p.TimeReading,
                Views = p.Views,
                SectionName = p.Section.Name,

                Section = new SectionDto()
                {
                    Name = p.Section.Name,
                    Code = p.Section.Code
                },

                User = new UserDto()
                {
                    FullName = p.User.FullName,
                    Email = p.User.Email,
                },

                Tags = p.Tags.Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code
                }).ToList()

            }).ToListAsync();
        }

        /// <summary>
        /// Метод для получения поста по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поста</param>
        /// <returns>Возвращает один пост</returns>
        [HttpGet("{id}")]
        public async Task<PostDto> GetPostById([FromRoute] int id)
        {
            PostDto? post = _context.Posts.Include(t => t.Tags).Select(p => new PostDto()
            {
                Id = p.Id,
                Title = p.Title,
                UserFullName = p.User.FullName,
                Description = p.Description,
                Complexity = p.Complexity,
                MinDescription = p.MinDescription,
                TimeReading = p.TimeReading,
                Views = p.Views,
                SectionName = p.Section.Name,

                Section = new SectionDto()
                {
                    Name = p.Section.Name,
                    Code = p.Section.Code
                },

                User = new UserDto()
                {
                    FullName = p.User.FullName,
                    Email = p.User.Email,
                },

                Tags = p.Tags.Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code
                }).ToList()

            }).FirstOrDefault(post => post.Id == id);
            return post;
        }

        /// <summary>
        /// Метод для создания поста
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PostCreateDto>> CreatePost(PostCreateDto post)
        {
            var newPost = new Post()
            {
                Title = post.Title,
                Description = post.Description,
                MinDescription = post.MinDescription,
                Complexity = post.Complexity,
                TimeReading = post.TimeReading,
                Views = post.Views,

                UserId = post.UserId,
                SectionId = post.SectionId
            };

            if (post.Tags.Count() > 0)
                newPost.Tags = await _context.Tags.Where(t => post.Tags.Contains(t.Id)).ToListAsync();

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return post;
        }

        /// <summary>
        /// Метод для обновления поста по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPut("{id}")]
        public async Task<ActionResult<PostUpdateDto>> UpdatePost([FromRoute] int id, PostUpdateDto post)
        {
            var currentPost = _context.Posts.Include(t => t.Tags).SingleOrDefault(post => post.Id == id) ?? throw new Exception("Post с таким Id не найден");

            currentPost.Description = post.Description;
            currentPost.Views = post.Views;
            currentPost.Title = post.Title;
            currentPost.Complexity = post.Complexity;
            currentPost.MinDescription = post.MinDescription;
            currentPost.TimeReading = post.TimeReading;
            currentPost.UserId = post.UserId;
            currentPost.SectionId = post.SectionId;

            if (post.Tags.Count() > 0)
                currentPost.Tags = await _context.Tags.Where(t => post.Tags.Contains(t.Id)).ToListAsync();
            else if (currentPost.Tags?.Count > 0)
                currentPost.Tags.Clear();

            _context.Update(currentPost);
            await _context.SaveChangesAsync();

            return post;
        }

        /// <summary>
        /// Метод для удаления поста по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var postDelete = _context.Posts.SingleOrDefault(post => post.Id == id) ?? throw new Exception("Post с таким Id не найден");

            _context.Posts.Remove(postDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
