using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Distribuidora.API.Data;
using Distribuidora.Shared.Entities;

namespace Distribuidora.API.Controllers
{
    [ApiController]
    [Route("/api/licores")]
    public class LicorsController : ControllerBase
    {

        private readonly DataContext _context;

        public LicorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Licors.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var licor = await _context.Licors.FirstOrDefaultAsync(x => x.Id == id);
            if (licor == null)
            {
                return NotFound();
            }

            return Ok(licor);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Licor licor)
        {
            try
            {
                _context.Add(licor);
                await _context.SaveChangesAsync();
                return Ok(licor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un licor con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Licor licor)
        {
            try
            {
                _context.Update(licor);
                await _context.SaveChangesAsync();
                return Ok(licor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un licor con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var licor = await _context.Licors.FirstOrDefaultAsync(x => x.Id == id);
            if (licor == null)
            {
                return NotFound();
            }

            _context.Remove(licor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
