using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedRepository;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DhtMeasurementsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public DhtMeasurementsController(SqlDbContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DhtMeasurement>>> GetDhtMeasurements()
        {
            return await _context.DhtMeasurements.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DhtMeasurement>> GetDhtMeasurement(int id)
        {
            var dhtMeasurement = await _context.DhtMeasurements.FindAsync(id);

            if (dhtMeasurement == null)
            {
                return NotFound();
            }

            return dhtMeasurement;
        }


        [HttpPost]
        public async Task<ActionResult<DhtMeasurement>> PostDhtMeasurement(DhtMeasurement dhtMeasurement)
        {
            _context.DhtMeasurements.Add(dhtMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDhtMeasurement", new { id = dhtMeasurement.Id }, dhtMeasurement);
        }

    }
}
