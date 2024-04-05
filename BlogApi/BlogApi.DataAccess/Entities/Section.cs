using BlogApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.DataAccess.Entities
{
    /// <summary>
    /// Раздел
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Код раздела
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название раздела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public List<Post> Posts { get; set; }
    }
}
