using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonRegisteration;

namespace PersonRegisteration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonalityController(PersonDbContext context)
        {
            _context = context;
        }

        // GET: api/Personality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personality>>> GetPersonality()
        {
            return await _context.Personality.ToListAsync();
        }

        // GET: api/Personality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personality>> GetPersonality(int id)
        {
            var personality = await _context.Personality.FindAsync(id);

            if (personality == null)
            {
                return NotFound();
            }

            return personality;
        }

        // PUT: api/Personality/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonality(int id, Personality personality)
        {
            if (id != personality.Id)
            {
                return BadRequest();
            }

            _context.Entry(personality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalityExists(id))
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

        // POST: api/Personality
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personality>> PostPersonality(Personality personality)
        {
            _context.Personality.Add(personality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonality", new { id = personality.Id }, personality);
        }

        // DELETE: api/Personality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonality(int id)
        {
            var personality = await _context.Personality.FindAsync(id);
            if (personality == null)
            {
                return NotFound();
            }

            _context.Personality.Remove(personality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalityExists(int id)
        {
            return _context.Personality.Any(e => e.Id == id);
        }
    }
}
