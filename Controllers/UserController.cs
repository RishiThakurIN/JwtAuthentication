using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize(Roles ="Administrator")]
        public IActionResult AdminEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }

        [HttpGet("seller")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Hi! you are on public property");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;

                return new UserModel
                {
                    Username = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }

    }
}
