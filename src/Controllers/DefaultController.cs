using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using efcorememorytest.Entities;
using efcorememorytest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace efcorememorytest.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IRepository<TestModel> _repository;
        private readonly Fixture _fixture;

        public DefaultController(ILogger<DefaultController> logger, IRepository<TestModel> repository)
        {
            _logger = logger;
            _repository = repository;
            _fixture = new Fixture();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // generate random entites
            IList<TestModel> _testModelsList = new List<TestModel>();

            Console.WriteLine("Started dummy data generation");
            for (var i = 0; i < 10000; i++)
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
            // i think ef supports this out of the box but we do it for some business logic
            int batch = 10000;
            int counter = 0;
            int total = 0;

            foreach (TestModel _tm in _testModelsList)
            {
                _repository.Add(_tm);

                if (counter > 0 && counter % batch == 0)
                {
                    _repository.Save();
                    _logger.LogInformation($"Batch #{counter / batch} [{total / batch}]");
                }

                counter++;
            }

            _repository.Save(); // final save for items outside of the batch

            return Ok(); // exit
        }
    }
}