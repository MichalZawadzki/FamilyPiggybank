using FamilyPiggybank.API.Infrastructure;
using FamilyPiggybank.API.Models;
using FamilyPiggybank.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FamilyPiggybank.API.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings, IIdentityService identityService)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }

        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                UserName = model.FamilyName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Created();
            }

            return BadRequest(result.Errors.MapToMetaError());
        }

        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginUserRequestModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var result = new LoginResponseModel
            {
                Token = identityService.GenerateJwtToken(user, appSettings.Secret)
            };

            return Ok(result);
        }
    }
}
