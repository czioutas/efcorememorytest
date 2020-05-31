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
        private readonly TestService _testService;

        public DefaultController(ILogger<DefaultController> logger, TestService tesstService)
        {
            _logger = logger;
            _testService = tesstService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            HttpContext.Response.RegisterForDispose(_testService);
            await _testService.WorkAsync();
            return Ok(); // exit
        }
    }
}