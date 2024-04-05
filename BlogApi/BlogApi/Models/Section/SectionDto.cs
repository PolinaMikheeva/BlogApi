using BlogApi.Models.Post;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models.Section
{
    /// <summary>
    /// Раздел DTO
    /// </summary>
    public class SectionDto
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
        public List<PostDto> Posts { get; set; }
    }
}
