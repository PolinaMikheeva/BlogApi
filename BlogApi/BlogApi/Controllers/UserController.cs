using BlogApi.DataAccess;
using BlogApi.Entities;
using BlogApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserDto>> GetUsers()
        {
            return await _context.Users.Select(u => new UserDto()
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
            }).ToListAsync();
        }

        /// <summary>
        /// Метод для получения пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("{id}")]
        public async Task<UserDto> GetUserById([FromRoute] int id)
        {
            return await _context.Users.Select(u => new UserDto()
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
            }).SingleOrDefaultAsync(user => user.Id == id) ?? throw new Exception();
        }

        /// <summary>
        /// Метод для создания пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> CreateUser(UserCreateDto user)
        {
            var newUser = new User()
            {
                FullName = user.FullName,
                Email = user.Email
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Метод для обновления пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserUpdateDto>> UpdateUser([FromRoute] int id, UserUpdateDto user)
        {
            var currentUser = _context.Users.SingleOrDefault(user => user.Id == id);

            currentUser.FullName = user.FullName;
            currentUser.Email = user.Email;

            await _context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Метод для удаления пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var userDelete = _context.Users.SingleOrDefault(user => user.Id == id);

            _context.Users.Remove(userDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
