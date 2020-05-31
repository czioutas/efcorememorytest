using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using efcorememorytest.Data;
using efcorememorytest.Entities;
using efcorememorytest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoreLinq;

namespace efcorememorytest.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        //private readonly IRepository<TestModel> _repository;
        private readonly IServiceProvider _serviceProvider;

        private readonly Fixture _fixture;

        public DefaultController(ILogger<DefaultController> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _fixture = new Fixture();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //HttpContext.Response.RegisterForDispose(_repository);
            // generate random entites
            IList<TestModel> _testModelsList = new List<TestModel>();

            Console.WriteLine("Started dummy data generation");
            for (var i = 0; i < 100000; i++)
            {
                _testModelsList.Add(_fixture.Build<TestModel>()
                                        .With(x => x.Id, 0)
                                        .With(x => x.Nested1TestModel, (_fixture.Build<Nested1TestModel>().With(x => x.Id, 0).Create()))
                                        .Create()
                                    );

                if (i % 10000 == 0 && i > 0)
                {
                    Console.WriteLine($"Created #{i} dummy data");
                }
            }

            // save them in batches
            int batch = 1000;

            IEnumerable<IEnumerable<TestModel>> batches = _testModelsList.Batch(batch);

            foreach (IEnumerable<TestModel> _batch in batches)
            {
                await DealWithBatchAsync(_batch);
            }

            return Ok(); // exit
        }

        private async Task DealWithBatchAsync(IEnumerable<TestModel> elements)
        {
            using (var scope = _serviceProvider.CreateScope())
            using (var _context = (ProjectDbContext)scope.ServiceProvider.GetRequiredService(typeof(ProjectDbContext)))
            using (IRepository<TestModel> _repository = new DbContextRepository<TestModel>(_context))
            {
                foreach (TestModel _tm in elements)
                {
                    _repository.Add(_tm);
                }

                await _repository.SaveAsync(); // final save for items outside of the batch
            }
        }
    }
}