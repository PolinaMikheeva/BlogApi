using BlogApi.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities
{
    /// <summary>
    /// Пост
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор поста
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название поста
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание поста
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Краткое описание поста
        /// </summary>
        public string MinDescription { get; set; }

        /// <summary>
        /// Просмотры
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Время чтения поста
        /// </summary>
        public int TimeReading { get; set; }

        /// <summary>
        /// Сложность
        /// </summary>
        public string Complexity { get; set; }

        /// <summary>
        /// Автор поста
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Раздел
        /// </summary>
        public int SectionId { get; set; }
        public Section Section { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public List<Tag> Tags { get; set; }
    }
}
