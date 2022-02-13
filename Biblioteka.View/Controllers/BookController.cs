using Biblioteka.Core;
using Biblioteka.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.View.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult AddBook([FromBody] AddBookDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _bookServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public ActionResult GetList([FromBody] string title)
        {
            var books = _bookServices.GetBooks(title);
            return Ok(books);
        }

        //[HttpGet("{title}")]
        //[AllowAnonymous]
        //public ActionResult GetList([FromRoute] string title)
        //{
        //    var books = _bookServices.GetBooks(title);
        //    return Ok(books);
        //}


        [HttpPost("{index}")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveFromList([FromRoute] int index)
        {
            _bookServices.Remove(index);
            return Ok();
        }
    }
}
