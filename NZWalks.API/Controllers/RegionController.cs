using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDBContext _context;

        public RegionController(NZWalksDBContext context)
        {
            _context = context;
        }

        // GET: api/Region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> Getregions()
        {
          if (_context.regions == null)
          {
              return NotFound();
          }
            return await _context.regions.ToListAsync();
        }

        // GET: api/Region/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(Guid id)
        {
          if (_context.regions == null)
          {
              return NotFound();
          }
            var region = await _context.regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/Region/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(Guid id, Region region)
        {
            if(ModelState.IsValid)
            {
                if (id != region.Id)
                {
                    return BadRequest();
                }

                _context.Entry(region).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            return NoContent();
        }

        // POST: api/Region
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
          if (_context.regions == null)
          {
              return Problem("Entity set 'NZWalksDBContext.regions'  is null.");
          }
            _context.regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        // DELETE: api/Region/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            if (_context.regions == null)
            {
                return NotFound();
            }
            var region = await _context.regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(Guid id)
        {
            return (_context.regions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
