using System.Collections.Generic;
using ApiAspnetCoreEfCore.Models;
using ApiAspnetCoreEfCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiAspnetCoreEfCore.Controllers
{    
    [Route("/api/v1/Home")]
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;

        public HomeController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public IActionResult Add([FromBody]Product produto)
        {
            _repository.Create(produto);

            return Ok(produto);
        }
    }
}