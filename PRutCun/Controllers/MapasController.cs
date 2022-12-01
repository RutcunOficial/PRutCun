﻿using PRutCun.Controllers;
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
    public class MapasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public MapasController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-V53B6UC\\SQLEXPRESS; Initial Catalog=Rutcun; Integrated Security=True;");
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
                var response = await connection.QueryAsync<Mapas>("SpInsertMapas", new { i.MapaUrl,i.Fktransportes}, commandType: CommandType.StoredProcedure); ;
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
              
                await connection.QueryAsync<Mapas>("SpUpdateMapas", new { request.PkMapas,request.MapaUrl,request.Fktransportes}, commandType: CommandType.StoredProcedure);

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Mapas mapas = new Mapas();
            mapas.PkMapas= id;
            return View(mapas);
        }
        [HttpPost]
        public async Task<IActionResult> Borrar(Mapas i)
        {
            try
            {
                var response = await connection.QueryAsync<Mapas>("SpDeleteMapas", new { i.PkMapas }, commandType: CommandType.StoredProcedure); ;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
    }
}
