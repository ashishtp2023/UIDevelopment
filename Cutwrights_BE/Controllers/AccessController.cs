using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CutwrightsCRUD.Models;
using CutwrightsCRUD.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CutwrightsCRUD.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUsers _context;

        public AccessController(IUsers context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {
            try
            {
                ViewData["ValidateMessage"] = "";

                if (modelLogin.Email == null || modelLogin.PassWord == null)
                {
                    ViewData["ValidateMessage"] = "Enter valid email id and password!";
                    return View();
                }

                var userdetails = _context.GetUserDetails(modelLogin.Email, modelLogin.PassWord);
                if (userdetails != null)
                {
                    if (modelLogin.Email == userdetails.emailaddress && modelLogin.PassWord == userdetails.password && userdetails.role == "Admin")
                    {
                        List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")
                    };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        AuthenticationProperties properties = new AuthenticationProperties()
                        {

                            AllowRefresh = true,
                            IsPersistent = modelLogin.KeepLoggedIn
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), properties);


                        return RedirectToAction("Index", "Admin"); //Boards / index
                    }
                    else if (modelLogin.Email == userdetails.emailaddress && modelLogin.PassWord == userdetails.password && userdetails.role == "Office")
                    {
                        List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")

                     };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            AllowRefresh = true,
                            IsPersistent = modelLogin.KeepLoggedIn
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), properties);

                        return RedirectToAction("Index", "Office");
                    }
                    else if (modelLogin.Email == userdetails.emailaddress && modelLogin.PassWord == userdetails.password && userdetails.role == "Workshop")
                    {
                        List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")

                     };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            AllowRefresh = true,
                            IsPersistent = modelLogin.KeepLoggedIn
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), properties);

                        return RedirectToAction("Index", "Office");
                    }
                }

                ViewData["ValidateMessage"] = "User not found";
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
    }
}
