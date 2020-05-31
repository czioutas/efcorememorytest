using efcorememorytest.Data;
using efcorememorytest.Repositories;
using System.Threading.Tasks;

namespace efcorememorytest.Entities
{
    public class DbContextRepository<ENTITY> : IRepository<ENTITY> where ENTITY : class
    {
        private bool disposedValue;

        public ProjectDbContext _context { get; set; }

        public DbContextRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public void Add(ENTITY entity)
        {
            _context.Add(entity);
        }

        public void Delete(ENTITY entity)
        {
            throw new System.NotImplementedException();
        }

        public void Detach(ENTITY entity)
        {
            throw new System.NotImplementedException();
        }

        public ENTITY Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ENTITY> GetAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _context = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}