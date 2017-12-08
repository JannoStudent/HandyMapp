using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandyMapp.Data;
using HandyMapp.Models;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Examples")]
    public class ExamplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Examples
        [HttpGet]
        public IEnumerable<Example> GetExample()
        {
            return _context.Example.ToList();
        }

        // GET: api/Examples/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExample([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var example = await _context.Example.SingleOrDefaultAsync(m => m.Id == id);

            if (example == null)
            {
                return NotFound();
            }

            return Ok(example);
        }

        // PUT: api/Examples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExample([FromRoute] int id, [FromBody] Example example)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != example.Id)
            {
                return BadRequest();
            }

            _context.Entry(example).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExampleExists(id))
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

        // POST: api/Examples
        [HttpPost]
        public async Task<IActionResult> PostExample([FromBody] Example example)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Example.Add(example);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExample", new { id = example.Id }, example);
        }

        // DELETE: api/Examples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExample([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var example = await _context.Example.SingleOrDefaultAsync(m => m.Id == id);
            if (example == null)
            {
                return NotFound();
            }

            _context.Example.Remove(example);
            await _context.SaveChangesAsync();

            return Ok(example);
        }

        private bool ExampleExists(int id)
        {
            return _context.Example.Any(e => e.Id == id);
        }
    }
}