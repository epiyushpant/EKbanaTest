using EKbanaTest.DTO;
using EKbanaTest.Queries;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EKbanaTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly IEmployeeLoginRepo _empLoginRepo;
        private readonly IEmployeeQueriesRepo _employeeQueriesRepo;

        public LoginController(IEmployeeLoginRepo empLoginRepo , IEmployeeQueriesRepo employeeQueriesRepo)
        {
            _empLoginRepo = empLoginRepo;
            _employeeQueriesRepo = employeeQueriesRepo;
        }


        // GET: LoginController
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(EmployeeLogin emp)
        {

            if (ModelState.IsValid)
            {
               
                var user = _empLoginRepo.ValidateEmployee(emp);

                if(user != null)
                {
                   
                    var claims = new List<Claim>
                            {
                             new Claim(ClaimTypes.Name, user.Email),
                             new Claim("Name",user.Name)
                            };

                  
                    var userRoles = _employeeQueriesRepo.Find(user.EmployeeId);
                    var roleClaim = new Claim(ClaimTypes.Role, userRoles.RoleName); ;
                    claims.Add(roleClaim);
                  
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties() { IsPersistent = emp.IsPersistant };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return Redirect("Employees/Index");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "Either username or password is not correct");
                }
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Login");
        }


    }
}
