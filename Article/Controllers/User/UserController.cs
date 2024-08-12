using ArticleApp.Data.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpGet]
    [Authorize]
    public async Task<List<string>> Get()
    {
        return await _userRepository.GetUserNames();
    }
}