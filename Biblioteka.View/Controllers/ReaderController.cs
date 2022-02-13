using Biblioteka.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteka.View
{
    [Route("api/reader")]
    [ApiController]
    [Authorize(Roles = "Admin,Librarian")]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderServices _readerServices;
        private readonly ILogger<ReaderController> _logger;

        public ReaderController(IReaderServices readerServices, ILogger<ReaderController> logger)
        {
            _readerServices = readerServices;
            _logger = logger;
        }

        [HttpGet]

        public ActionResult<IEnumerable<ReaderDTO>> GetAll()
        {
            var readersDTO = _readerServices.GetAll();

            _logger.LogInformation($"All readers listed.");

            return Ok(readersDTO);
        }

        [HttpPost]
        public ActionResult AddReader([FromBody] AddReaderDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _readerServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }
    }
}
