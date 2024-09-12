
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Data;

namespace MovieWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private ILogger _logger;
        public Repository(ApplicationDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            try 
            {
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            SaveChanges();
        }
    }
}
