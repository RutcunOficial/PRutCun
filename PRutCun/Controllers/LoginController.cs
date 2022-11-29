using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRutCun.Context;
using PRutCun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PRutCun.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;//va con guion bajo por que es una variable privada
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {
            try
            {
                var response = _context.Usuario.Include(u => u.Rol).FirstOrDefault(x => x.Nickname == user && x.Password == password);
                if (response != null)
                {
                    if (response.Rol.PkRol == 1)
                    {
                        return Json(new { Success = true, Admin = true });
                    }
                    return Json(new { Success = true, Admin = false });
                }
                else
                {
                    return Json(new { Success = false, Admin = false });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
    }
}
