using Biblioteka.Core;
using Biblioteka.Core.DTOs.RentalDTOs;
using Biblioteka.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.View
{
    [Route("api/rental")]
    [ApiController]
    [Authorize(Roles = "Admin,Librarian")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalServices _rentalServices;

        public RentalController(IRentalServices rentalServices)
        {
            _rentalServices = rentalServices;
        }

        [HttpPost("rent")]
        public ActionResult AddRental([FromBody] AddRentalDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rental = _rentalServices.Add(dto);
            return Ok(rental);
        }

        [HttpPost("return")]
        public ActionResult Return([FromBody] ReturnDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _rentalServices.Return(dto);
            return Ok();
        }
    }
}
