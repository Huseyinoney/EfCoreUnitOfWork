using Business.Abstract;
using Business.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var response = await userService.AddUser(registerDTO.Username, registerDTO.Password);
            return Ok(response);
        }

    }
}
