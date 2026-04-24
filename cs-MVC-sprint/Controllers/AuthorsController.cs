using cs_MVC_sprint.Models;
using cs_MVC_sprint.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_MVC_sprint.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        public IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet ("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost]

        public IActionResult AddAuthor(Author author)
        {
            var newAuthor = _authorService.AddAuthor(author);
            return CreatedAtAction(nameof(GetAllAuthors), new {Id = newAuthor.Id}, newAuthor);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteAuthorById(int id)
        {
            var deleteAuthor = _authorService.DeleteAuthorById(id);
            return NoContent();
        }
    }
}
