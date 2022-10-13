using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyApi.Models;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCompaniesController : ControllerBase
    {
        private readonly db_a8d373_aljazerasoftContext _context;

        public ClientCompaniesController(db_a8d373_aljazerasoftContext context)
        {
            _context = context;
        }

        // GET: api/ClientCompanies
        [HttpGet]
        public async Task<ActionResult<Company>> GetClientCompanies([FromQuery] String username, String password)
        {
            // Status Of Return 
            //------------------------------------------------
            // 1- return 'Data' is mean login with Successe
            // 2- return '2' is mean Active Status is Blocked
            // 3- return '0' is mean is not Found 
            //------------------------------------------------


            var result = await _context.ClientCompanies.Where(cC => cC.CompanyUsernam == username && cC.CompanyPasswrod == password  ).ToListAsync();

            if (!result.Any())
            {
                return Ok(0);
            }
            else
            {
                if(result[0].CompanyActiveStatus == 1)
                {
                    Company company = new Company();
                    company.CompanyNumber = result[0].CompanyNumber;
                    company.CompanyName = result[0].CompanyName;
                    company.CompanyTaxNumber = result[0].CompanyTaxNumber;
                    company.CompanyPhone = result[0].CompanyPhone;
                    company.CompanyAddress = result[0].CompanyAddress;
                    company.CompanyCommercial = result[0].CompanyCommercial;
                    company.CompanyZoneCount = result[0].CompanyZoneCount;
                    company.CompanyLink= result[0].CompanyLink;

                    return company;
                }
                else
                {
                    return Ok(2);
                }

            }

           
        }

        // GET: api/ClientCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientCompany>> GetClientCompany(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);

            if (clientCompany == null)
            {
                return NotFound();
            }

            return clientCompany;
        }

        // PUT: api/ClientCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientCompany(int id, ClientCompany clientCompany)
        {
            if (id != clientCompany.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(clientCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCompanyExists(id))
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



        // POST: api/ClientCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientCompany>> PostClientCompany(ClientCompany clientCompany)
        {
            _context.ClientCompanies.Add(clientCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientCompany", new { id = clientCompany.CompanyId }, clientCompany);
        }

        // DELETE: api/ClientCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientCompany(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            _context.ClientCompanies.Remove(clientCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientCompanyExists(int id)
        {
            return _context.ClientCompanies.Any(e => e.CompanyId == id);
        }

      



    }
}
