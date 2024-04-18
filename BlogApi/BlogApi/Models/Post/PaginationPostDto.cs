namespace BlogApi.Models.Post
{
    public class PaginationPostDto
    {
        /// <summary>
        /// Список постов
        /// </summary>
        public List<PostDto> PostsDto { get; set; }

        /// <summary>
        /// Количество страниц со всеми постами
        /// </summary>
        public int TotalPosts { get; set; }
    }
}
