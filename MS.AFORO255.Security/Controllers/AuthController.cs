using Aforo255.Cross.Token.Src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MS.AFORO255.Security.DTOs;
using MS.AFORO255.Security.Services;
using System.Text.Json;

namespace MS.AFORO255.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;
        private readonly JwtOptions _jwtOption;
        readonly ILogger<AuthController> _log;

        public AuthController(IAccessService accessService,
            IOptionsSnapshot<JwtOptions> jwtOption, ILogger<AuthController> log)
        {
            _accessService = accessService;
            _jwtOption = jwtOption.Value;
            _log = log;
        }


        [HttpGet]
        public IActionResult Get()
        {
            _log.LogInformation("Get AuthController");
            return Ok(_accessService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            _log.LogInformation("Post AuthController with data {0}", JsonSerializer.Serialize(request));

            if (!_accessService.Validate(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));

            return Ok();
        }


    }
}
