using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMissions.Data;
using TheMissions.MissionModel;

namespace TheMissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsModelsController : ControllerBase
    {
        private readonly TheMissionsContext _context;

        public MissionsModelsController(TheMissionsContext context)
        {
            _context = context;
        }

        // GET: api/MissionsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionsModel>>> GetMissionsModel()
        {
            return await _context.MissionsModel.ToListAsync();
        }

        // GET: api/MissionsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionsModel>> GetMissionsModel(int id)
        {
            var missionsModel = await _context.MissionsModel.FindAsync(id);

            if (missionsModel == null)
            {
                return NotFound();
            }

            return missionsModel;
        }

        // PUT: api/MissionsModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionsModel(int id, MissionsModel missionsModel)
        {
            if (id != missionsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(missionsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionsModelExists(id))
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

        // POST: api/MissionsModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissionsModel>> PostMissionsModel(MissionsModel missionsModel)
        {
            _context.MissionsModel.Add(missionsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissionsModel", new { id = missionsModel.Id }, missionsModel);
        }

        // DELETE: api/MissionsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionsModel(int id)
        {
            var missionsModel = await _context.MissionsModel.FindAsync(id);
            if (missionsModel == null)
            {
                return NotFound();
            }

            _context.MissionsModel.Remove(missionsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionsModelExists(int id)
        {
            return _context.MissionsModel.Any(e => e.Id == id);
        }
    }
}
