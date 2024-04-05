using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public List<Post> Posts { get; set; }
    }
}