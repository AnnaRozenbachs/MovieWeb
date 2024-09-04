namespace MovieWeb.Service
{
    public interface IPaginationService<T> where T : class  
    {
        public IEnumerable<T> GetCurrentPage(IEnumerable<T> list, int page);
    }
}
