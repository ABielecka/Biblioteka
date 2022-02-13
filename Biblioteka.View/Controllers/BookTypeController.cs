using Biblioteka.Core;
using Biblioteka.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Biblioteka.View.Controllers
{
    [Route("api/booktype")]
    [ApiController]
    public class BookTypeController : ControllerBase
    {
        private readonly IBookTypeServices _bookTypeServices;

        public BookTypeController(IBookTypeServices bookTypeServices)
        {
            _bookTypeServices = bookTypeServices;
        }

        [HttpGet]
        public ActionResult<ICollection<BookTypeDTO>> GetAll()
        {
            var bookTypesDTOs = _bookTypeServices.GetAll();
            return Ok(bookTypesDTOs);
        }

        [HttpPost]
        public ActionResult AddBookType([FromBody] AddBookTypeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _bookTypeServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }

        [HttpPut("{type}")]
        public ActionResult Update([FromBody] UpdateBookTypeDTO dto, [FromRoute] string type)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _bookTypeServices.Update(type, dto);
            if (!isUpdated) return NotFound();
            else
            {
                return Ok();
            }
        }
    }
}
