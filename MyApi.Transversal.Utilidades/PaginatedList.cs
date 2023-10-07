namespace MyApi.Transversal.Utilidades
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int Draw { get; set; }
        public List<T> Result { get; set; } = new List<T>();

        public PaginatedList(List<T> items, int count, int currentPage, int pageSize, int draw = 0)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            Draw = draw;
            Result.AddRange(items);
        }

        public PaginatedList()
        {

        }
    }

    public static class PaginatedListHelper
    {

        public const int DefaultPageSize = 10;
        public const int DefaultCurrentPage = 1;

        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> source, int currentPage, int pageSize, int draw = 0)
        {
            var count = source.Count();
            if (currentPage == 0 || pageSize == 0)
            {
                return new PaginatedList<T>(source.ToList(), count, currentPage, pageSize);
            }
            currentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
            pageSize = pageSize > 0 ? pageSize : DefaultPageSize;

            var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, currentPage, pageSize, draw);
        }
    }
}
