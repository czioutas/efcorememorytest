using efcorememorytest.Data;
using efcorememorytest.Entities;

namespace efcorememorytest.Repositories
{
    public class TestModelRepository : DbContextRepository<TestModel>
    {
        public TestModelRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}