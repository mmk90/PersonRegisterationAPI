using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonRegisteration;
using Newtonsoft.Json;

namespace PersonRegisteration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PeopleController(PersonDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var people = _context.People.Include(c => c.PersonPersonalities).ToList();
            foreach (var item in people)
            {
                foreach (var item2 in item.PersonPersonalities)
                {
                    item.personalities += _context.Personality.Find(item2.PersonalityId).Title + ", ";
                    item.personalitiesIds.Add(item2.PersonalityId);
                }
                item.personalities = item.personalities?.Remove(item.personalities.Length - 2);
                item.PersonPersonalities = null;
            }

            return people;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var personalitiesId = _context.PersonPersonality.Where(c => c.PersonId == person.Id)?.ToList();
                if (personalitiesId != null)
                {
                    foreach (var item in personalitiesId)
                    {
                        _context.PersonPersonality.Remove(item);
                        _context.SaveChanges();
                    }
                }

                if (person.personalitiesIds != null && person.personalitiesIds.Count() > 0)
                {
                    foreach (var item in person.personalitiesIds)
                    {
                        _context.PersonPersonality.Add(new PersonPersonality() { PersonalityId = item, PersonId = person.Id });
                        _context.SaveChanges();
                    }

                }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            if (person.personalitiesIds != null && person.personalitiesIds.Count() > 0)
            {
                foreach (var item in person.personalitiesIds)
                {
                    _context.PersonPersonality.Add(new PersonPersonality() { PersonalityId = item, PersonId = person.Id });
                    _context.SaveChanges();
                }

            }



            return NoContent();
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
