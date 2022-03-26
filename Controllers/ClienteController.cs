using ClarisaMendoza.Data;
using ClarisaMendoza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarisaMendoza.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly MyDbContext _dbContext;
        List<Cliente> listadocliente = new List<Cliente>();
        Cliente cliente = new Cliente();

        public ClienteController(ILogger<ClienteController> logger,MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View("AgregarCliente");
        }
        public IActionResult AgregarCliente(Cliente cliente2)
        {
            try
            {
                if (cliente2.Apellido != null)
                {
                    if (cliente2.IdCliente != 0)
                    {
                        cliente = _dbContext.Cliente.Where(x => x.IdCliente == cliente2.IdCliente).FirstOrDefault();
                        cliente.Nombre = cliente2.Nombre;
                        cliente.Apellido = cliente2.Apellido;
                        cliente.Telefono = cliente2.Telefono;
                        cliente.Genero = cliente2.Genero;
                        cliente.Direccion = cliente2.Direccion;
                        _dbContext.Update(cliente);
                        _dbContext.SaveChanges();
                        return View(cliente);
                    }
                    else
                    {

                        cliente2.FechaCreacion = DateTime.Now.Date;
                        _dbContext.Add(cliente2);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(cliente);
        }
        public IActionResult ListarClientes()
        {
            
            try
            {
                 listadocliente = _dbContext.Cliente.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
            return View(listadocliente);

        }
        public IActionResult EliminarCliente(int IdCliente)
        {
            try
            {
               Cliente cliente = _dbContext.Cliente.Where(x=>x.IdCliente == IdCliente).FirstOrDefault();
                _dbContext.Remove(cliente);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View("ListarClientes");
        }
    }
}
