using ClarisaMendoza.Data;
using ClarisaMendoza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarisaMendoza.Controllers
{
    public class PrestamoController : Controller
    {
      
        private readonly ILogger<PrestamoController> _logger;
        private readonly MyDbContext _dbContext;
        List<Prestamo> listadoPrestamo = new List<Prestamo>();
        Prestamo Prestamo = new Prestamo();

        public PrestamoController(ILogger<PrestamoController> logger, MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View("AgregarPrestamo");
        }
        public IActionResult AgregarPrestamo(Prestamo Prestamo2)
        {
            try
            {
                if (Prestamo2.EstadoPrestamo != null)
                {
                    if (Prestamo2.IdPrestamo != 0)
                    {
                        Prestamo = _dbContext.Prestamo.Where(x => x.IdPrestamo == Prestamo2.IdPrestamo).FirstOrDefault();
                        Prestamo.Interes = Prestamo2.Interes;
                        Prestamo.IdCliente = Prestamo2.IdCliente;
                        Prestamo.EstadoPrestamo = Prestamo2.EstadoPrestamo;
                        Prestamo.Plazo = Prestamo2.Plazo;
                        _dbContext.Update(Prestamo);
                        _dbContext.SaveChanges();
                        return View(Prestamo);
                    }
                    else
                    {
                        Prestamo2.FechaCreacion = DateTime.Now.Date;
                        _dbContext.Add(Prestamo2);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(Prestamo);
        }
        public IActionResult ListarPrestamo()
        {

            try
            {
                listadoPrestamo = _dbContext.Prestamo.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(listadoPrestamo);

        }
        public IActionResult EliminarPrestamo(int IdPrestamo)
        {
            try
            {
                Prestamo Prestamo = _dbContext.Prestamo.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();
                _dbContext.Remove(Prestamo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View("ListarPrestamo");
        }

    }
}
