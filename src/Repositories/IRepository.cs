using System.Threading.Tasks;

namespace efcorememorytest.Repositories
{
    public interface IRepository<ENTITY> where ENTITY : class
    {
        ENTITY Get(long id);

        Task<ENTITY> GetAsync(long id);

        void Add(ENTITY entity);

        void Delete(ENTITY entity);

        void Save();

        void Detach(ENTITY entity);

        Task SaveAsync();
    }
}