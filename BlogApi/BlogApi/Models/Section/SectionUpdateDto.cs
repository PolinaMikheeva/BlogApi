namespace BlogApi.Models.Section
{
    /// <summary>
    /// Обновление раздела DTO
    /// </summary>
    public class SectionUpdateDto
    {
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
        public int[] Posts { get; set; }
    }
}
