using FitFolio.Authorization;
using FitFolio.Data.Models;
using FitFolio.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitFolio.Controllers
{
    public class AuthController : Controller
    {
        JwtTokenGenerator _jwtTokenGenerator;
        SignInManager<ApplicationUser> _signInManager;

        public AuthController(JwtTokenGenerator jwtTokenGenerator, SignInManager<ApplicationUser> signInManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("/api/auth/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login?.Trim(), model.Password?.Trim(), model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(model.Login);
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = _jwtTokenGenerator.GenerateToken(user);

                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest(result);
            }                      
        }

        [HttpPost]
        [Route("/api/auth/register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = _jwtTokenGenerator.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("/api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "success" });
        }
    }
}
