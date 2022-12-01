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
using System.Text;
using System.Security.Cryptography;

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
                string contraseñaTemp = Encrypt(password);
                string contraseña = Decrypt(contraseñaTemp);
                var response = _context.Usuario.Include(u => u.Rol).FirstOrDefault(x => x.Nickname == user && x.Password == contraseñaTemp);
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

        public string Encrypt(String mensaje)
        {
            string hash = "Coding C";
            byte[] data = UTF8Encoding.UTF8.GetBytes(mensaje);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public string Decrypt(string MensajeEn)
        {
            string hash = "Coding C";
            byte[] data = Convert.FromBase64String(MensajeEn);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
