using Biblioteka.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteka.View
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult<ICollection<UserDTO>> GetAll()
        {
            var usersDTO = _userServices.GetAll();
            return Ok(usersDTO);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult RegisterUser([FromBody] AddUserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = _userServices.Add(dto);

            if (!isAdded) return BadRequest();
            else
            {
                return Ok();
            }
        }

        [HttpPut("{email}")]
        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult ChangePassword([FromBody] ChangePasswordDTO dto, [FromRoute] string email)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _userServices.ChangePassword(email, dto);
            if (!isUpdated) return NotFound();
            else
            {
                return Ok();
            }
        }

        [HttpPost("login")]
        public ActionResult LoginUserDTO([FromBody] LoginUserDTO dto)
        {
            string token = _userServices.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
