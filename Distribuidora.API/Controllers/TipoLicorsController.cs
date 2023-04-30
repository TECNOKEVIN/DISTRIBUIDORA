﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Distribuidora.API.Data;
using Distribuidora.Shared.Entities;

namespace Distribuidora.API.Controllers
{
    [ApiController]
    [Route("/api/tipolicores")]
    public class TipoLicorsController : ControllerBase
    {

        private readonly DataContext _context;

        public TipoLicorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.TipoLicors
                .Include(x => x.Licors)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var tipolicor = await _context.TipoLicors
                .Include(x => x.Licors)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (tipolicor == null)
            {
                return NotFound();
            }
            return Ok(tipolicor);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoLicor tipolicor)
        {
            try
            {
                _context.Add(tipolicor);
                await _context.SaveChangesAsync();
                return Ok(tipolicor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un tipo de licor con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(TipoLicor tipolicor)
        {
            try
            {
                _context.Update(tipolicor);
                await _context.SaveChangesAsync();
                return Ok(tipolicor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un tipo de licor con el mismo nombre.");
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
            var tipolicor = await _context.TipoLicors.FirstOrDefaultAsync(x => x.Id == id);
            if (tipolicor == null)
            {
                return NotFound();
            }

            _context.Remove(tipolicor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}