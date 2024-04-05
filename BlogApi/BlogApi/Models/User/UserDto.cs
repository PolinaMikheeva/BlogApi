namespace BlogApi.Models.User
{
    /// <summary>
    /// Пользователь DTO
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

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
