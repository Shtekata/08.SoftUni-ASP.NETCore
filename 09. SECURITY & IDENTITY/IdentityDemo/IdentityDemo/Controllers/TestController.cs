using IdentityDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDemo.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Test()
        {
            var result = await userManager.CreateAsync(new ApplicationUser
            {
                Email = "a@a",
                UserName = "S",
                EmailConfirmed = true,
                PhoneNumber = "123",
                FullName = "AG",
            }, "111111");

            if (result.Succeeded)
            {
                //User registered
            }
            else
            {
                //result.Errors holds error messages
            }

            return Json(result);
        }

        public async Task<IActionResult> Test2()
        {
            var result = await signInManager.PasswordSignInAsync("gesheval@gmail.com", "1qa@WS1qa", true, true);

            return Json(result);
        }

        [AllowAnonymous]
        public IActionResult WhoAmI()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }
            else
            {
                return Ok(User.Identity.Name);
            }
        }

        //[Authorize]
        public IActionResult WhoAmI2()
        {
            return Ok(User.Identity.Name);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> WhoAmI3()
        {
            var user = await userManager.GetUserAsync(User);
            //return Json(user.Id);
            return Json(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PostalCode)?.Value);
        }

        public async Task<IActionResult> Test3()
        {
            var result = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });

            var user = await userManager.GetUserAsync(User);
            await userManager.AddToRoleAsync(user, "Admin");

            if (User.IsInRole("Admin")) { ViewBag.Message = "Welcome to admin area!"; };

            return Json(result);
        }

        public async Task<IActionResult> Test4()
        {
            var user = await userManager.GetUserAsync(User);
            var result = await userManager.AddClaimAsync(user, new Claim(ClaimTypes.PostalCode, "1111"));

            return Json(result);
        }

        [Authorize(Policy = "WithAddress")]
        public IActionResult Test5()
        {
            return Json("Hello!");
        }
    }
}
