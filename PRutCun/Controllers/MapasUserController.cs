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
    public class MapasUserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public MapasUserController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SCRUN91; Initial Catalog=Rutcun; Integrated Security=True;");
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var response = await _context.ArticuloDb.ToListAsync();
            var response = await connection.QueryAsync<Mapas>("SpGetMapas", new { }, commandType: CommandType.StoredProcedure);
            return View(response);
        }
        [HttpGet]
        public IActionResult VistaCrear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Mapas i)
        {
            try
            {
                var response = await connection.QueryAsync<Mapas>("SpInsertMapas", new { i.MapaUrl,i.Fktrasportes}, commandType: CommandType.StoredProcedure); ;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult EditarMapas(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var mapas = _context.Mapas.Find(id);
            if (mapas == null)
            { return NotFound(); }

            return View(mapas);
        }
        [HttpPost]
        public async Task<ActionResult> MapasEditar(Mapas request)
        {

            Mapas mapas = new Mapas();
            mapas = _context.Mapas.Find(request.PkMapas);
            if (mapas != null)
            {
              
                await connection.QueryAsync<Mapas>("SpUpdateMapas", new { request.PkMapas,request.MapaUrl,request.Fktrasportes}, commandType: CommandType.StoredProcedure);

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
