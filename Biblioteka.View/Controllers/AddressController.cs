using Biblioteka.Core;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.View
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] AddAddressDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _addressServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }

        [HttpPut("{City}/{Street}/{Number}/{PostalCode}")]
        public ActionResult Update([FromBody] UpdateAddressDTO dto, [FromRoute] string City, [FromRoute] string Street,
            [FromRoute] int Number, [FromRoute] string PostalCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _addressServices.Update(City, Street, Number, PostalCode, dto);
            if (!isUpdated) return NotFound();
            else
            {
                return Ok();
            }
        }
    }
}
