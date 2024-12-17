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
        public async Task<IActionResult> AcceptBook(BookDTO book)
        {
            if (await BookService.AcceptBook(book.Title))
            {
                return Ok("Book Accepted");
            }
            return BadRequest("Book not accepted. Maybe wrong title?");
        }
    }
}
