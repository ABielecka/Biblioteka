using Biblioteka.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteka.View
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _countryServices;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryServices countryServices, ILogger<CountryController> logger)
        {
            _countryServices = countryServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<ICollection<CountryDTO>> GetAll()
        {
            var countriesDTO = _countryServices.GetAll();
            return Ok(countriesDTO);
        }

        [HttpPost]
        public ActionResult AddCountry([FromBody] AddCountryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _countryServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }
    }
}
