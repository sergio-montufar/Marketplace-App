using marketplaceapp.Data;
using marketplaceapp.Dto;
using marketplaceapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketplaceapp.Controllers {
  [Route("/User")]
  [ApiController]
  public class UserController : Controller {
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository) {
      _repository = repository;
    }


    [HttpPost("/register")]
    public IActionResult Register(RegisterDto dto) {
      Console.WriteLine(dto.Username);
      var user = new User {
        Username = dto.Username,
        Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
      };

      return Created("s uccess", _repository.Create(user));
    }
  }
}