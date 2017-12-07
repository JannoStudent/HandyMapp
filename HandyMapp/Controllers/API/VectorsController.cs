using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandyMapp.Data;
using HandyMapp.Models.Navigation;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Vectors")]
    public class VectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vectors
        [HttpGet]
        public IEnumerable<Vector> GetVectors()
        {
            return _context.Vectors;
        }

        // GET: api/Vectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vector = await _context.Vectors.SingleOrDefaultAsync(m => m.Id == id);

            if (vector == null)
            {
                return NotFound();
            }

            return Ok(vector);
        }

        // PUT: api/Vectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVector([FromRoute] int id, [FromBody] Vector vector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vector.Id)
            {
                return BadRequest();
            }

            _context.Entry(vector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VectorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vectors
        [HttpPost]
        public async Task<IActionResult> PostVector([FromBody] Vector vector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vectors.Add(vector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVector", new { id = vector.Id }, vector);
        }

        // DELETE: api/Vectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vector = await _context.Vectors.SingleOrDefaultAsync(m => m.Id == id);
            if (vector == null)
            {
                return NotFound();
            }

            _context.Vectors.Remove(vector);
            await _context.SaveChangesAsync();

            return Ok(vector);
        }

        private bool VectorExists(int id)
        {
            return _context.Vectors.Any(e => e.Id == id);
        }
    }
}