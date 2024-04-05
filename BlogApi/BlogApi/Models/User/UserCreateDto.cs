namespace BlogApi.Models.User
{
    /// <summary>
    /// Создание пользователя DTO
    /// </summary>
    public class UserCreateDto
    {
        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
    }
}
