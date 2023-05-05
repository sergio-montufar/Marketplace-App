using marketplaceapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marketplaceapp.Controllers {
  [Route("/user")]
  [ApiController]
  public class UserController : Controller {
    [HttpGet]
    public IActionResult Register() {
      return Ok("Success");
    }
  }



  // public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto) {
  //   if (await _userRepository.CheckUsernameExists(userDto.Username)) {
  //     return BadRequestResult("Username already exists.");
  //   }

  //   var user = new User {
  //     Username = userDto.Username,
  //     Password = userDto.Password
  //   };

  //   await _userRepository.AddUser(user);
  //   return OkObjectResult("User Created successfully"); 
  // }
}