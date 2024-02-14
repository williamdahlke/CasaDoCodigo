using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository <T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbset;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }
    }
}
