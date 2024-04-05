namespace BlogApi.Models.Tag
{
    /// <summary>
    /// Обновление тега DTO
    /// </summary>
    public class TagUpdateDto
    {
        /// <summary>
        /// Код тега
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификаторы постов
        /// </summary>
        public int[] Posts { get; set; }
    }
}
