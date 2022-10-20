using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyApi.Models;
using CompanyApi.HelperCors;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly db_a8d373_aljazerasoftContext _context;

        public ClientsController(db_a8d373_aljazerasoftContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients([FromQuery] PagingMove paging, [FromQuery] String? searchString)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }

            var _client = await _context.Clients.Include(c => c.ClientCompanies).OrderByDescending(c => c.ClientId).ToListAsync();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                _client = _client.Where(c => c.ClientName.StartsWith(searchString)||
                                        c.ClientEmail.StartsWith(searchString) 
                                         ).ToList();
            }
            
            var pagedResponse = new PagingResponse<Client>(_client.AsQueryable(), paging);
            return Ok(pagedResponse);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
             
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
             

                await _context.SaveChangesAsync();
               

                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }


        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Status/{id}")]
        public async Task<IActionResult> UpdateStatusClient(int id, Client client, [FromQuery] bool activeStatus)
        {
          
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            var result = await _context.ClientCompanies.Where(cC => cC.ClientId == client.ClientId).ToListAsync();
            _context.Entry(client).State = EntityState.Modified;
            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {

                    result[i].CompanyActiveStatus = activeStatus ? 1 : 0;
                    _context.Entry(result[i]).State = EntityState.Modified;
                }
            }
            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
       
    }
}
