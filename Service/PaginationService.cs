
using MovieWeb.Models;

namespace MovieWeb.Service
{
    public class PaginationServic<T> : IPaginationService<T> where T : class
    {
        public IEnumerable<T> GetCurrentPage(IEnumerable<T> list, int page)
        {
            var totalPerPage = Pagination<T>.TotalPerPage;
            int itemToSkip = page > 1 ? (page *  totalPerPage) - totalPerPage : 0;
            return list.Skip(itemToSkip).Take(totalPerPage);
        }
    }
}
