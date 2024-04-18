namespace BlogApi.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Пагинация
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="page">Номер страницы</param>
        /// <param name="count">Количество элементов на странице</param>
        /// <returns></returns>
        public static IQueryable<T> Pagination<T> (this IQueryable<T> query, int page = 1, int count = 15)
        {
            return query.Skip((page - 1) * count).Take(count);
        }
    }
}
