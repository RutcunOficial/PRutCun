using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PRutCun.Context;
using PRutCun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRutCun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-ABQMQPT; Initial Catalog=Rutcun; Integrated Security=True;");

        [HttpPost]
        public async Task<ActionResult> Mapa(Mapas response)
        {
            Mapas mapas = new Mapas();
            mapas = _context.Mapas.Find(response.Fktrasportes);
            if (mapas != null)
            {
                var mapas1 = await connection.QueryAsync<Mapas>("SpMapaGet", new { response.Fktrasportes }, commandType: CommandType.StoredProcedure);
                //var mapas2 = await connection.QueryAsync<Mapas>("SpGetDatosT", new { response.Fktrasportes }, commandType: CommandType.StoredProcedure);
                
                return View(mapas1.FirstOrDefault());
            }
            return NotFound();

        }
        //[HttpPost]
        //public async Task<ActionResult> Texto(Mapas response)
        //{
        //    Mapas mapas = new Mapas();
        //    mapas = _context.Mapas.Find(response.Fktrasportes);
        //    if (mapas != null)
        //    {
        //        var a = await connection.QueryAsync<Mapas>("SpGetDatosT", new { response.Fktrasportes }, commandType: CommandType.StoredProcedure);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return NotFound();

        //}

        [HttpGet]

        public IActionResult Index()
        {
            ViewBag.Transporte = _context.Trasporte.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkTrasporte.ToString()


            });


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
