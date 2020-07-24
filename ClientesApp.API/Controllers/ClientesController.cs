using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientesApp.API.Data;
using ClientesApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientesController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult>  ObtenerClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerCliente(int id) {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.ID_Cliente == id);
            return Ok(cliente);
        }
    }
}