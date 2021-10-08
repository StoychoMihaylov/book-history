namespace BookHistory.App.Controllers
{
    using BookHistory.Models.BindingModels;
    using BookHistory.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly IBookService bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> CreateNewBook(BookBindingModel bookBm)
        {
            Guid bookId;

            try
            {
                bookId = await this.bookService.CreateNewBook(bookBm);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Method: {Methid}", nameof(CreateNewBook));
                return StatusCode(400);
            }

            return StatusCode(201, bookId);
        }
    }
}
