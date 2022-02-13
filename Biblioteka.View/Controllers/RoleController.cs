using Biblioteka.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteka.View
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleServices roleServices, ILogger<RoleController> logger)
        {
            _roleServices = roleServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<ICollection<RoleDTO>> GetAll()
        {
            var usersDTO = _roleServices.GetAll();
            return Ok(usersDTO);
        }

        [HttpPost]
        public ActionResult AddRole([FromBody] AddRoleDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roleServices.Add(dto);

            return Ok();
        }

        [HttpPut("{name}")]
        public ActionResult Update([FromBody] UpdateRoleDTO dto, [FromRoute] string name)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _roleServices.Update(name, dto);
            if (!isUpdated) return NotFound();
            else
            {
                return Ok();
            }
        }
    }
}
