using Login.Application.Login.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Login.Application.Login.Command;
using Login.API.Controllers.Base;
using Login.Application.Abstract.Interface.Services;

namespace Login.API.Controllers
{
    [Route("api")]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly ISender _mediatR;

        public LoginController(ILoginService loginService, ISender mediatR)
        {
            _loginService = loginService;
            _mediatR = mediatR;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginQuery request)
        {
            var result = await _loginService.Login(request);

            return ResponseResult(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignupCommand request)
        {
            var result = await _mediatR.Send(request);

            return ResponseResult(result);
        }

        [HttpGet("GenerateToken")]
        public async Task<IActionResult> GenerateToken(string email, string firstName, string lastName)
        {
            var result = await _loginService.GenerateToken(email, firstName, lastName);

            if (result.IsError)
            {
                return ResponseResult(result);
            }

            return Ok(new { Token = result.Value });
        }
    }
}
