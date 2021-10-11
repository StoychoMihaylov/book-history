namespace BookHistory.App.Controllers
{
    using BookHistory.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> logger;
        private readonly IAuthorService authorService;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {
            this.logger = logger;
            this.authorService = authorService;
        }

        [HttpGet]
        [Route("authors")]
        public async Task<IActionResult> GetListOfAuthorNames()
        {
            var authorNames = await this.authorService.GetListOfAuthorNames();
            return StatusCode(200, authorNames);
        }
    }
}
