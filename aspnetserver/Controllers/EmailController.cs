using aspnetserver.Services;
using AutoMapper;
using Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static aspnetserver.Constants.AppConstants;

namespace aspnetserver.Controllers
{
    [Route("")]
    public class EmailController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly IConfiguration configuration;

        public EmailController(IUsersService usersService, IMapper mapper, IConfiguration configuration) : base(mapper)
        {
            this.usersService = usersService;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("/confirm-email")]
        [Tags("Auth Endpoint")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await usersService.GetUserByUsernameAsync(email);

            if (user == null) return NotFound($"User with username: {email} was not found");
            if (await usersService.ConfirmEmailForUserAsync(user, token))
            {
                var environment = configuration["Environment"];
                var redirectToLogin = "";

                switch (environment)
                {
                    case "DEV":
                        redirectToLogin = $"{devClientUrl}/login";
                        break;
                    case "PRD":
                        redirectToLogin = $"{prdClientUrl}/login";
                        break;
                    default:
                        break;
                }

                return Redirect(redirectToLogin);
            }
            else return BadRequest("Error during email confirmation");
        }
    }
}
