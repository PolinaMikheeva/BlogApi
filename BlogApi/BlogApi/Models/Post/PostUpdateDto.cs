namespace BlogApi.Models.Post
{
    /// <summary>
    /// Обновление поста DTO
    /// </summary>
    public class PostUpdateDto
    {
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
        /// Идентификатор автора
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Идентификаторы тегов
        /// </summary>
        public int[] Tags { get; set; }
    }
}
