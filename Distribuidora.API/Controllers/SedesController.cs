using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Distribuidora.API.Data;
using Distribuidora.Shared.Entities;


namespace Distribuidora.API.Controllers
{
    [ApiController]
    [Route("/api/sedes")]
    public class SedesController: ControllerBase
    {

        private readonly DataContext _context;
        private readonly DataContext context;

        public SedesController(DataContext context)
        {
            _context = context;
        }

        //get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Sedes.ToListAsync());
        }

        //create
        [HttpPost]
        public async Task<ActionResult> Post(Sede sede)
        {
            _context.Add(sede);
            await _context.SaveChangesAsync();
            return Ok(sede);
        }

    }
}
