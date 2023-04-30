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
            return Ok(await _context.Sedes
                .Include(x => x.TipoLicors)
                .ToListAsync());
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.Sedes
                .Include(x => x.TipoLicors!)
                .ThenInclude(x => x.Licors)
                .ToListAsync());
        }


        //get parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var sede = await _context.Sedes
                
                .Include(x => x.TipoLicors)
                .ThenInclude(x => x.Licors)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (sede is null)
            {
                return NotFound();
            }

            return Ok(sede);
        }


        //create
        [HttpPost]
        public async Task<ActionResult> Post(Sede sede)
        {
            _context.Add(sede);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(sede);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una sede con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Sede sede)
        {
            _context.Update(sede);
            await _context.SaveChangesAsync();
            return Ok(sede);
        }


        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Sedes
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
