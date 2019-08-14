using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beer_Collection.Data;

namespace Beer_Collection.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly BeerContext _context;

        public BeerController(BeerContext context)
        {
            _context = context;
        }
        
        // GET: api/Beers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beer>>> GetBeer()
        {
            return await _context.Beers.ToListAsync();
        }

        // GET: api/Beers/id
        [HttpGet("{name}")]
        public async Task<ActionResult<Beer>> GetBeer(string name)
        {
            try
            {
                using (var beer = new BeerContext())
                {
                    var beerName = beer.Beers.Where(s => s.Name.ToUpper().Contains(name.ToUpper()))
                                             .Include(x => x.Ratings)
                                             .FirstOrDefault<Beer>();

                    return beerName;
                }

            }
            catch(Exception ex)
            {                
                return BadRequest(ex.Message);
            }
            
        }

        // PUT: api/Beers/5
        [HttpPut]
        public async Task<IActionResult> PutBeer([FromBody] Rating rating)
        {
            if (BeerExists(rating.BeerId) == false)
            {
                return NotFound();
            }

            _context.Ratings.Add(rating);
            try
            {
               await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(200, rating);
        }

        // POST: api/Beers
        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer([FromBody]Beer beer)
        {
            _context.Beers.Add(beer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201, beer);
        }

        // DELETE: api/Beers/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Beer>> DeleteBeer(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }

            _context.Beers.Remove(beer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return beer;
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }
    }
}
