using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeAPI.Data;
using CoffeeAPI.Model;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeDaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoffeeDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeDay>>> GetCoffeeDays()
        {
          if (_context.CoffeeDays == null)
          {
              return NotFound();
          }
            return await _context.CoffeeDays.ToListAsync();
        }

        // GET: api/CoffeeDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeDay>> GetCoffeeDay(int id)
        {
          if (_context.CoffeeDays == null)
          {
              return NotFound();
          }
            var coffeeDay = await _context.CoffeeDays.FindAsync(id);

            if (coffeeDay == null)
            {
                return NotFound();
            }

            return coffeeDay;
        }

        // PUT: api/CoffeeDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffeeDay(int id, CoffeeDay coffeeDay)
        {
            if (id != coffeeDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffeeDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeDayExists(id))
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

        // POST: api/CoffeeDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoffeeDay>> PostCoffeeDay(CoffeeDay coffeeDay)
        {
          if (_context.CoffeeDays == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CoffeeDays'  is null.");
          }
            _context.CoffeeDays.Add(coffeeDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoffeeDay", new { id = coffeeDay.Id }, coffeeDay);
        }

        // DELETE: api/CoffeeDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeDay(int id)
        {
            if (_context.CoffeeDays == null)
            {
                return NotFound();
            }
            var coffeeDay = await _context.CoffeeDays.FindAsync(id);
            if (coffeeDay == null)
            {
                return NotFound();
            }

            _context.CoffeeDays.Remove(coffeeDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeDayExists(int id)
        {
            return (_context.CoffeeDays?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
