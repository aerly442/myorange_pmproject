using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;


using myorange_pmproject.Data;
using myorange_pmproject.Models;
using myorange_pmproject.Service;

namespace myorange_pmproject.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class LoginUserModel : PageModel
    {
    
        private readonly MyOrangePMPProjectContext _context;
        public LoginUserModel(MyOrangePMPProjectContext context
        )
         {
             _context     = context;

         }
         public void OnGet()
        {
            this.ViewData["ShowError"] = "";
        }

      

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            string ReturnUrl = returnUrl;

            string userName = Request.Form["UserName"];
            string password = Request.Form["Password"];
            string remember = Request.Form["rememberMe"];

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                this.ViewData["ShowError"] = "请输入用户名和密码！";
            }
            else
            {
                password = new Manager().GetEncodePassword(password);
                var user = _context.Manager.Where(x => x.password == password && x.username == userName).FirstOrDefault();
                if (user != null && user.Id > 0)
                {
                    string Role = user.power == 1 ? "Admin" : "User";
                    this.ViewData["ShowError"] = "";

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.name),
                        new Claim("UserName",user.username),
                        new Claim("UserId",user.Id.ToString()),
                        new Claim(ClaimTypes.Role, Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                         claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //cookie保留时间
                    int cookieTime = (String.IsNullOrEmpty(remember) == false && remember == "on") ? 10000 : 30;

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(cookieTime),


                    };
                    await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(claimsIdentity),
                      authProperties);
                    //HttpContext.User.
                    return LocalRedirect(string.IsNullOrEmpty(returnUrl)?"~/": returnUrl);
                }
                else
                {
                    this.ViewData["ShowError"] = "错误的用户名和密码！";
                }

            }
            return Page();
            
        }

 

    }
}
