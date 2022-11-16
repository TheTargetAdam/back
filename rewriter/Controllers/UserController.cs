using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rewriter.Services;
using rewriter.Services.Models;

namespace rewriter.Controllers
{

    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [Route("SignIn")]
        public async  Task<AuthResult> SignIn(LoginModel model)
        {
            var user = await userService.SignIn(model);
            return user;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<AuthResult> Register(RegisterModel model)
        {
            var user=await userService.Register(model);
            return user;
        }
        [HttpGet]
    
        public async Task<UserModel> GetUserById([FromQuery] int id)
        {
            var user = await userService.GetUserById(id);
            return user;
        }
    }
}
