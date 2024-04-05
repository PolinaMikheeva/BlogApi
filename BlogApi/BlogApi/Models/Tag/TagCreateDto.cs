namespace BlogApi.Models.Tag
{
    /// <summary>
    /// Создание тега DTO
    /// </summary>
    public class TagCreateDto
    {
        /// <summary>
        /// Код тега
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификаторы постов
        /// </summary>
        public int[] Posts { get; set; }
    }
}
