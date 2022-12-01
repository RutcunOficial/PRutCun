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
    public class TrasporteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public TrasporteController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UDRF3CJ; Initial Catalog=Rutcun; Integrated Security=True;");
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var response = await _context.ArticuloDb.ToListAsync();
            var response = await connection.QueryAsync<Transporte>("SpGetTrasporte", new { }, commandType: CommandType.StoredProcedure);
            return View(response);
        }
        [HttpGet]
        public IActionResult VistaCrear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Transporte i)
        {
            try
            {
                var response = await connection.QueryAsync<Transporte>("Sp_IngresarRuta", new { i.Nombre,i.HoraInicial,i.HoraFinal,i.Dia,i.Estatus,i.FkTipo }, commandType: CommandType.StoredProcedure); ;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult EditarTrasporte(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var trasporte = _context.Trasporte.Find(id);
            if (trasporte == null)
            { return NotFound(); }

            return View(trasporte);
        }
        [HttpPost]
        public async Task<ActionResult> TrasporteEditar(Transporte request)
        {

            Transporte trasporte = new Transporte();
            trasporte = _context.Trasporte.Find(request.PkTransporte);
            if (trasporte != null)
            {

                await connection.QueryAsync<Transporte>("SpUpdateRuta", new { request.PkTransporte,request.Nombre,request.HoraInicial,request.HoraFinal,request.Dia,request.Estatus,request.FkTipo }, commandType: CommandType.StoredProcedure);

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Transporte trasporte = new Transporte();
            trasporte.PkTransporte = id;
            return View(trasporte);
        }
        [HttpPost]
        public async Task<IActionResult> Borrar(Transporte i)
        {
            try
            {
                var response = await connection.QueryAsync<Transporte>("Sp_DeleteRuta", new { i.PkTransporte}, commandType: CommandType.StoredProcedure); ;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
    }
}
