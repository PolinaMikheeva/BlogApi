namespace BlogApi.Models.User
{
    /// <summary>
    /// Обновление пользователя DTO
    /// </summary>
    public class UserUpdateDto
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
