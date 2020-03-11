using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace NETCoreErrorHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private IEnumerable<Book> _books = new List<Book>
          {
            new Book()
            {
              Id = 1,
              Name = "Book 1",
              RetailPrice = 19.99M
            },
            new Book()
            {
              Id = 2,
              Name = "Book 2",
              RetailPrice = 29.99M
            },
          };

        [HttpGet]
        public Book GetById(int id)
            {
            var book = _books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                throw new EntityNotFoundException(nameof(Book), id);
            }
            return book;
        }
    }
}