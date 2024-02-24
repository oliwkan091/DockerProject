using Server.db;
using Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Server.Repository;
using MongoDB.Driver;

namespace Client.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductsRepository _productsRepository;
        public HomeController(ILogger<HomeController> logger, ProductsRepository productsRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository)); 
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
                                                        //TODO co to 
            return await _productsRepository.products.Find(propa => true).ToListAsync();
        }
    }
}
