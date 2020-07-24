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
    public class EstadosCivilesController : ControllerBase
    {
        private readonly DataContext _context;
        public EstadosCivilesController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerEstadosCiviles(){
            var estadosCiviles = await _context.EstadosCiviles.ToListAsync();
            return Ok(estadosCiviles);
        }

    }
}