namespace BookHistory.App.Controllers
{
    using BookHistory.Models.BindingModels;
    using BookHistory.Models.ViewModels;
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

        [HttpGet]
        [Route("book/{id}")]
        public async Task<IActionResult> GetBookDetails(Guid id)
        {
            GetBookDetailsViewModel model;

            try
            {
                model = await this.bookService.GetBookDetails(id);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Method: {Method}", nameof(GetBookDetails));
                return StatusCode(400, ex.Message);
            }

            return StatusCode(200, model);
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> CreateNewBook(CreateBookBindingModel bookBm)
        {
            Guid bookId;

            try
            {
                bookId = await this.bookService.CreateNewBook(bookBm);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Method: {Method}", nameof(CreateNewBook));
                return StatusCode(400, ex.Message);
            }

            return StatusCode(201, bookId);
        }

        [HttpPut]
        [Route("book")]
        public async Task<IActionResult> EditBook(EditBookBindingModel bookBm)
        {
            try
            {
                await this.bookService.EditBook(bookBm);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Method: {Method}", nameof(EditBook));
                return StatusCode(400, ex.Message);
            }

            return StatusCode(204);
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetListOfBooks()
        {        
            var books = await this.bookService.GetListOfBooks();
            return StatusCode(200, books);
        }
    }
}
