using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceWorkersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ServiceWorkersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceWorker>>> GetServiceWorkers()
        {
            return await _context.ServiceWorkers.ToListAsync();
        }

        // GET: api/ServiceWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceWorker>> GetServiceWorker(int id)
        {
            var serviceWorker = await _context.ServiceWorkers.FindAsync(id);

            if (serviceWorker == null)
            {
                return NotFound();
            }

            return serviceWorker;
        }

        // PUT: api/ServiceWorkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceWorker(int id, ServiceWorker serviceWorker)
        {
            if (id != serviceWorker.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceWorkerExists(id))
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

        // POST: api/ServiceWorkers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceWorker>> PostServiceWorker(ServiceWorker serviceWorker)
        {
            _context.ServiceWorkers.Add(serviceWorker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceWorker", new { id = serviceWorker.Id }, serviceWorker);
        }

        // DELETE: api/ServiceWorkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceWorker(int id)
        {
            var serviceWorker = await _context.ServiceWorkers.FindAsync(id);
            if (serviceWorker == null)
            {
                return NotFound();
            }

            _context.ServiceWorkers.Remove(serviceWorker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceWorkerExists(int id)
        {
            return _context.ServiceWorkers.Any(e => e.Id == id);
        }
    }
}
