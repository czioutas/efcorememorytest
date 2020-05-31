using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using efcorememorytest.Data;
using efcorememorytest.Entities;
using efcorememorytest.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoreLinq;

namespace efcorememorytest
{
    public class TestService : IDisposable
    {
        private readonly ILogger<TestService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly Fixture _fixture;
        private bool disposedValue;

        public TestService(ILogger<TestService> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _fixture = new Fixture();
        }

        public async Task WorkAsync()
        {
            Console.WriteLine("Started dummy data generation");

            // save them in batches
            int batch = 1000;

            for (var i = 0; i < 10; i++)
            {
                await DealWithBatchAsync();
            }
        }

        private async Task DealWithBatchAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            using (var _context = (ProjectDbContext)scope.ServiceProvider.GetRequiredService(typeof(ProjectDbContext)))
            using (IRepository<TestModel> _repository = new DbContextRepository<TestModel>(_context))
            {
                for (var i = 0; i < 1000; i++)
                {
                    _repository.Add(_fixture.Build<TestModel>()
                                            .With(x => x.Id, 0)
                                            .With(x => x.Nested1TestModel, (_fixture.Build<Nested1TestModel>().With(x => x.Id, 0).Create()))
                                            .Create()
                                        );
                }

                await _repository.SaveAsync(); // final save for items outside of the batch
            }

            Console.WriteLine("Worked on 1k");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}