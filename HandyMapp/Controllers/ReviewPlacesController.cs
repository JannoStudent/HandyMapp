using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandyMapp.Data;
using HandyMapp.Models.AddressModels;

namespace HandyMapp.Controllers
{
    [Produces("application/json")]
    [Route("api/ReviewPlaces")]
    public class ReviewPlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReviewPlaces
        [HttpGet]
        public IEnumerable<ReviewAddress> GetReviewAddress()
        {
            return _context.ReviewAddress;
        }

        // GET: api/ReviewPlaces/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewAddress = await _context.ReviewAddress.SingleOrDefaultAsync(m => m.Id == id);

            if (reviewAddress == null)
            {
                return NotFound();
            }

            return Ok(reviewAddress);
        }

        // PUT: api/ReviewPlaces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewAddress([FromRoute] int id, [FromBody] ReviewAddress reviewAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewAddressExists(id))
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

        // POST: api/ReviewPlaces
        [HttpPost]
        public async Task<IActionResult> PostReviewAddress([FromBody] ReviewAddress reviewAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReviewAddress.Add(reviewAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewAddress", new { id = reviewAddress.Id }, reviewAddress);
        }

        // DELETE: api/ReviewPlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewAddress = await _context.ReviewAddress.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewAddress == null)
            {
                return NotFound();
            }

            _context.ReviewAddress.Remove(reviewAddress);
            await _context.SaveChangesAsync();

            return Ok(reviewAddress);
        }

        private bool ReviewAddressExists(int id)
        {
            return _context.ReviewAddress.Any(e => e.Id == id);
        }
    }
}