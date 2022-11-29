using PRutCun.Controllers;
using PRutCun.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PRutCun.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace PRutCun.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public UsuarioController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UDRF3CJ; Initial Catalog=Rutcun; Integrated Security=True;");
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var response = await _context.ArticuloDb.ToListAsync();
            var response = await connection.QueryAsync<Usuario>("SpGetUsuarios", new { }, commandType: CommandType.StoredProcedure);
            return View(response);
        }
        [HttpGet]
        public IActionResult VistaCrear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Usuario i)
        {
            try
            {
                
                var response = await connection.QueryAsync<Usuario>("SpInsertUsuarios", new { i.Nombre, i.Nickname, i.Password,i.FkRol  }, commandType: CommandType.StoredProcedure); ;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
    }
}
