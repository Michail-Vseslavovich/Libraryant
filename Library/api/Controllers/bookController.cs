using Library.Instruments.DataBase;
using Library.Instruments.Dto;
using Library.Instruments.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Library.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [Authorize(Roles = "1,0")][HttpPost]
        public IActionResult AddNewBook(BookDTO book, byte[] content)
        {
            string file = Encoding.UTF8.GetString(content);           
            if (BookService.FriteBookToTxt(book, file))
            {

                return Ok("Success");
            }
            return BadRequest("something went wrong");
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult> AcceptBook(BookDTO book)
        {
            if (await BookService.AcceptBook(book.Title))
            {
                return Ok("Book Accepted");
            }
            return NotFound("Wrong title");
        }

        [HttpGet]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            (BookDTO book, string text) = await BookService.getBookByTitle(title);
            if (book == null || text == null)
            {
                return Ok(book.Title + book.Description + text);
            }
            return NotFound("NoBookWithSuchTitle");
        }

        [Authorize(Roles ="1")]
        [HttpGet]
        public async Task<IActionResult> GetNotCheckedBooks()
        {
            return Ok(BookService.GetUnsafeBookS());
        }


        [Authorize(Roles ="1")]
        [HttpGet]
        public async Task<IActionResult> GetNotCheckedBookByTitle(string title)
        {
            (BookDTO book, string text) = await BookService.getBookByTitle(title);
            if (book == null || text == null)
            {
                return Ok(book.Title + book.Description + text);
            }
            return NotFound("NoBookWithSuchTitle");
        }
    }
}
